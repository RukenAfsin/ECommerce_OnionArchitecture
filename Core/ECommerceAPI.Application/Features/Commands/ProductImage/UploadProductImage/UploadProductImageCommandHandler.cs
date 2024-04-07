using AutoMapper;
using ECommerceAPI.Application.Abstractions.DTOs.ProductImage;
using ECommerceAPI.Application.Constants;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.ProductImage;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Infrastructure.Utilities.Helpers.FileHelper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using p = ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
         readonly IFileHelper _fileHelper;
         readonly IProductReadRepository _productReadRepository;
         readonly IProductImageWriteRepository _productImageWriteRepository;
         readonly IMapper _mapper;

        public UploadProductImageCommandHandler(IProductReadRepository productReadRepository, IFileHelper fileHelper, IProductImageWriteRepository productImageWriteRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _fileHelper = fileHelper;
            _productImageWriteRepository = productImageWriteRepository;
            _mapper = mapper;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                return new UploadProductImageCommandResponse { ErrorMessage = "Invalid product ID" };
            }

            // Dosyayı yüklerken ProductId alanını da belirtmek gerekir
            if (request.File == null)
            {
                return new UploadProductImageCommandResponse { ErrorMessage = "File is required" };
            }

            string imagePath = await _fileHelper.UploadAsync(request.File, PathConstants.ImagesPath);
            if (imagePath == null)
            {
                return new UploadProductImageCommandResponse { ErrorMessage = "Failed to upload image" };
            }

            p.Product product = await _productReadRepository.GetByIdAsync(request.Id.ToString());
            if (product == null)
            {
                return new UploadProductImageCommandResponse { ErrorMessage = "Product not found" };
            }

            var productImage = new p.ProductImage
            {
                ImagePath = imagePath,
                CreatedDate = DateTime.Now,
                // ProductId alanını isteğin Id değeriyle ayarla
                ProductId = request.Id
            };

            await _productImageWriteRepository.AddAsync(productImage);
            await _productImageWriteRepository.SaveAsync();

            var productImageDto = _mapper.Map<CreateProductImageDTO>(productImage);

            return new UploadProductImageCommandResponse { ProductImage = productImageDto };
        }


    }
}
