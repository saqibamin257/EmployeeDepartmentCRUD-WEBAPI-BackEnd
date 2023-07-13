using EmployeeDepartment_CRUD_Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartment_CRUD_WEBAPI.Model
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly AppDBContext appDBContext;
        public EmployeeRepository(AppDBContext _appDBContext)
        {
            this.appDBContext = _appDBContext;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await appDBContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await appDBContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        //public async Task<IEnumerable<Employee>> Search(string name)
        //{
        //    IQueryable<Employee> query = appDBContext.Employees;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        query = query.Where(e => e.Name.Contains(name));
        //    }
        //    return await query.ToListAsync();
        //}

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDBContext.Employees.AddAsync(employee);
            await appDBContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var emp = await appDBContext.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (emp != null)
            {
                emp.EmployeeName = employee.EmployeeName;
                emp.DateOfJoining = employee.DateOfJoining;
                emp.PhotoFileName = employee.PhotoFileName;
                emp.DepartmentId = employee.DepartmentId;
                await appDBContext.SaveChangesAsync();
                return emp;
            }
            return null;
        }
        public async Task<Employee> DeleteEmployee(int id)
        {
            var result = await appDBContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (result != null)
            {
                appDBContext.Employees.Remove(result);
                await appDBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }      
    }
}
