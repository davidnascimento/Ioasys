using System;
using System.Collections.Generic;
using System.Text;
using Ioasys.Domain.Services;
using Ioasys.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Ioasys.Domain.Interfaces.Repository;
using Ioasys.Infra.Data.Repositories;
using AutoMapper;
using Ioasys.Application.Services;
using Ioasys.Application.Interfaces;

namespace Ioasys.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton<IUserToken, UserResolverService>();

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IEnterpriseAppService, EnterpriseAppService>();

            // Infra - Authorization
            //services.AddScoped<IAuthRepository, AuthRepository>();

            // Infra - Data
            services.AddScoped<IoasysContext>();
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            //Domain
            services.AddScoped<IEnterpriseService, EnterpriseService>();
        }
    }
}
