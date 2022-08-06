using API_Core_BL.Services.PasswordSecurityService;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace API_UnitTests
{
    public class PasswordServiceTests
    {
        private Fixture _fixture;
        private Mock<IPasswordService> _passwordServiceMock;

        public PasswordServiceTests()
        {
            _fixture = new Fixture();
            _passwordServiceMock = new Mock<IPasswordService>();
        }

        [Test]
        public void GenerateSalted_WhenValidPassed_ShouldGenerateSalted()
        {
            var salt = _fixture.Create<string>();
            _passwordServiceMock
                .Setup(x => x.GenerateSalted())
                .Returns(salt)
                .Verifiable();

            var passwordService = new PasswordService();

            var actualSalt = passwordService.GenerateSalted();

            actualSalt.Should().Be(salt);
            _passwordServiceMock.Verify();
        }

        [Test]
        public void PasswordHashing_WhenValidPassed_ShouldPasswordHashing()
        {
            var clientPassword = _fixture.Create<string>();
            var salt = _fixture.Create<string>();
            var hashedPassword = _fixture.Create<string>();
            _passwordServiceMock
                .Setup(x => x.PasswordHashing(clientPassword, salt))
                .Returns(hashedPassword)
                .Verifiable();

            var passwordService = new PasswordService();

            var actualPassword = passwordService.PasswordHashing(clientPassword, salt);

            actualPassword.Should().Be(hashedPassword);
            _passwordServiceMock.Verify();
        }

        //[Test]
        //public void ValidatePassword_WhenValidPassed_ShouldValidatePassword()
        //{
        //    var enteredPassword = _fixture.Create<string>();
        //    var savedSalt = _fixture.Create<string>();
        //    var savedPassword = _fixture.Create<string>();
        //    _passwordServiceMock
        //        .Setup(x => x.ValidatePassword(
        //            enteredPassword,
        //            savedPassword,
        //            savedSalt))
        //        .Returns(true)
        //        .Verifiable();

        //    var validateBool = false;
        //    validateBool = _passwordServiceMock.ValidatePassword(enteredPassword, savedPassword, savedSalt);

        //    validateBool.Should().Be(true);
        //    _passwordServiceMock.Verify();
        //}
    }
}