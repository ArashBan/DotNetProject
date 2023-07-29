namespace DotNetProject.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

    }
}
