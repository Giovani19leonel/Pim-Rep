using Extension.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.Core.Extensions
{
    public static class ConfigureDataExtensions
    {
        public static IServiceCollection AddHttpServices(this IServiceCollection services, string connection)
        {
            services.AddDbContext<UserContext>(x =>
            {
                x.UseSqlServer(connection);
            });

            return services;
        }
    }
}
