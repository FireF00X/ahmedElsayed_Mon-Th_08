using Company.Services.Interfaces.Dto;

namespace Company.Services.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentDto GetById(int id);
        List<DepartmentDto> GetAll();
        void Add(DepartmentDto departmentDto);
        void Update(DepartmentDto departmentDto);
        void Delete(DepartmentDto departmentDto);
    }
}
