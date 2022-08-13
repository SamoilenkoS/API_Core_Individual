using System;
using System.Text;
using System.Security.Cryptography;

namespace API_Core_BL.Services.PasswordSecurityService
{
    public class PasswordService : IPasswordService
    {

        public string PasswordHashing(string password, string salt)
        {
            byte[] saltBytes = Encoding.ASCII.GetBytes(salt);
            var byteResult = new Rfc2898DeriveBytes(password, saltBytes, 10000);

            return Convert.ToBase64String(byteResult.GetBytes(24));
        }

        public bool ValidatePassword(string enteredPassword, string savedPassword, string savedSalt)
        {
            string hashedPassword = PasswordHashing(enteredPassword, savedSalt);
            if (hashedPassword == savedPassword)
            {
                return true;
            }

            return false;
        }
    }
}
