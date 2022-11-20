using Hust.Datn.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Interfaces
{
    public interface IBaseRepo<Entity>
    {
        Task<IEnumerable<Entity>> GetAll(string source);

        Task<Entity> GetByIdGuid(Guid entityId);

        Task<Entity> GetByIdInt(int entityId);

        Task<ServiceResult> Add(Entity entity);

        Task<ServiceResult> Update(Entity entity);

        Task<ServiceResult> DeleteGuid(List<Guid> entityIds);

        Task<ServiceResult> DeleteInt(List<int> entityIds);
    }
}
