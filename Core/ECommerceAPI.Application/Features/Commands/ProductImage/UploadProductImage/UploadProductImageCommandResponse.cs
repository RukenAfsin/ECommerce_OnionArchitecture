using System;
using ECommerceAPI.Application.Constants;
using p = ECommerceAPI.Application.Constants;

namespace ECommerceAPI.Application.Features.Commands.ProductImage.UploadProductImage
{
    public class UploadProductImageCommandResponse
    {
        public enum UploadStatus
        {
            Success,
            Failure
        }

        public UploadStatus Status { get; set; }
        public string Message { get; private set; }

        public void SetMessage()
        {
            Message = Status == UploadStatus.Success ? p.Message.UploadSuccess : p.Message.UploadFailure;
        }
    }
}




