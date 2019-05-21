using DockerDemo.Models;
using AutoMapper;
using employee.Controllers.Resources;

namespace DockerDemo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapping domain class to resource class.
            CreateMap<Employee, EmployeeResource>();
            //Mapping API resource class to domain class. And the id property is ignored to mapping.
            CreateMap<EmployeeResource, Employee>().ForMember(v => v.Id, opt => opt.Ignore());
        }
    }
}