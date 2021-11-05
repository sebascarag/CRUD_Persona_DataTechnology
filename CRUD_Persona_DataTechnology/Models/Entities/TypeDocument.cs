using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Persona_DataTechnology.Models.Entities
{
    public class TypeDocument
    {
        public int TypeDocumentId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tipo de Documento")]
        public string Name { get; set; }
    }
}
