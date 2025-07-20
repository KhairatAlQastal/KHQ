using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Domain.ViewModel
{
    public class ContactUsVM
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string CompanyLocation { get; set; }
    }
}
