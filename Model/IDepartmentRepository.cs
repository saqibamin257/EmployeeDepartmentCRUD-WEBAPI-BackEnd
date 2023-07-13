using EmployeeDepartment_CRUD_Model;

namespace EmployeeDepartment_CRUD_WEBAPI.Model
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int id);
        //Task<IEnumerable<Department>> Search(string name);
        Task<Department> AddDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task<Department> DeleteDepartment(int id);
    }
}
