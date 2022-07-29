namespace API_Core_BL.Services.PasswordSecurityService
{
    public interface IPasswordService
    { 
        string GenerateSalted();
        string PasswordHashing(string password, string salt);
        bool ValidatePassword(string enteredPassword, string savedPassword, string savedSalt);

    }
}
