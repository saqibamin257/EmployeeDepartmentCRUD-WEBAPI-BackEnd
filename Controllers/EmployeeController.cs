using EmployeeDepartment_CRUD_Model;
using EmployeeDepartment_CRUD_WEBAPI.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartment_CRUD_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IEmployeeRepository _employeeRepository, IWebHostEnvironment env)
        {
            employeeRepository = _employeeRepository;
            _env = env;
        }       
       
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            try
            {
                return Ok(await employeeRepository.GetAllEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployeeById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        //[HttpGet("{search}")]
        //public async Task<ActionResult<IEnumerable<Employee>>> Search(string search)
        //{
        //    try
        //    {
        //        var result = await employeeRepository.Search(search);
        //        if (result.Any())
        //        {
        //            return Ok(result);
        //        }
        //        return NotFound();

        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error searching the employee");
        //    }
        //}


        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return BadRequest();
                }
                var createdEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { Id = createdEmployee.Id }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.Id)
                {
                    return BadRequest("Employee Id mismatch");
                }
                var emp = await employeeRepository.GetEmployeeById(id);
                if (emp == null)
                {
                    return NotFound($"Employee with Id {id} not found.");
                }
                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var emp = await employeeRepository.GetEmployeeById(id);
                if (emp == null)
                {
                    return NotFound($"Employee with Id {id} not found.");
                }
                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        //public JsonResult SaveFile()
        //{
        //    try
        //    {
        //        var httpRequest = Request.Form;
        //        var postedFile = httpRequest.Files[0];
        //        string filename = postedFile.FileName;
        //        var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

        //        using (var stream = new FileStream(physicalPath, FileMode.Create))
        //        {
        //            postedFile.CopyTo(stream);
        //        }

        //        return new JsonResult(filename);
        //    }
        //    catch (Exception)
        //    {

        //        return new JsonResult("anonymous.png");
        //    }
        //}
    }
}
