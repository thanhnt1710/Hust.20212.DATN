using Hust.Datn.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces.Services
{
    public interface IEvaluateService : IBaseService<Evaluate>
    {
        Task<ServiceResult> GetEvaluateByCourseID(Guid id);

        Task<ServiceResult> InsertEvaluate(Evaluate e);
    }
}
