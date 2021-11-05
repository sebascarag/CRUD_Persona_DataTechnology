using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Persona_DataTechnology.Models.Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Correo")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Tipo de Documento de Identidad")]
        public int TypeDocumentId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Documento de Identidad")]
        public string Document { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public DateTime Birthday { get; set; }

        [ForeignKey("TypeDocumentId")]
        public virtual TypeDocument TypeDocument { get; set; }

    }
}
