using KHQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Repo.Mapping
{
    public class SliderMapping : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            //builder.OwnsMany(x => x.SliderImages, slider =>
            //{
            //    slider.ToTable(typeof(SliderImages).Name.Pluralize());
            //    slider.HasKey(x => x.Id);
            //    slider.Property(x => x.SliderId).IsRequired();
            //    slider.Property(x => x.ImagePath).IsRequired();
            //});
        }
    }
}
