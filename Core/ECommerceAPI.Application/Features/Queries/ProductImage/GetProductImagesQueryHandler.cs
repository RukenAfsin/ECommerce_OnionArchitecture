using AutoMapper;
using ECommerceAPI.Application.Abstractions.DTOs.ProductImage;
using ECommerceAPI.Application.Repositories.ProductImage;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.ProductImage
{
    public class GetProductImagesQueryHandler : IRequestHandler<GetProductImagesQueryRequest, GetProductImagesQueryResponse>
    {

        readonly IProductImageReadRepository _productImageReadRepository;
        readonly IMapper _mapper;


        public GetProductImagesQueryHandler(IProductImageReadRepository productImageReadRepository, IMapper mapper)
        {
            _productImageReadRepository = productImageReadRepository;
            _mapper = mapper;
        }

        public async Task<GetProductImagesQueryResponse> Handle(GetProductImagesQueryRequest request, CancellationToken cancellationToken)
        {
            var productImage = _productImageReadRepository.GetAll(false)
                .Skip(request.Page*request.Size)
                .Take(request.Size)
                .Select(p => _mapper.Map<GetAllProductImageDTO>(p))
                .ToList();

            return new GetProductImagesQueryResponse
            {
                ProductImage = productImage,
            };
        }
    }
}
