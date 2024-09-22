using Company.Data.Entities;
using Company.Services.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto GetById(int id);
        List<EmployeeDto> GetAll();
        void Add(EmployeeDto employeeDto);
        void Update(EmployeeDto employeeDto);
        void Delete(EmployeeDto employeeDto);
        IEnumerable<EmployeeDto> GetEmployeeByName(string name);
    }
}
