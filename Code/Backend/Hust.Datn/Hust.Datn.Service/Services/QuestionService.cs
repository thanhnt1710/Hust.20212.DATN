using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Services
{
    public class QuestionService: BaseService<Question>, IQuestionService
    {
        #region Declare
        protected readonly IQuestionRepo _questionRepo;
        #endregion

        #region Constructor
        public QuestionService(IQuestionRepo questionRepo, IFileSystemService fileSystemService, IConfiguration configuration) : base(questionRepo, fileSystemService, configuration)
        {
            _questionRepo = questionRepo;
        }

        #endregion

        #region Methods
        public async Task<ServiceResult> GetMaxID()
        {
            var result = new ServiceResult();

            var sql = @"SELECT IFNULL(MAX(q.QuestionID), 0) AS QuestionID FROM Question q;";

            result.Data = await _questionRepo.GetMaxID(sql);

            return result;
        }
        #endregion
    }
}
