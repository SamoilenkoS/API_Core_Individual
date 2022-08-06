using API_Core_BL.DTOs;
using API_Core_BL.Services.BooksService;
using API_Core_DAL;
using API_Core_DAL.Entities;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_UnitTests
{
    public class BooksServiceTests
    {
        private Fixture _fixture;
        private Mock<IGenericRepository<Book>> _genericBooksRepositoryMock;
        private Mock<IBookRevisionRepository> _booksRevisionRepositoryMock;

        public BooksServiceTests()
        {
            _fixture = new Fixture();
            _genericBooksRepositoryMock = new Mock<IGenericRepository<Book>>();
            _booksRevisionRepositoryMock = new Mock<IBookRevisionRepository>();
        }

        [Test]
        public async Task GetAllBooksAsync_WhenCalled_ShouldGetDataFromRepository()
        {
            var booksRepositoryResponse = new List<Book>
            {
                _fixture.Create<Book>(),
                _fixture.Create<Book>()
            };

            _genericBooksRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(booksRepositoryResponse)
                .Verifiable();
            var booksService = new BooksService(
                _genericBooksRepositoryMock.Object,
                _booksRevisionRepositoryMock.Object);

            var actulBooks = await booksService.GetAllBooksAsync();

            CollectionAssert.AreEqual(booksRepositoryResponse, actulBooks);
            _genericBooksRepositoryMock.Verify();
        }

        [Test]
        public async Task AddBookAsync_WhenCalled_ShouldAddBookToRepository()
        {
            var addBook = _fixture.Create<Book>();
            var addBookGuid = Guid.NewGuid();

            _genericBooksRepositoryMock
                .Setup(repository =>
                    repository.AddAsync(
                        It.Is<Book>(book =>
                            book.Author == addBook.Author &&
                            book.Title == addBook.Title)))
                .ReturnsAsync(addBookGuid)
                .Verifiable();
            var booksService = new BooksService(
                _genericBooksRepositoryMock.Object,
                _booksRevisionRepositoryMock.Object);

            var actualBookGuid = await booksService.AddBookAsync(addBook);

            actualBookGuid.Should().Be(addBookGuid);
            _genericBooksRepositoryMock.Verify();
        }

        [Test]
        public async Task DeleteBookAsync_WhenCalled_ShouldDeleteBookFromRepository()
        {
            var deleteBook = _fixture.Create<Book>();

            _genericBooksRepositoryMock
                .Setup(repository =>
                    repository.DeleteAsync(deleteBook.Id))
                .ReturnsAsync(true)
                .Verifiable();
            var booksService = new BooksService(
                _genericBooksRepositoryMock.Object,
                _booksRevisionRepositoryMock.Object);

            bool deleteBookBool = false;
            deleteBookBool = await booksService.DeleteBookAsync(deleteBook.Id);

            deleteBookBool.Should().Be(true);
            _genericBooksRepositoryMock.Verify();
        }

        [Test]
        public async Task UpdateBookAsync_WhenCalled_ShouldUpdateBookInRepository()
        {
            var updateBook = _fixture.Create<Book>();

            _genericBooksRepositoryMock
                .Setup(repository =>
                    repository.UpdateAsync(
                        It.Is<Book>(book =>
                            book.Author == updateBook.Author &&
                            book.Title == updateBook.Title)))
                .ReturnsAsync(true)
                .Verifiable();
            var booksService = new BooksService(
                _genericBooksRepositoryMock.Object,
                _booksRevisionRepositoryMock.Object);

            bool updateBookBool = false;
            updateBookBool = await booksService.UpdateBookAsync(updateBook);

            updateBookBool.Should().Be(true);
            _genericBooksRepositoryMock.Verify();
        }

        [Test]
        public async Task GetBookByIdAsync_WhenCalled_ShouldGetBookByIdRepository()
        {
            var getBook = _fixture.Create<Book>();

            _genericBooksRepositoryMock
                .Setup(repository =>
                    repository.GetByIdAsync(getBook.Id))
                .ReturnsAsync(getBook)
                .Verifiable();

            var booksService = new BooksService(
                _genericBooksRepositoryMock.Object,
                _booksRevisionRepositoryMock.Object);

            var actualBook = await booksService.GetBookByIdAsync(getBook.Id);

            actualBook.Should().Be(getBook);
            _genericBooksRepositoryMock.Verify();
        }

        [Test]
        public async Task GetAllAboutBook_WhenCalled_ShouldReturnBookAndItsRevisions()
        {
            var bookId = Guid.NewGuid();
            var bookRevisions = new List<BookRevision>
            {
                _fixture.Create<BookRevision>(),
                _fixture.Create<BookRevision>()
            };

            var book = bookRevisions.First().Book;
            book.Id = bookId;
            foreach (var item in bookRevisions)
            {
                item.BookId = bookId;
                item.Book = book;
            }

            _booksRevisionRepositoryMock
                .Setup(x => x.GetAllAboutBook(bookId))
                .ReturnsAsync(bookRevisions)
                .Verifiable();

            var expected = new BookDto
            {
                Title = book.Title,
                Author = book.Author,
                BookId = bookId,
                BookRevisions = bookRevisions.Select(
                    br => new BookRevisionDto
                    {
                        LostPrice = br.LostPrice,
                        PagesCount = br.PagesCount,
                        PublishedCount = br.PublishedCount,
                        Year = br.Year
                    })
            };

            var booksService = new BooksService(
               _genericBooksRepositoryMock.Object,
               _booksRevisionRepositoryMock.Object);

            var actual = await booksService
                .GetAllAboutBook(bookId);

            actual.Should().BeEquivalentTo(expected);
            _booksRevisionRepositoryMock.Verify();
        }
    }
}