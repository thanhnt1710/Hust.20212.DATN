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
    public class EvaluateService : BaseService<Evaluate>, IEvaluateService
    {
        #region Declare
        protected readonly IEvaluateRepo _evaluateRepo;
        #endregion

        #region Constructor
        public EvaluateService(IEvaluateRepo evaluateRepo, IFileSystemService fileSystemService, IConfiguration configuration) : base(evaluateRepo, fileSystemService, configuration)
        {
            _evaluateRepo = evaluateRepo;
        }

        #endregion

        #region Methods
        public async Task<ServiceResult> GetEvaluateByCourseID(Guid courseID)
        {
            var result = new ServiceResult();

            var sql = @"SELECT
                          e.EvaluateID,
                          u.FullName AS UserName,
                          e.EvaluateContent,
                          e.CreatedDate,
                          DATE_FORMAT(e.CreatedDate, '%T %d/%m/%Y') AS CreatedDateStr
                        FROM Evaluate e
                          INNER JOIN User u
                            ON e.UserID = u.UserID
                        WHERE e.CourseID = @CourseID
                        ORDER BY e.CreatedDate DESC";
            var param = new
            {
                CourseID = courseID
            };

            result.Data = await _evaluateRepo.GetEvaluateByCourseID(sql, param);

            return result;
        }

        public async Task<ServiceResult> InsertEvaluate(Evaluate evaluate)
        {
            var result = new ServiceResult();

            var sql = @"INSERT INTO Evaluate (CourseID, UserID, EvaluateContent, CreatedDate)
                        VALUES (@CourseID, @UserID, @EvaluateContent, NOW());";
            var param = new
            {
                CourseID = evaluate.CourseID,
                UserID = evaluate.UserID,
                EvaluateContent = evaluate.EvaluateContent,
            };

            var rowEffect = await _evaluateRepo.InsertEvaluate(sql, param);
            result.Success = rowEffect > 0;

            return result;
        }
        #endregion
    }
}
