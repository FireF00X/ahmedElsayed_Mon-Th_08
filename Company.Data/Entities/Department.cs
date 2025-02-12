﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Entities
{
    public class Department : BaseEntity
    {
        [DisplayName("DepartmentName")]
        public string Name { get; set; }
        public string Code { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
