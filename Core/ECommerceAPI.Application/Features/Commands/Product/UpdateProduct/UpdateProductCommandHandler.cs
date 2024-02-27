using AutoMapper;
using ECommerceAPI.Application.Abstractions.DTOs.Product;
using ECommerceAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IMapper _mapper;
        readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
            _logger = logger;
        }

        //public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        //{
        //    p.Product product = await _productReadRepository.GetByIdAsync(request.Id);
        //    product.Stock = request.Stock;
        //    product.Price = request.Price;
        //    product.Name = request.Name;
        //    await _productWriteRepository.SaveAsync();
        //    return new();
        //}
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            p.Product product = _mapper.Map<p.Product>(request);
            bool IsSuccess =  _productWriteRepository.Update(product);
            UpdateProductDTO updatedProduct = _mapper.Map<UpdateProductDTO>(product);
            await _productWriteRepository.SaveAsync();
            _logger.LogInformation("Product updated");

            return new UpdateProductCommandResponse
            {
                Product = updatedProduct
            };
        }
    }
}
