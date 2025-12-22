using Cortex.Mediator.Queries;
using LMS.Domain;
using LMS.Domain.Entities;
using LMS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Inventory.Queries
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, (IList<Product>, int total, int totalDisplay)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        public GetProductsQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<Product>, int total, int totalDisplay)> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProductRepository.GetPagedProductsAsync(query.PageIndex,query.PageSize,query.SearchText,query.SortOrder);
        }
    }
}
