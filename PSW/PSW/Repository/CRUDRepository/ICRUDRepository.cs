using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSW.Repository.CRUDRepository
{
    public interface ICRUDRepository<T, ID>
    {

        int Count();

        void Delete(T entity);

        void DeleteAll();

        void DeleteById(ID identificator);

        Boolean ExistsById(ID id);

        IEnumerable<T> FindAll();

        T FindById(ID id);

        void Save(T entity);

        void SaveAll(IEnumerable<T> entities);

        IEnumerable<T> FindAllById(IEnumerable<ID> ids);
    }
}
