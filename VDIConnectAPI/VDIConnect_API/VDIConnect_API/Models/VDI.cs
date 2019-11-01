using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VDIConnect_API.Models
{
    public class VDI
    {
        [Key] public int Id { get; set; }
        public int IdEnterprise { get; set; }
        [ForeignKey("IdEnterprise")]
        public Enterprise Enterprise { get; set; }
        public int IdPerson { get; set; }
        [ForeignKey("IdPerson")]
        public Person Person { get; set; }
        public bool Archive { get; set; }
    }
}