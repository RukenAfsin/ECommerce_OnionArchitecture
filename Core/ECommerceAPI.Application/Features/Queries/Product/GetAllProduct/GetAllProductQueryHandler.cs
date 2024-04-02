using AutoMapper;
using ECommerceAPI.Application.Abstractions.DTOs.Product;
using ECommerceAPI.Application.Features.Commands.Product.UpdateProduct;
using ECommerceAPI.Application.Features.Queries.Product.GetAllProduct;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.RequestParameters;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly ILogger<UpdateProductCommandHandler> _logger;
        readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, ILogger<UpdateProductCommandHandler> logger, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Gets all products");
            var totalProductCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(p => _mapper.Map<GetAllProductDTO>(p))
                .ToList();

            return new GetAllProductQueryResponse
            {
                Products = products,
                TotalProductCount = totalProductCount
            };
        }

    }
}
