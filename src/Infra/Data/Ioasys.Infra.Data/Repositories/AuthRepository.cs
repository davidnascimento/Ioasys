using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ioasys.Domain.Entities;
using Ioasys.Domain.Interfaces.Repository;
using Ioasys.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.Infra.Data.Repositories
{
    public class AuthRepository : RepositoryBase<User>, IAuthRepository
    {
        private IoasysContext _context;
        public AuthRepository(IoasysContext context) : base(context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return _context.Users.Where(it => it.Email.ToLower().Equals(email.ToLower()))
                                 .Include(it => it.Investor)
                                 .Include(it => it.Enterprise).FirstOrDefault();
        }

        public bool ValidatePassword(string email, string plainTextPassword)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(plainTextPassword))
                return false;

            return _context.Users.Any(it => it.Email.ToLower().Equals(email.ToLower())
                                            && it.Password.Equals(plainTextPassword));
        }
    }
}
