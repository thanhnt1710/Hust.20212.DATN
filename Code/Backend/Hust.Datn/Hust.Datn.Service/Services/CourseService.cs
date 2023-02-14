using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        #region Declare
        protected readonly ICourseRepo _courseRepo;
        #endregion

        #region Constructor
        public CourseService(ICourseRepo courseRepo, IFileSystemService fileSystemService, IConfiguration configuration) : base(courseRepo, fileSystemService, configuration)
        {
            _courseRepo = courseRepo;
        }

        #endregion

        #region Methods
        public async Task<ServiceResult> SaveCourse(Course course)
        {
            var result = new ServiceResult();
            IDbTransaction tran = null;
            _dbConnection.Open();

            using (tran = _dbConnection.BeginTransaction())
            {
                try
                {
                    // Insert khóa học

                    // Insert chương

                    //Insert bài

                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                }
            }
            _dbConnection.Close();

            return result;
        }
        #endregion
    }
}
