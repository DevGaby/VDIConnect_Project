using System.ComponentModel.DataAnnotations;

namespace VDIConnect_API.Models
{
    public class Enterprise
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public bool Delete { get; set; }
    }
}