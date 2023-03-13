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
        Task<bool> RemoveCourse(string sql, object param);
        Task<List<Course>> GetListCourse(string sql, ParamGetCourse param);
        Task<Statistic> GetDataStatistic(string sql);
    }
}
