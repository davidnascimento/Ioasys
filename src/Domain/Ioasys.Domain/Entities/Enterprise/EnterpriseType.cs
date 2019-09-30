using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Domain.Entities.Enterprise
{
    public class EnterpriseType : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Enterprise> Enterprises { get; private set; }
    }
}
