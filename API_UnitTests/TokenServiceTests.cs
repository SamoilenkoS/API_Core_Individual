using API_Core_BL.Services.TokenService;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace API_UnitTests
{
    public class TokenServiceTests
    {
        private Fixture _fixture;
        private Mock<ITokenService> _tokenServiceMock;

        public TokenServiceTests()
        {
            _fixture = new Fixture();
            _tokenServiceMock = new Mock<ITokenService>();
        }

        [Test]
        public void GenerateToken_WhenValidPassed_ShouldGenerateToken()
        {
            var username = _fixture.Create<string>();
            var role = _fixture.Create<string>();
            var token = _fixture.Create<string>();
            _tokenServiceMock
                .Setup(x => x.GenerateToken(username, role))
                .Returns(token)
                .Verifiable();

            string generateToken = _tokenServiceMock.GenerateToken(username, role);

            generateToken.Should().Be(token);
            _tokenServiceMock.Verify();
        }
    }
}