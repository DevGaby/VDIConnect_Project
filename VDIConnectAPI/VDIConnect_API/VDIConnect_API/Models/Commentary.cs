using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VDIConnect_API.Models
{
    public class Commentary
    {
        [Key] public int Id { get; set; }
        /// <summary>
        /// Date d'écriture du commentaire
        /// </summary>
        [Required] public DateTime? DateCreate { get; set; }

        /// <summary>
        /// Contenu du commentaire
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Nom de rédacteur du commentaire
        /// </summary>
        [Required] public string Sender { get; set; }

        /// <summary>
        /// Type de commentaire
        /// </summary>
        public int? TypeCommentaireId { get; set; }

        [ForeignKey("TypeCommentaireId")]
        public TypeCommentary TypeCommentary { get; set; }
        public int IdEvent { get; set; }
        [ForeignKey("IdEvent")]
        public Event Event { get; set; }
    }
}