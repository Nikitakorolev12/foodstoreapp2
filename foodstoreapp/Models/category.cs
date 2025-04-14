using System.ComponentModel.DataAnnotations;
namespace foodstoreapp.Models
{
    public class category
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
