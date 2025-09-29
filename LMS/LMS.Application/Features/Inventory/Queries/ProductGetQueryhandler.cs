using Cortex.Mediator.Queries;
using LMS.Domain;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Inventory.Queries
{
    public class ProductGetQueryhandler : IQueryHandler<ProductGetQuery, Product>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public ProductGetQueryhandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> Handle(ProductGetQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(query.Id);
        }
    }
}
