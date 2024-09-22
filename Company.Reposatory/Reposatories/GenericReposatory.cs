using Company.Data.Contexts;
using Company.Data.Entities;
using Company.Reposatory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatory.Reposatories
{
    public class GenericReposatory<T> : IGenericReposatory<T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;

        public GenericReposatory(CompanyDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public List<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x=>x.Id == id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
