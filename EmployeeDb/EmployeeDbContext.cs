using DockerDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerDemo.EmployeeDB
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) 
            : base(options){}
        public DbSet<Employee> Employees { get; set; }
    }
}