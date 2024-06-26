﻿using ECommerceAPI.Application.Features.SomeFeatures.Rules;
using ECommerceAPI.Application.Repositories;
using MediatR;
using x = ECommerceAPI.Domain.Entities;
using AutoMapper;
using ECommerceAPI.Application.Abstractions.DTOs.Product;
using ECommerceAPI.Application.Abstractions.Hubs;


namespace ECommerceAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly ProductBusinessRules _productBusinessRules;
        readonly IProductHubService _productHubService;
        readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, ProductBusinessRules productBusinessRules, IMapper mapper, IProductHubService productHubService)
        {
            _productWriteRepository = productWriteRepository;
            _productBusinessRules = productBusinessRules;
            _mapper = mapper;
            _productHubService = productHubService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productBusinessRules.ProductNameCanNotBeDuplicated(request.Name);


            x.Product product = _mapper.Map<x.Product>(request);
            bool isSuccess = await _productWriteRepository.AddAsync(product);

            CreateProductDTO createdProductDto = _mapper.Map<CreateProductDTO>(product);
          
            await _productWriteRepository.SaveAsync();
            await  _productHubService.ProductAddedMessageAsync($" {request.Name} product added ");
            return new CreateProductCommandResponse
            {
                Product = createdProductDto
            };
        }

    }
}
