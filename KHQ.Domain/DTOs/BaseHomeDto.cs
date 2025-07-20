using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Domain.DTOs
{
    public class BaseHomeDto
    {
        public Guid Id { get; set; }

        // About Us
        public string AboutUsTitle { get; set; }
        public string AboutUsDescreption { get; set; }

        // Category
        public string CategoryTitleEn { get; set; }
        public string CategoryTitleAr { get; set; }
        public string CategoryDescriptionEn { get; set; }
        public string CategoryDescriptionAr { get; set; }

        // FAQ
        public string FAQTitleEn { get; set; }
        public string FAQTitleAr { get; set; }
        public string FAQDescriptionEn { get; set; }
        public string FAQDescriptionAr { get; set; }

        // Brands
        public string BrandsTitleEn { get; set; }
        public string BrandsTitleAr { get; set; }
        public string BrandsDescriptionEn { get; set; }
        public string BrandsDescriptionAr { get; set; }
    }

}
