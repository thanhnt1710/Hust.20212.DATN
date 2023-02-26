using Hust.Datn.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces.Repos
{
    public interface IEvaluateRepo: IBaseRepo<Evaluate>
    {
        Task<List<Evaluate>> GetEvaluateByCourseID(string sql, object param);
        Task<int> InsertEvaluate(string sql, object param);
    }
}
