using ECommerceAPI.Application.Constants;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.Repositories.ProductImage;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Infrastructure.Utilities.Helpers.FileHelper;
using ETicaretAPI.Application.Repositories;
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
            string imagePath = await _fileHelper.UploadAsync(request.File, PathConstants.ImagesPath);
            if (string.IsNullOrEmpty(request.Id))
            {
                // Hata işleme mekanizması - Geçersiz istek durumu
                return new UploadProductImageCommandResponse { ErrorMessage = "Geçersiz istek. Ürün ID'si belirtilmemiş." };
            }

            p.Product product = await _productReadRepository.GetByIdAsync(request.Id);

            if (imagePath != null)
            {
                await _productImageWriteRepository.AddRangeAsync(new List<Domain.Entities.ProductImage>
        {
            new Domain.Entities.ProductImage
            {
                ImagePath = imagePath,
                CreatedDate = DateTime.Now
            }
        });

                await _productImageWriteRepository.SaveAsync();
            }

            return new UploadProductImageCommandResponse();

        }
    }
}
