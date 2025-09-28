using LMS.Domain;
using LMS.Domain.Repositories;
using LMS.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
        }
    }
}
