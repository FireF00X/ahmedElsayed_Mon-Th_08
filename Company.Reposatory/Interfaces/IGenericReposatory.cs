using Company.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatory.Interfaces
{
    public interface IGenericReposatory<T> where T : BaseEntity
    {
        T GetById(int id);
        List<T> GetAll();
        void Delete(T entity);
        void Add(T entity);
        void Update(T entity);
    }
}
