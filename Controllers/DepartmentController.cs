using EmployeeDepartment_CRUD_Model;
using EmployeeDepartment_CRUD_WEBAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartment_CRUD_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository iDeparmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            iDeparmentRepository= departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDepartments() 
        {
            try
            {
                return Ok(await iDeparmentRepository.GetAllDepartments());
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartmentById(int id)         
        {
            try
            {
                var result = await iDeparmentRepository.GetDepartmentById(id);
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
        [HttpPost]
        public async Task<ActionResult<Department>> AddDepartment(Department department)
        {
            try
            {
                if (department == null)
                {
                    return BadRequest();
                }
                var createdDepartment = await iDeparmentRepository.AddDepartment(department);
                return CreatedAtAction(nameof(GetDepartmentById), new { Id = createdDepartment.Id }, createdDepartment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Department>> UpdateDepartment(int id, Department department)
        {
            try
            {
                if (id != department.Id)
                {
                    return BadRequest("Department Id mismatch");
                }
                var dept = await iDeparmentRepository.GetDepartmentById(id);
                if (dept == null)
                {
                    return NotFound($"Department with Id {id} not found.");
                }
                return await iDeparmentRepository.UpdateDepartment(department);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Department>> DeleteDepartment(int id)
        {
            try
            {
                var dept = await iDeparmentRepository.GetDepartmentById(id);
                if (dept == null)
                {
                    return NotFound($"Employee with Id {id} not found.");
                }
                return await iDeparmentRepository.DeleteDepartment(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }

    }
}
