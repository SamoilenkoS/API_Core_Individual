using API_Core_BL.Services.ClientService;
using API_Core_BL.Services.PasswordSecurityService;
using API_Core_BL.Services.TokenService;
using API_Core_DAL;
using API_Core_DAL.Entities;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_UnitTests
{
    public class ClientServiceTests
    {
        private Fixture _fixture;
        private Mock<IGenericRepository<Client>> _genericClientRepositoryMock;
        private Mock<ITokenService> _tokenServiceMock;
        private Mock<IPasswordService> _passwordServiceMock;

        public ClientServiceTests()
        {
            _fixture = new Fixture();
            _genericClientRepositoryMock = new Mock<IGenericRepository<Client>>();
            _tokenServiceMock = new Mock<ITokenService>();
            _passwordServiceMock = new Mock<IPasswordService>();
        }

        [Test]
        public async Task AddClientAsync_WhenValidUserPassed_ShouldRegisterUser()
        {
            var _client = _fixture.Create<Client>();
            var salt = _fixture.Create<string>();
            var hashedPassword = _fixture.Create<string>();
            var clientGuid = Guid.NewGuid();
            _passwordServiceMock
                .Setup(x => x.GenerateSalted())
                .Returns(salt)
                .Verifiable();
            _passwordServiceMock
                .Setup(x => x.PasswordHashing(_client.Password, salt))
                .Returns(hashedPassword)
                .Verifiable();
            _genericClientRepositoryMock
                .Setup(repository =>
                    repository.AddAsync(
                        It.Is<Client>(client =>
                            client.BirthDate == client.BirthDate &&
                            client.Email == client.Email &&
                            client.FirstName == client.FirstName &&
                            client.LastName == client.LastName &&
                            client.Password == hashedPassword &&
                            client.Salt == salt)))
                .ReturnsAsync(clientGuid)
                .Verifiable();
           var clientService = new ClientService(
                _genericClientRepositoryMock.Object,
                _tokenServiceMock.Object,
                _passwordServiceMock.Object);

            var actualClientGuid = await clientService.AddClientAsync(_client);

            actualClientGuid.Should().Be(clientGuid);
            _passwordServiceMock.Verify();
            _genericClientRepositoryMock.Verify();
        }
    }
}
