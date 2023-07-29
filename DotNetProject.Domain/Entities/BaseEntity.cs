namespace DotNetProject.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime ProduceDate { get; set; }
        public bool IsAvailable { get; set; }

        public BaseEntity()
        {
            ProduceDate = DateTime.Now;
        }
    }
}
