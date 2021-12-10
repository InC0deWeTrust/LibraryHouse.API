using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LibraryHouse.Application.Auth;
using LibraryHouse.Application.Roles;
using LibraryHouse.Application.Users;
using LibraryHouse.Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryHouse.Application.DI
{
    public static class DependencyInjection
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.RegisterInfrastructureServices();
        }
    }
}
