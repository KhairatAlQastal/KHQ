using KHQ.Domain;
using KHQ.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Srv.Services
{
    public interface IImageService
    {
        Task<List<Image>> SaveImagesAsync(List<IFormFile> images, Guid foreignKey, ImageType imageType);
    }

}
