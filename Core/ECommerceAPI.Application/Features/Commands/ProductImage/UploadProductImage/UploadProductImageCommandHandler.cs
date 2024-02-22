using ECommerceAPI.Application.Constants;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.ProductImage;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Infrastructure.Utilities.Helpers.FileHelper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p = ECommerceAPI.Domain.Entities;


namespace ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        readonly IFileHelper _fileHelper;
        readonly IProductReadRepository _productReadRepository;
        readonly IProductImageWriteRepository _productImageWriteRepository;

        public UploadProductImageCommandHandler(IProductReadRepository productReadRepository, IFileHelper fileHelper, IProductImageWriteRepository productImageWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _fileHelper = fileHelper;
            _productImageWriteRepository = productImageWriteRepository;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id))
            {
                return new UploadProductImageCommandResponse();
            }

            string imagePath = await _fileHelper.UploadAsync(request.File, PathConstants.ImagesPath);
            if (imagePath == null)
            {
                return new UploadProductImageCommandResponse();
            }

            p.Product product = await _productReadRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                return new UploadProductImageCommandResponse();
            }
            var productImage = new Domain.Entities.ProductImage
            {
                ImagePath = imagePath,
                CreatedDate = DateTime.Now
            };

            await _productImageWriteRepository.AddAsync(productImage);
            await _productImageWriteRepository.SaveAsync();

            return new UploadProductImageCommandResponse();
        }
    }
}
