﻿using Dapper;
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
    public class QuestionRepo : BaseRepo<Question>, IQuestionRepo
    {
        #region Declare
        #endregion

        #region Constructor
        public QuestionRepo(IConfiguration configuration, IFileSystemService fileSystemService) : base(configuration, fileSystemService) { }

        #endregion

        #region Methods
        public async Task<int> GetMaxID(string sql)
        {
            return await _dbConnection.QueryFirstAsync<int>(sql);
        }

        public async Task<List<ResultTest>> ScroingTest(string sql, object param)
        {
            var testEnumable = await _dbConnection.QueryAsync<ResultTest>(sql, param);

            return testEnumable.ToList();
        }
        #endregion

    }
}
