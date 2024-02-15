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
            if (string.IsNullOrEmpty(request.Id))
            {
                // Hata işleme mekanizması - Geçersiz istek durumu
                return new UploadProductImageCommandResponse();
            }

            string imagePath = await _fileHelper.UploadAsync(request.File, PathConstants.ImagesPath);
            if (imagePath == null)
            {
                // Hata işleme mekanizması - Resim yükleme başarısız
                return new UploadProductImageCommandResponse();
            }

            p.Product product = await _productReadRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                // Hata işleme mekanizması - Belirtilen ID'ye sahip ürün bulunamadı
                return new UploadProductImageCommandResponse();
            }

            // Yeni ürün resminin oluşturulması ve veritabanına eklenmesi
            var productImage = new Domain.Entities.ProductImage
            {
                ImagePath = imagePath,
                CreatedDate = DateTime.Now
            };

            await _productImageWriteRepository.AddAsync(productImage);
            await _productImageWriteRepository.SaveAsync();

            return new UploadProductImageCommandResponse();
        }

        //public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        //{
        //    if (string.IsNullOrEmpty(request.Id))
        //    {
        //        // Hata işleme mekanizması - Geçersiz istek durumu
        //        return new UploadProductImageCommandResponse();
        //    }

        //    if (request.Files == null || request.Files.Count == 0)
        //    {
        //        // Hata işleme mekanizması - Yüklenen dosya yok
        //        return new UploadProductImageCommandResponse();
        //    }

        //    foreach (var file in request.Files)
        //    {
        //        string imagePath = await _fileHelper.UploadAsync(file, PathConstants.ImagesPath);
        //        if (imagePath == null)
        //        {
        //            // Hata işleme mekanizması - Resim yükleme başarısız
        //            return new UploadProductImageCommandResponse();
        //        }

        //        p.Product product = await _productReadRepository.GetByIdAsync(request.Id);
        //        if (product == null)
        //        {
        //            // Hata işleme mekanizması - Belirtilen ID'ye sahip ürün bulunamadı
        //            return new UploadProductImageCommandResponse();
        //        }

        //        // Yeni ürün resminin oluşturulması ve veritabanına eklenmesi
        //        var productImage = new Domain.Entities.ProductImage
        //        {
        //            ImagePath = imagePath,
        //            CreatedDate = DateTime.Now
        //        };

        //        await _productImageWriteRepository.AddAsync(productImage);
        //        await _productImageWriteRepository.SaveAsync();
        //    }

        //    return new UploadProductImageCommandResponse();
        //}


    }
}
