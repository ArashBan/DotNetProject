using System.Security.AccessControl;

namespace DotNetProject.Application.DTOs
{
    public class AddNewProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
    }
}
