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
    public class DepartmentReposatory : GenericReposatory<Department> , IDepartmentReposatory
    {
        private readonly CompanyDbContext context;

        public DepartmentReposatory(CompanyDbContext context) : base (context)
        {
            this.context = context;
        }
    }
}
