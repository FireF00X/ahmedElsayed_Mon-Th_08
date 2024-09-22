using AutoMapper;
using Company.Data.Entities;
using Company.Services.Interfaces;
using Company.Services.Interfaces.Dto;

namespace Company.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(DepartmentDto departmentDto)
        {
            var newDept = _mapper.Map<Department>(departmentDto);
            _unitOfWork.departmentReposatory.Add(newDept);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var newDept = _mapper.Map<Department>(departmentDto);
            _unitOfWork.departmentReposatory.Delete(newDept);
            _unitOfWork.Complete();
        }

        public List<DepartmentDto> GetAll()
        {
            var deptList = _unitOfWork.departmentReposatory.GetAll();
            var deptDtoList = _mapper.Map<List<DepartmentDto>>(deptList);
            return deptDtoList;
        }

        public DepartmentDto GetById(int id)
        {
            var dept = _unitOfWork.departmentReposatory.GetById(id);
            var deptDto = _mapper.Map<DepartmentDto>(dept);
            return deptDto;
        }

        public void Update(DepartmentDto departmentDto)
        {
            //var updatedDept = GetById(departmentDto.Id);
            //updatedDept.Code = departmentDto.Code;
            //updatedDept.Name = departmentDto.Name;
            //_unitOfWork.departmentReposatory.Update(updatedDept);
            //_unitOfWork.Complete();
        }
    }
}
