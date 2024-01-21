using System.ComponentModel.DataAnnotations;

namespace MyRestApi.Models
{
    public class PersonModel
    {
        [Key]
        public Guid PersonId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Photo { get; set; }
    }
}
