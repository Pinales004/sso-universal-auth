using API_BASE.Application.Interfaces.Servicios;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios
{
    public class HashService : IHashService
    {
        public string HashPassword(string password, out string salt)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
            salt = Convert.ToBase64String(saltBytes);
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password, saltBytes, KeyDerivationPrf.HMACSHA256, 10000, 32));
            return hash;
        }

        public bool VerifyPassword(string password, string hash, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var testHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password, saltBytes, KeyDerivationPrf.HMACSHA256, 10000, 32));
            return hash == testHash;
        }
    }
}