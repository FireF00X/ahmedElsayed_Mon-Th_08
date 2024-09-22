using Company.Reposatory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeReposatory employeeReposatory { get; set; }
        public IDepartmentReposatory departmentReposatory{ get; set; }

        int Complete();
    }
}
