using System.ComponentModel.DataAnnotations;

namespace VDIConnect_API.Models
{
    public class Role
    {
        [Key] public int Id { get; set; }
        public string Label { get; set; }
    }
}