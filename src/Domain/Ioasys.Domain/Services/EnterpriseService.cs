using System;
using System.Collections.Generic;
using System.Text;
using Ioasys.Domain.Entities.Enterprise;
using Ioasys.Domain.Interfaces.Repository;

namespace Ioasys.Domain.Services
{
    public class EnterpriseService : ServiceBase<Enterprise>, IEnterpriseService
    {
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseService(IEnterpriseRepository enterpriseRepository)
            : base (enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }
    }
}
