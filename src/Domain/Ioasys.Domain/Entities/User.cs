using Ioasys.Domain.Entities.Enterprise;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public int? InvestorId { get; set; }
        public virtual Investor Investor { get; set; }

        public int? EnterpriseId { get; set; }
        public virtual Enterprise.Enterprise Enterprise { get; set; }
    }
}
