using Dapper;
using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Infrastructure.Repository
{
    public class AuthRepo : BaseRepo<User>, IAuthRepo
    {
        #region Declare
        #endregion

        #region Constructor
        public AuthRepo(IConfiguration configuration, IFileSystemService fileSystemService) : base(configuration, fileSystemService) { }

        #endregion

        #region Methods
        public async Task<User> GetUser(string userName, string password)
        {
            var sql = @"SELECT
                          u.UserID,
                          u.FullName,
                          u.Role,
                          u.UserName,
                          u.Password,
                          u.CreatedBy,
                          u.ModifiedBy,
                          u.CreatedDate,
                          u.ModifiedDate
                        FROM User u
                        WHERE u.UserName = @UserName
                        AND u.Password = @Password LIMIT 1;";
            var param = new
            {
                UserName = userName,
                Password = password
            };

            return await _dbConnection.QueryFirstOrDefaultAsync<User>(sql, param);
        }

        public async Task<int> InsertUser(string sql, object param)
        {
            return await _dbConnection.ExecuteAsync(sql, param);
        }

        public async Task<bool> CheckUserName(string sql, object param)
        {
            var check = await _dbConnection.ExecuteScalarAsync<int>(sql, param);
            if (check == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
