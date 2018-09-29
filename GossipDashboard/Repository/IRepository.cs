using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GossipDashboard.Repository
{
    interface IRepository<T>
    {
        T Add(T entity);

        T Update(T entity);

        bool Delete(int id);

        T Select(int id);
    }
}
