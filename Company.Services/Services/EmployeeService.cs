using AutoMapper;
using Company.Data.Entities;
using Company.Reposatory.Interfaces;
using Company.Reposatory.Reposatories;
using Company.Services.Helper;
using Company.Services.Interfaces;
using Company.Services.Interfaces.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image, "Images");
            var newEmp = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.employeeReposatory.Add(newEmp);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            var newEmp = _mapper.Map<Employee>(employeeDto);
            _unitOfWork.employeeReposatory.Delete(newEmp);
            _unitOfWork.Complete();
        }

        public List<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.employeeReposatory.GetAll();
            List<EmployeeDto> mappedEmployees = _mapper.Map<List<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public EmployeeDto GetById(int id)
        {
            var emp = _unitOfWork.employeeReposatory.GetById(id);
            var empDto = _mapper.Map<EmployeeDto>(emp);
            return empDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employees = _unitOfWork.employeeReposatory.GetEmployeeByName(name);
            var mappedEmployees = _mapper.Map<List<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public void Update(EmployeeDto employeeDto)
        {

            //var emp = GetById(employeeDto.Id);

            //emp.Name = employeeDto.Name;
            //emp.Age = employeeDto.Age;
            //emp.Salary = employeeDto.Salary;
            //emp.PhoneNumber = employeeDto.PhoneNumber;
            //emp.Address = employeeDto.Address;
            //emp.Email = employeeDto.Email;
            //emp.DepartmentId = employeeDto.DepartmentId;
            //emp.HiringDate = employeeDto.HiringDate;

            //_unitOfWork.employeeReposatory.Update(emp);
            //_unitOfWork.Complete();
        }
    }
}
