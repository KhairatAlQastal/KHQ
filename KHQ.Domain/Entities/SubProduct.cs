using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Domain.Entities
{
    public class SubProduct
    {
        public Guid Id { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string ImageUrl { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
