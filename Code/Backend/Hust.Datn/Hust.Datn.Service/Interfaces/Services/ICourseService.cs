using Hust.Datn.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces.Services
{
    public interface ICourseService : IBaseService<Course>
    {
        Task<ServiceResult> SaveCourse(Course course);

        Task<ServiceResult> GetMaxID();
    }
}
