using Company.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Reposatory.Interfaces
{
    public interface IEmployeeReposatory : IGenericReposatory<Employee>
    {
        public IEnumerable<Employee> GetEmployeeByName(string name);
    }
}
