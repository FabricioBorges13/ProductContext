using AutoMapper;
using ProductContext.Application.Features.Products.Commands;
using ProductContext.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Application.Features.Products.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ProductAddCommand, Product>()
                .ForMember(x => x.Description, c => c.MapFrom(y => y.Description))
                .ForMember(x => x.DescriptionProvider, c => c.MapFrom(y => y.DescriptionProvider))
                .ForMember(x => x.DueDate, c => c.MapFrom(y => y.DueDate))
                .ForMember(x => x.ManufacturingDate, c=> c.MapFrom(y => y.ManufacturingDate))
                .ForMember(x => x.IdProvider, c => c.MapFrom(y => y.IdProvider))
                .ForMember(x => x.CNPJProvider, c => c.MapFrom(y => y.CNPJProvider));

            CreateMap<ProductUpdateCommand, Product>()
               .ForMember(x => x.Id, c => c.MapFrom(y => y.Id))
               .ForMember(x => x.Description, c => c.MapFrom(y => y.Description))
               .ForMember(x => x.DescriptionProvider, c => c.MapFrom(y => y.DescriptionProvider))
               .ForMember(x => x.DueDate, c => c.MapFrom(y => y.DueDate))
               .ForMember(x => x.ManufacturingDate, c => c.MapFrom(y => y.ManufacturingDate))
               .ForMember(x => x.IdProvider, c => c.MapFrom(y => y.IdProvider))
               .ForMember(x => x.CNPJProvider, c => c.MapFrom(y => y.CNPJProvider));
        }
    }
}
