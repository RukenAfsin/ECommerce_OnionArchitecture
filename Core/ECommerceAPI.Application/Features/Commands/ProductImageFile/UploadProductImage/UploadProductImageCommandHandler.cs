﻿//using ECommerceAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
//using ECommerceAPI.Application.Repositories;
//using ETicaretAPI.Application.Abstractions.Storage;
//using ETicaretAPI.Application.Repositories;
//using MediatR;
//using p = ECommerceAPI.Domain.Entities;


//namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
//{
//    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
//    {
//        readonly IStorageService _storageService;
//        readonly IProductReadRepository _productReadRepository;
//        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

//        public UploadProductImageCommandHandler(IStorageService storageService, IProductReadRepository productReadRepository, IProductImageFileWriteRepository productImageFileWriteRepository)
//        {
//            _storageService = storageService;
//            _productReadRepository = productReadRepository;
//            _productImageFileWriteRepository = productImageFileWriteRepository;
//        }

//        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
//        {
//            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);


//            p.Product product = await _productReadRepository.GetByIdAsync(request.Id);


//            await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new Domain.Entities.ProductImageFile
//            {
//                FileName = r.fileName,
//                Path = r.pathOrContainerName,
//                Storage = _storageService.StorageName,
//                Products = new List<p.Product>() { product }
//            }).ToList());

//            await _productImageFileWriteRepository.SaveAsync();

//            return new();
//        }
//    }
//}