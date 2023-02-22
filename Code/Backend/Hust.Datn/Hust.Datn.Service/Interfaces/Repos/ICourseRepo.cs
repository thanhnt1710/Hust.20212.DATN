using Hust.Datn.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces.Repos
{
    public interface ICourseRepo : IBaseRepo<Course>
    {
        Task<MaxID> GetMaxID(string sql);
        Task<Course> GetCourseByCourseID(Guid courseID);
        Task<List<Course>> GetCourseByUserID(Guid courseID);
        Task<bool> RemoveCourse(string sql, object param);
    }
}
