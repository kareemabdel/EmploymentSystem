using System;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace EmploymentSystem.Api.Helpers
{
    public static class CryptoHelper
    {
        public static string Encrypt(string password, string key)
        {
            // Use it for generate key
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            //var salt0 = new byte[128 / 8];
            //using (var rngCsp = new RNGCryptoServiceProvider())
            //{
            //    rngCsp.GetNonZeroBytes(salt0);
            //}
            //var key = Convert.ToBase64String(salt0);

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            var salt = Encoding.UTF8.GetBytes(key);
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                100000,
                256 / 8));

            return hashed;
        }

    }
}
