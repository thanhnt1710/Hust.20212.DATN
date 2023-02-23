using Hust.Datn.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces.Services
{
    public interface IQuestionService : IBaseService<Question>
    {
        Task<ServiceResult> GetMaxID();
    }
}
