using AutoMapper;
using MediatR;
using OnionArchitectureDemo.Application.Interfaces.Repository;
using OnionArchitectureDemo.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitectureDemo.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Entities.Product>(request);
                await _productRepository.AddAsync(product);
                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
