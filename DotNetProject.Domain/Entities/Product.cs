namespace DotNetProject.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }

        public Product(string name, string manufacturePhone, string manufactureEmail)
        {
            Name = name;
            ManufacturePhone = manufacturePhone;
            ManufactureEmail = manufactureEmail;
        }
    }
}
