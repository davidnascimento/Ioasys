using System;
using System.Collections.Generic;
using System.Text;
using Ioasys.Domain.Entities.Enterprise;
using Ioasys.Domain.Interfaces.Repository;
using Ioasys.Infra.Data.Context;

namespace Ioasys.Infra.Data.Repositories
{
    public class EnterpriseRepository : RepositoryBase<Enterprise>, IEnterpriseRepository
    {
        private IoasysContext _context;

        public EnterpriseRepository(IoasysContext context) : base(context)
        {
            _context = context;
        }
    }
}
