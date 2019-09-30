using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using AutoMapper;
using Ioasys.Application.Interfaces;
using Ioasys.Application.ViewModels;
using Ioasys.Domain.Entities.Enterprise;
using Ioasys.Domain.Services;
using Ioasys.Utility.Extension;

namespace Ioasys.Application.Services
{
    public class EnterpriseAppService : IEnterpriseAppService
    {
        private readonly IEnterpriseService _enterpriseService;

        public EnterpriseAppService(IEnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService;
        }

        public IEnumerable<EnterpriseViewModel> GetAllEnterprises()
        {
            var data = _enterpriseService.GetAll(it => it.EnterpriseType);
            return Mapper.Map<IEnumerable<EnterpriseViewModel>>(data);
        }

        public EnterpriseViewModel GetEnterpriseById(int id)
        {
            var data = _enterpriseService.GetById(id, it => it.EnterpriseType);
            return Mapper.Map<EnterpriseViewModel>(data);
        }

        public IEnumerable<EnterpriseViewModel> GetEnterprisesByNameAndType(string name, int enterpriseTypeId)
        {
            Expression<Func<Enterprise, bool>> predicate = ExpressionExtension.Query<Enterprise>();

            predicate = predicate.And(it => it.EnterpriseType.Id == enterpriseTypeId);

            if (!string.IsNullOrWhiteSpace(name))
                predicate = predicate.And(it => it.Name.ToLower().Contains(name.ToLower()));

            var data = _enterpriseService.Find(predicate, it => it.EnterpriseType);

            return Mapper.Map<IEnumerable<EnterpriseViewModel>>(data);
        }

        public void Dispose()
        {
            _enterpriseService.Dispose();
        }
    }
}
