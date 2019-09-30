using AutoMapper;
using Ioasys.Application.ViewModels;
using Ioasys.Domain.Entities.Enterprise;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ioasys.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<EnterpriseType, EnterpriseTypeViewModel>()
                .ForMember(it => it.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(it => it.enterprise_type_name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Enterprise, EnterpriseViewModel>()
                .ForMember(it => it.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(it => it.email_enterprise, opt => opt.MapFrom(src => src.Email))
                .ForMember(it => it.facebook, opt => opt.MapFrom(src => src.Facebook))
                .ForMember(it => it.twitter, opt => opt.MapFrom(src => src.Twitter))
                .ForMember(it => it.linkedin, opt => opt.MapFrom(src => src.Linkedin))
                .ForMember(it => it.phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(it => it.own_enterprise, opt => opt.MapFrom(src => src.Own))
                .ForMember(it => it.enterprise_name, opt => opt.MapFrom(src => src.Name))
                .ForMember(it => it.photo, opt => opt.MapFrom(src => src.Photo))
                .ForMember(it => it.description, opt => opt.MapFrom(src => src.Description))
                .ForMember(it => it.city, opt => opt.MapFrom(src => src.City))
                .ForMember(it => it.country, opt => opt.MapFrom(src => src.Country))
                .ForMember(it => it.value, opt => opt.MapFrom(src => src.Value))
                .ForMember(it => it.share_price, opt => opt.MapFrom(src => src.SharePrice))
                .ForMember(it => it.enterprise_type, opt => opt.MapFrom(src => Mapper.Map<EnterpriseType>(src.EnterpriseType)));
        }
    }
}