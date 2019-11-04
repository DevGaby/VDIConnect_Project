using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VDIConnect_API.Models
{
    public class Session
    {
        [Key] public int Id { get; set; }
        public string Title { get; set; }
        [Required] public DateTime DateStart { get; set; }
        [Required] public DateTime DateEnd { get; set; }
        [Required] public int IdCreator { get; set; }
        public int NbSeat { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public int? IdHote { get; set; }
        public int? IdVDI { get; set; }
        [Required] public int IdTypeInterest { get; set; }
        [ForeignKey("IdTypeInterest")]
        public TypeInterest TypeInterest { get; set; }
        public int? IdEvent { get; set; }
        [ForeignKey("IdEvent")]
        public Event Event { get; set; }
        public List<Person> Members { get; set; }
        public bool Delete { get; set; }
    }
}