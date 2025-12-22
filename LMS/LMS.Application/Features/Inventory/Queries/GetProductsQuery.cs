using Cortex.Mediator.Queries;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Inventory.Queries
{
    public class GetProductsQuery : IQuery<(IList<Product>, int total,int totalDisplay)>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? SearchText { get; set; }
        public string? SortOrder { get; set; }
    }
}
