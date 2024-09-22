using Company.Data.Contexts;
using Company.Reposatory.Interfaces;
using Company.Reposatory.Reposatories;
using Company.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;

        public UnitOfWork(CompanyDbContext context) 
        {
            _context = context;
            employeeReposatory = new EmployeeReposatory(context);
            departmentReposatory = new DepartmentReposatory(context);
        }
        public IEmployeeReposatory employeeReposatory { get; set; }
        public IDepartmentReposatory departmentReposatory { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
