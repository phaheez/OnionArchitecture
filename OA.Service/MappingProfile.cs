using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OA.DataAccess;
using OA.Service.DTOs.Readonly;
using OA.Service.DTOs.Writeable;

namespace OA.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Writeable
            
            CreateMap<ProductDtow, Product>();

            #endregion


            #region Readonly

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDetails, ProductDetailsDto>();

            #endregion
        }
    }
}
