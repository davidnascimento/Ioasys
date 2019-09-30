using System;
using System.Collections.Generic;
using System.Text;
using Ioasys.Application.ViewModels;

namespace Ioasys.Application.Interfaces
{
    public interface IEnterpriseAppService : IDisposable
    {
        IEnumerable<EnterpriseViewModel> GetAllEnterprises();
        EnterpriseViewModel GetEnterpriseById(int id);
        IEnumerable<EnterpriseViewModel> GetEnterprisesByNameAndType(string name, int enterpriseTypeId);
    }
}
