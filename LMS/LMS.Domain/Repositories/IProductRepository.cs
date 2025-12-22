using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product, Guid>  
    {
        Task<(IList<Product>, int total, int totalDisplay)> GetPagedProductsAsync(int pageIndex, int pageSize, string? searchText, string? sortOrder);
    }
}
