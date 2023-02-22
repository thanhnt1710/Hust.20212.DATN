using Dapper;
using Hust.Datn.Service.Const;
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
    public class CourseRepo : BaseRepo<Course>, ICourseRepo
    {
        #region Declare
        #endregion

        #region Constructor
        public CourseRepo(IConfiguration configuration, IFileSystemService fileSystemService) : base(configuration, fileSystemService) { }

        #endregion

        #region Methods
        public async Task<MaxID> GetMaxID(string sql)
        {
            return await _dbConnection.QueryFirstAsync<MaxID>(sql);
        }

        public async Task<Course> GetCourseByCourseID(Guid id)
        {
            var sql = await _fileSystemService.GetFileString(FileType.SqlQuery, "Course_GetByCourseID.sql");
            var param = new Dictionary<string, object>
            {
                { "ID", id }
            };

            var courseEnumable = await _dbConnection.QueryAsync<Course>(sql, param);

            return courseEnumable.ToArray().FirstOrDefault();
        }

        public async Task<List<Course>> GetCourseByUserID(Guid id)
        {
            var sql = await _fileSystemService.GetFileString(FileType.SqlQuery, "Course_GetByUserID.sql");
            var param = new Dictionary<string, object>
            {
                { "ID", id }
            };

            var courseEnumable = await _dbConnection.QueryAsync<Course>(sql, param);

            return courseEnumable.ToList();
        }

        public async Task<bool> RemoveCourse(string sql, object param)
        {
            var effectRow = await _dbConnection.ExecuteAsync(sql, param);
            return effectRow > 0 ? true : false;
        }
        #endregion

    }
}
