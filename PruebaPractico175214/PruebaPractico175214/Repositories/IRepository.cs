using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T>
    {
        void Create(T anEntity);
        void Delete(int anId);
        T Get(int anId);
        void Update(T anEntity);
    }
}
