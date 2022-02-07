using AutoMapper;
using OnionArchitectureDemo.Application.Features.Commands.CreateProduct;
using OnionArchitectureDemo.Application.Features.Queries.GetProductById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitectureDemo.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product, Dto.ProductViewDto>().ReverseMap();

            CreateMap<Domain.Entities.Product, CreateProductCommand>().ReverseMap();

            CreateMap<Domain.Entities.Product, GetProductByIdViewModel>().ReverseMap();
        }
    }
}
