using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Domain.Entities.Enterprise
{
    public class Enterprise : Entity
    {
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string Phone { get; set; }
        public bool Own { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Value { get; set; }
        public float SharePrice { get; set; }
        public int EnterpriseTypeId { get; set; }
        public virtual EnterpriseType EnterpriseType { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
