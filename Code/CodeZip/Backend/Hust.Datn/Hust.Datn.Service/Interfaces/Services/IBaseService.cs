using Hust.Datn.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces
{
    public interface IBaseService<Entity>
    {
        Task<IEnumerable<Entity>> GetAll();

        Task<Entity> GetById(string entityId);

        Task<ServiceResult> Add(Entity entity);

        Task<ServiceResult> Update(Entity entity);

        Task<ServiceResult> Delete(List<Entity> entities);

        Task<ServiceResult> GetMaxID();
    }
}
