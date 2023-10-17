using System.Security.Cryptography;
using System.Text;

namespace GameStoreBeGNorbi.Services
{
    public class PasswordHasher
    {
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public string HashPassword(string password, string salt)
        {
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                Encoding.UTF8.GetBytes(salt),
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        public static string GenerateSalt()
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);
            return Convert.ToHexString(salt);
        }
    }
}
