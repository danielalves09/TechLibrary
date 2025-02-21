﻿using TechLibrary.Api.Domain.Entities;

namespace TechLibrary.Api.Infraestructure.Security.Cryptography
{
    public class BcryptAlgorithm
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool VerifyPassword(string password, User user)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
    }
}
