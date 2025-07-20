using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Domain.Entities
{
    public class Slider
    {
        public Guid Id { get; set; }
        public List<SliderImages> SliderImages { get; set; }
        public string Link { get; set; }
    }

    public class SliderImages : ValueObject
    {
        public Guid Id { get; set; }
        public Guid SliderId { get; set; }
        public string ImagePath { get; set; }
    }
}
