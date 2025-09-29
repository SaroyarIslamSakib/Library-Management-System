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
    public class ProductGetAllQueryHandler : IQueryHandler<ProductGetAllQuery, IList<Product>>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public ProductGetAllQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IList<Product>> Handle(ProductGetAllQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }
    }
}
