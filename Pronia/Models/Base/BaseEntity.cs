namespace Pronia.Models
{
    public abstract class BaseEntity
    {
        public int id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
