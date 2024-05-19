using Taller1.Src.Services.Interfaces;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;
using Taller1.Src.Helpers;

namespace Taller1.Src.Services.Implements
{
    public class PhotoService : IPhotoService
    {

        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddPhoto(IFormFile photo)
        {
            var uploadResult = new ImageUploadResult();
            if(photo.Length > 0)
            {
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "Taller1"
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhoto(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}