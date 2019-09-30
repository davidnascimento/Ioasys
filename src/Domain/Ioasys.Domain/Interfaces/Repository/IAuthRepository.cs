using Ioasys.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Domain.Interfaces.Repository
{
    public interface IAuthRepository : IDisposable
    {
        User GetUserByEmail(string email);
        bool ValidatePassword(string email, string plainTextPassword);
    }
}
