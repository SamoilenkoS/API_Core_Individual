using API_Core_BL.Services.PasswordSecurityService;
using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace API_UnitTests
{
    public class PasswordServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Pass123", "CJZwnMlpqN3Q9elgDkqdlQ==", "G7+Zl0JjprruZEVsOyWBDd+e9Wo1W3Hl")]
        public void PasswordHashing_WhenValidPassed_ShouldPasswordHashing(
           string clientPassword, string salt, string hashedPassword)
        {
            var passwordService = new PasswordService();
            var actualPassword = passwordService.PasswordHashing(clientPassword, salt);
            Assert.AreEqual(hashedPassword, actualPassword);
        }


        [TestCase("Pass123", "CJZwnMlpqN3Q9elgDkqdlQ==", "G7+Zl0JjprruZEVsOyWBDd+e9Wo1W3Hl", true)]
        [TestCase("Pass124", "CJZwnMlpqN3Q9elgDkqdlQ==", "G7+Zl0JjprruZEVsOyWBDd+e9Wo1W3Hl", false)]
        public void ValidatePassword_WhenValidPassed_ShouldValidatePassword(
            string enteredPassword, string salt, string savedPassword, bool expectedValidate)
        {
            var passwordService = new PasswordService();
            var actualValidate = passwordService.ValidatePassword(
                enteredPassword, savedPassword, salt);
            Assert.AreEqual(expectedValidate, actualValidate);
        }
    }
}