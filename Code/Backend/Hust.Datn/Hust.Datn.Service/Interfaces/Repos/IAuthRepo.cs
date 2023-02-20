using Hust.Datn.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces.Repos
{
    public interface IAuthRepo: IBaseRepo<User>
    {
        Task<User> GetUser(string userName, string password);

        Task<int> InsertUser(string sql, object param);

        Task<bool> CheckUserName(string sql, object param);
    }
}
