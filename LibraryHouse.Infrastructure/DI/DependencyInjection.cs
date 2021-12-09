using System;
using System.Collections.Generic;
using System.Text;
using LibraryHouse.Infrastructure.GenericRepository;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryHouse.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
