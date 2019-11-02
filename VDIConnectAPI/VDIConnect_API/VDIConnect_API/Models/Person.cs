using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VDIConnect_API.Models
{
    public class Person
    {
        /// <summary>
        /// Class de contruction d'un utilisateur
        /// </summary>
        [Key] public int Id { get; set; }
        public string Username { get; set; }
        [Required] public string Lastname { get; set; }
        [Required] public string Firstname { get; set; }
        [Required] public string Mail { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public bool AccountArchive { get; set; }
    }
}