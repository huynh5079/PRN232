using BCrypt;

namespace DataLayer.Utilities
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            // BCrypt generates its own salt
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}