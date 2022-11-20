using Dapper;
using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Infrastructure.Repository
{
    public class BaseRepo<Entity>: IBaseRepo<Entity>
    {
        #region Declare
        IConfiguration _configuration;
        //Chuoi ket noi
        string _connectionString = string.Empty;
        protected readonly IDbConnection _dbConnection = null;
        protected string _tableName;
        #endregion

        #region Constructor
        public BaseRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            //Khai báo thông tin kêt nối tới db
            _connectionString = _configuration.GetConnectionString("ConnectionString");
            //Khởi tạo kết nối 
            _dbConnection = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<Entity>> GetAll(string source)
        {
            
            var entities = await _dbConnection.QueryAsync<Entity>(source);
            
            return entities;
        }

        public Task<Entity> GetById(string entityId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Add(Entity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Delete(List<Entity> entities)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
