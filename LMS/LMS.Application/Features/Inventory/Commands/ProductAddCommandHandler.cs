using Cortex.Mediator.Commands;
using LMS.Domain;
using LMS.Domain.Entities;
using LMS.Domain.Utilities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Features.Inventory.Commands
{
    public class ProductAddCommandHandler : ICommandHandler<ProductAddCommand, Product>
    {

        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductAddCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Product> Handle(ProductAddCommand command, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(command);
            product.Id = IdentityGenerator.NewSequentialGuid();

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();

            return product;
        }
    }
}
