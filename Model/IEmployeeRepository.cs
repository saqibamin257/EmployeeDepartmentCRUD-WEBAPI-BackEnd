using EmployeeDepartment_CRUD_Model;

namespace EmployeeDepartment_CRUD_WEBAPI.Model
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        //Task<IEnumerable<Employee>> Search(string name);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);       
    }
}
