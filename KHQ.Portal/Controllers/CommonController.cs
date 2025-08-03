using AutoMapper;
using KHQ.Domain;
using KHQ.Domain.DTOs;
using KHQ.Domain.Entities;
using KHQ.Repo.UOW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KHQ.Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpPost("SaveImages")]
        public async Task<IActionResult> SaveImages(List<IFormFile> images, Guid fKey)
        {
            if (images == null || images.Count == 0 || fKey == Guid.Empty)
                return BadRequest("No images uploaded or invalid F_Key");

            var id = Guid.NewGuid();
            var savedImages = new List<Image>();
            string[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Select(c => c.ToString()).ToArray();
            string folderPath = Path.Combine("wwwroot", "Images");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            for (int i = 0; i < images.Count; i++)
            {
                var file = images[i];
                if (file.Length > 0)
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    string sortedName = alphabet.Length > i ? alphabet[i] : $"Image_{i}";
                    string newFileName = $"{sortedName}_{id}{fileExtension}";
                    string fullPath = Path.Combine(folderPath, newFileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    savedImages.Add(new Image
                    {
                        Id = id,
                        F_Key = fKey,
                        PathLink = $"/Images/{newFileName}",
                        ImageType = ImageType.Sliders,
                        ImageName = newFileName,
                        Sort = i
                    });
                }
            }
            await _unitOfWork.Repository<Image>().AddRange(savedImages);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new { success = true, count = savedImages.Count });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteImage(Guid id, Guid fKey)
        {
            if (id == Guid.Empty || fKey == Guid.Empty)
                return BadRequest("Invalid parameters");

            var image = await _unitOfWork.Repository<Image>().Queryable().Where(i => i.Id == id && i.F_Key == fKey).FirstOrDefaultAsync();
            if (image == null)
                return NotFound("Image not found");

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.PathLink.TrimStart('/'));
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);

            _unitOfWork.Repository<Image>().Delete(image);
            await _unitOfWork.SaveChangesAsync();

            return Ok(new { success = true });
        }


        [HttpPost]
        public async Task<IActionResult> UpdateImageSort([FromBody] List<ImageSortUpdateDto> sortedImages)
        {
            if (sortedImages == null || !sortedImages.Any())
                return BadRequest("Invalid sort data.");

            var imageIds = sortedImages.Select(i => i.Id).ToList();
            var images = await _unitOfWork.Repository<Image>().Queryable().Where(i => imageIds.Contains(i.Id)).ToListAsync();

            foreach (var update in sortedImages)
            {
                var image = images.FirstOrDefault(i => i.Id == update.Id);
                if (image != null)
                {
                    image.Sort = update.Sort;
                }
            }

            await _unitOfWork.SaveChangesAsync();

            return Ok(new { success = true });
        }
    }
}
