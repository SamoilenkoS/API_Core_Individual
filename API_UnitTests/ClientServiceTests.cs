using API_Core_BL.DTOs;
using API_Core_BL.Services.ClientService;
using API_Core_BL.Services.PasswordSecurityService;
using API_Core_BL.Services.TokenService;
using API_Core_DAL;
using API_Core_DAL.Entities;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_UnitTests
{
    public class ClientServiceTests
    {
        private Fixture _fixture;
        private Mock<IGenericRepository<Client>> _genericClientRepositoryMock;
        private Mock<ITokenService> _tokenServiceMock;
        private Mock<IPasswordService> _passwordServiceMock;
        private Mock<IConfiguration> _configuration;
        private readonly string _salt;

        public ClientServiceTests()
        {
            _fixture = new Fixture();
            _genericClientRepositoryMock = new Mock<IGenericRepository<Client>>();
            _tokenServiceMock = new Mock<ITokenService>();
            _passwordServiceMock = new Mock<IPasswordService>();
            _configuration = new Mock<IConfiguration>();
            _salt = "CJZwnMlpqN3Q9elgDkqdlQ==";
        }

        [Test]
        public async Task AddClientAsync_WhenValidUserPassed_ShouldRegisterUser()
        {
            var _client = _fixture.Create<Client>();
            _client.Password = "Pass123";
            var hashedPassword = "G7+Zl0JjprruZEVsOyWBDd+e9Wo1W3Hl";
            var clientGuid = Guid.NewGuid();
            _passwordServiceMock
                .Setup(x => x.PasswordHashing(_client.Password, _salt))
                .Returns(hashedPassword)
                .Verifiable();

            _client.Password = hashedPassword;
            _genericClientRepositoryMock
                .Setup(repository =>
                    repository.AddAsync(
                        It.Is<Client>(client =>
                            client.BirthDate == _client.BirthDate &&
                            client.Email == _client.Email &&
                            client.FirstName == _client.FirstName &&
                            client.LastName == _client.LastName &&
                            client.Password == hashedPassword)))
                .ReturnsAsync(clientGuid)
                .Verifiable();
           var clientService = new ClientService(
                _genericClientRepositoryMock.Object,
                _tokenServiceMock.Object,
                _passwordServiceMock.Object, _configuration.Object);

            var actualClientGuid = await clientService.AddClientAsync(_client);

            actualClientGuid.Should().Be(clientGuid);
            _passwordServiceMock.Verify();
            _genericClientRepositoryMock.Verify();
        }

        [Test]
        public async Task DeleteClientAsync_WhenCalled_ShouldDeleteClientFromRepository()
        {
            var client = _fixture.Create<Client>();

            _genericClientRepositoryMock
                .Setup(repository =>
                    repository.DeleteAsync(client.Id))
                .ReturnsAsync(true)
                .Verifiable();
            var clientService = new ClientService(
                 _genericClientRepositoryMock.Object,
                 _tokenServiceMock.Object,
                 _passwordServiceMock.Object, _configuration.Object);

            bool deleteClientBool = false;
            deleteClientBool = await clientService.DeleteClientAsync(client.Id);

            deleteClientBool.Should().Be(true);
            _genericClientRepositoryMock.Verify();
        }

        [Test]
        public async Task UpdateClientAsync_WhenCalled_ShouldUpdateClientInRepository()
        {
            var updateClient = _fixture.Create<Client>();

            _genericClientRepositoryMock
                .Setup(repository =>
                    repository.UpdateAsync(It.Is<Client>(client =>
                            client.BirthDate == updateClient.BirthDate &&
                            client.Email == updateClient.Email &&
                            client.FirstName == updateClient.FirstName &&
                            client.LastName == updateClient.LastName &&
                            client.Password == updateClient.Password)))
                .ReturnsAsync(true)
                .Verifiable();
            var clientService = new ClientService(
                 _genericClientRepositoryMock.Object,
                 _tokenServiceMock.Object,
                 _passwordServiceMock.Object, _configuration.Object);

            bool updateClientBool = false;
            updateClientBool = await clientService.UpdateClientAsync(updateClient);

            updateClientBool.Should().Be(true);
            _genericClientRepositoryMock.Verify();
        }

        [Test]
        public async Task GetAllClientsAsync_WhenCalled_ShouldGetDataFromRepository()
        {
            var clientsRepositoryResponse = new List<Client>
            {
                _fixture.Create<Client>(),
                _fixture.Create<Client>(),
                _fixture.Create<Client>()
            };

            _genericClientRepositoryMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(clientsRepositoryResponse)
                .Verifiable();
            var clientService = new ClientService(
                 _genericClientRepositoryMock.Object,
                 _tokenServiceMock.Object,
                 _passwordServiceMock.Object, _configuration.Object);

            var actulClients = await clientService.GetAllClientsAsync();

            CollectionAssert.AreEqual(clientsRepositoryResponse, actulClients);
            _genericClientRepositoryMock.Verify();
        }

        [Test]
        public async Task LoginAsync_WhenValidLoginPassed_ShouldLoginUser()
        {
            var clientLogin = _fixture.Create<Client>();
            var token = _fixture.Create<string>();
            clientLogin.Password = "Pass123";
            var hashedPassword = "G7+Zl0JjprruZEVsOyWBDd+e9Wo1W3Hl";
            var clientGuid = Guid.NewGuid();

            var loginDto = new LoginDto()
            {
                Email = clientLogin.Email,
                Password = clientLogin.Password
            };

            _genericClientRepositoryMock
                .Setup(repository =>
                    repository.GetByPredicateEnumerable(x =>
                        x.Email == loginDto.Email))
                .ReturnsAsync(new List<Client> { clientLogin })
                .Verifiable();
            _passwordServiceMock.Setup(ps => ps.ValidatePassword(
                loginDto.Password, clientLogin.Password, _salt))
                .Returns(true)
                .Verifiable();
            _tokenServiceMock
                .Setup(ts => ts.GenerateToken(clientLogin.Email, "Reader"))
                .Returns(token);
            var clientService = new ClientService(
                 _genericClientRepositoryMock.Object,
                 _tokenServiceMock.Object,
                 _passwordServiceMock.Object, _configuration.Object);

            var actualClientToken = await clientService.LoginAsync(loginDto);

            actualClientToken.Should().Be(token);
            _passwordServiceMock.Verify();
            _genericClientRepositoryMock.Verify();
        }

        [Test]
        public async Task GetClientByIdAsync_WhenCalled_ShouldGetClientByIdFromRepository()
        {
            var getClient = _fixture.Create<Client>();

            _genericClientRepositoryMock
                .Setup(repository => repository.GetByIdAsync(getClient.Id))
                .ReturnsAsync(getClient)
                .Verifiable();

            var clientService = new ClientService(
                 _genericClientRepositoryMock.Object,
                 _tokenServiceMock.Object,
                 _passwordServiceMock.Object, _configuration.Object);

            var actualClient = await clientService.GetClientByIdAsync(getClient.Id);

            actualClient.Should().Be(getClient);
            _genericClientRepositoryMock.Verify();
        }
    }
}
