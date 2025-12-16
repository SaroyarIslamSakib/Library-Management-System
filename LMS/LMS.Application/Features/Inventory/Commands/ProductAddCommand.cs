using Cortex.Mediator.Commands;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Inventory.Commands
{
    public class ProductAddCommand : ICommand<Product>
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
