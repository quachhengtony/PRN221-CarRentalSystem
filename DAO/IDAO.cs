using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    internal interface IDAO<T>
    {
        public void Create(T t);
        public List<T> Retrieve();
        public T RetrieveById(string id);
        public void Update(T t);
        public void Delete(T t);
        public void SaveChanges();
    }
}
