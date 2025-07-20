using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Domain.DTOs
{
    public class ValidateUserResult
    {
        public bool IsValid { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
