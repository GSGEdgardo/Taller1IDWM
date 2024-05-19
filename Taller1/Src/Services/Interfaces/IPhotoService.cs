using CloudinaryDotNet.Actions;

namespace Taller1.Src.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhoto(IFormFile photo);
        Task<DeletionResult> DeletePhoto(string publicId);
    }
}