using LMS.Domain;
using LMS.Domain.Repositories;
using LMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IProductRepository ProductRepository { get; private set; }

        public ApplicationUnitOfWork(ApplicationDbContext context, IProductRepository productRepository)
            : base(context)
        {
            ProductRepository = productRepository;
        }
    }

}
