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
    public class EmployeeReposatory : GenericReposatory<Employee>, IEmployeeReposatory
    {
        private readonly CompanyDbContext _context;

        public EmployeeReposatory(CompanyDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            return _context.Employees.Where(emp => emp.Name
                                                      .Trim()
                                                      .ToLower()
                                                      .Contains(name.Trim().ToLower())).ToList();
        }
    }
}
