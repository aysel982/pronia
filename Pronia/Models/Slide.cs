namespace Pronia.Models
{
    public class Slide: BaseEntity
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string Image { get; set; }
       
    }
}
