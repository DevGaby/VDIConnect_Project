using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VDIConnect_API.Models
{
    public class Event
    {
        /// <summary>
        /// Class de contruction d'un événement
        /// </summary>
        [Key] public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? IdPersonne { get; set; }
        [ForeignKey("IdPersonne")]
        public Person Person { get; set; }
    }
}