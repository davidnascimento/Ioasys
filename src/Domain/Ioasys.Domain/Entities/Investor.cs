using System;
using System.Collections.Generic;
using System.Text;
using Ioasys.Domain.Entities.Enterprise;

namespace Ioasys.Domain.Entities
{
    public class Investor : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float Balance { get; set; }
        public string Photo { get; set; }
        public float PortfolioValue { get; set; }
        public bool FirstAccess { get; set; }
        public bool SuperAngel { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

