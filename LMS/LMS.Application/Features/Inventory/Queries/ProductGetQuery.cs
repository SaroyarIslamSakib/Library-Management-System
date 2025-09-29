using Cortex.Mediator.Queries;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Inventory.Queries
{
    public class ProductGetQuery : IQuery<Product>
    {
        public Guid Id { get; set; }
    }
}
