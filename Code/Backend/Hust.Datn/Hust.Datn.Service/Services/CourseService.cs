using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Hust.Datn.Service.Interfaces.Services;
using System;
using System.Collections.Generic;
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
        public CourseService(ICourseRepo courseRepo, IFileSystemService fileSystemService) : base(courseRepo, fileSystemService)
        {
            _courseRepo = courseRepo;
        }

        #endregion

        #region Methods
        public async Task<ServiceResult> SaveCourse(Course course)
        {
            var result = new ServiceResult();
            SqlTransaction tran = null;
            using (var cnn = _dbConnection)
            {
                tran = (SqlTransaction)cnn.BeginTransaction();
                // Insert khóa học

                // Insert chương

                //Insert bài
            }

                return result;
        }
        #endregion
    }
}
