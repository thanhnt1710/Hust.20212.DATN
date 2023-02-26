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
    public class EvaluateRepo : BaseRepo<Evaluate>, IEvaluateRepo
    {
        #region Declare
        #endregion

        #region Constructor
        public EvaluateRepo(IConfiguration configuration, IFileSystemService fileSystemService) : base(configuration, fileSystemService) { }

        #endregion

        #region Methods
        public async Task<List<Evaluate>> GetEvaluateByCourseID(string sql, object param)
        {
            var evaluateEnumable = await _dbConnection.QueryAsync<Evaluate>(sql, param);

            return evaluateEnumable.ToList();
        }

        public async Task<int> InsertEvaluate(string sql, object param)
        {
            return await _dbConnection.ExecuteAsync(sql, param);
        }
        #endregion
    }
}
