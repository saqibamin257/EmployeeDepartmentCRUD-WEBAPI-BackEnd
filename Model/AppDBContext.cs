using EmployeeDepartment_CRUD_Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartment_CRUD_WEBAPI.Model
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
         : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Employee Table
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                EmployeeName = "Saqib",
                DateOfJoining = DateTime.Now,
                PhotoFileName = "anonymous.png",
                DepartmentId=1
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                EmployeeName = "Malik",
                DateOfJoining = DateTime.Now,
                PhotoFileName = "anonymous.png",
                DepartmentId = 2
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                EmployeeName = "Imran",
                DateOfJoining = DateTime.Now,
                PhotoFileName = "anonymous.png",
                DepartmentId = 3
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 4,
                EmployeeName = "Farhan",
                DateOfJoining = DateTime.Now,
                PhotoFileName = "anonymous.png",
                DepartmentId = 4
            });

            // Seed Department Table
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                DepartmentName = "Sales",               
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 2,
                DepartmentName = "Production",                
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 3,
                DepartmentName = "IT",                
            });
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 4,
                DepartmentName = "Accounts",                
            });
        }
    }
}
