using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.DataAccess.Interfaces
{
    public interface IRepository<Entity, EntityKey> : IDisposable
        where Entity : class
    {
        IEnumerable<Entity> GetAllEntities();
        Entity GetEntityByKey(EntityKey entityKey);
        bool AddNewEntity(Entity entity);
    }
}
