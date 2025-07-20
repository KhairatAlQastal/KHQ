using KHQ.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Srv.Services
{
    public interface IUserService
    {
        Task Register(UserRegister viewModel);

        Task<ValidateUserResult> Login(UserLogin viewModel);

        Task Logout();
    }
}
