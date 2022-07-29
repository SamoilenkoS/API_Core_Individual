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