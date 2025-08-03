using KHQ.Domain;
using KHQ.Domain.Entities;
using KHQ.Srv.Services;

namespace KHQ.Portal.Service
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<Image>> SaveImagesAsync(List<IFormFile> images, Guid foreignKey, ImageType imageType)
        {
            List<Image> savedImages = new();

            if (images == null || !images.Any())
                return savedImages;

            string folderName = Path.Combine("Images", imageType.ToString());
            string wwwRootPath = Path.Combine(_webHostEnvironment.WebRootPath, folderName);

            if (!Directory.Exists(wwwRootPath))
                Directory.CreateDirectory(wwwRootPath);
            var sort = 0;
            foreach (var file in images)
            {
                sort++;
                if (file.Length <= 0)
                    continue;

                string uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                string filePath = Path.Combine(wwwRootPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                string relativePath = Path.Combine(folderName, uniqueFileName).Replace("\\", "/");

                savedImages.Add(new Image
                {
                    Id = Guid.NewGuid(),
                    F_Key = foreignKey,
                    PathLink = $"/{relativePath}",
                    ImageType = imageType,
                    ImageName = file.FileName,
                    Sort = sort
                });
            }

            return savedImages.OrderBy(x => x.Sort).ToList();
        }
    }
}
