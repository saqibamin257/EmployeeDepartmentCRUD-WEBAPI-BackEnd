using EmployeeDepartment_CRUD_Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartment_CRUD_WEBAPI.Model
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private AppDBContext AppDBContext;
        public DepartmentRepository(AppDBContext _AppDBContext)
        {
            AppDBContext = _AppDBContext;
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await AppDBContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await AppDBContext.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<Department> AddDepartment(Department department)
        {
            var result = await AppDBContext.Departments.AddAsync(department);
            await AppDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            var dept = await AppDBContext.Departments.FirstOrDefaultAsync(dept=>dept.Id == id);
            if(dept != null)
            {
                AppDBContext.Departments.Remove(dept);
                await AppDBContext.SaveChangesAsync();
                return dept;
            }
            return null;
        }
          

        //public Task<IEnumerable<Department>> Search(string name)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Department> UpdateDepartment(Department department)
        {
            var dept = await AppDBContext.Departments.FirstOrDefaultAsync(d=>d.Id== department.Id);
            if(dept != null) 
            {
                dept.DepartmentName = department.DepartmentName;
                await AppDBContext.SaveChangesAsync();
                return dept;
            }
            return null;
            
        }
    }
}
