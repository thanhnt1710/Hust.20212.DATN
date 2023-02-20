using Hust.Datn.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces.Services
{
    public interface IAuthService : IBaseService<User>
    {
        Task<ServiceResult> Login(string userName, string password);
        Task<ServiceResult> Register(User user);
    }
}
