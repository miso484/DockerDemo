using System.Collections.Generic;
using System.Threading.Tasks;
using DockerDemo.EmployeeDB;
using DockerDemo.Models;
using AutoMapper;
using employee.Controllers.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerDemo.Controllers
{
    [Route("/api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IMapper mapper;
        private readonly EmployeeDbContext context;
        public EmployeeController(IMapper mapper, EmployeeDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeResource>> GetEmployee(EmployeeResource employeeResource)
        {
            var employee = await context.Employees.ToListAsync();
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employee);
        } 

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeResource employeeResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var employee = mapper.Map<EmployeeResource, Employee>(employeeResource);
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return Ok(employee);
        }   

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeResource employeeResource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var employee = await context.Employees.FindAsync(id); 
            if(employee == null)
                return NotFound();
            mapper.Map<EmployeeResource, Employee>(employeeResource, employee);
            await context.SaveChangesAsync();
            return Ok(employee);
        }


        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if(employee == null)
                return NotFound();
            var employeeResource = mapper.Map<Employee, EmployeeResource>(employee);
            return Ok(employeeResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if(employee == null)
                return NotFound();
            context.Remove(employee);
            await context.SaveChangesAsync();
            return Ok(id);
        }
    }
}
