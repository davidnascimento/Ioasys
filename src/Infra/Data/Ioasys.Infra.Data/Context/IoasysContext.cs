using System;
using System.Collections.Generic;
using System.Text;
using Ioasys.Domain.Entities;
using Ioasys.Domain.Entities.Enterprise;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.Infra.Data.Context
{
    public class IoasysContext : BaseContext
    {
        public IoasysContext() : base()
        {
        }

        public DbSet<Enterprise> Enterprises { get; set; }
        public DbSet<EnterpriseType> EnterpriseTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(IoasysContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
