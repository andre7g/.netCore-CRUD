using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_empresa.Models{
    public class Empleados{
        [Key]
        public int Id {get;set;}
        public string Primer_Nombre {get;set;}
        public string Segundo_Nombre {get;set;}
        public string Primer_Apellido {get;set;}
        public string Segundo_Apellido {get;set;}

        public int Puestos_Id {get;set;}
        [ForeignKey("Puestos_Id")]
        public virtual Puestos Puestos { get; set; }

        public int Departamentos_Id {get;set;}
        [ForeignKey("Departamentos_Id")]
        public virtual Departamentos Departamentos { get; set; }

        public string Fecha_Nacimiento { get; set; }

        public int Estados_Id {get;set;}
        [ForeignKey("Estados_Id")]
        public virtual Estados Estados { get; set; }

        public string Nit {get;set;}
        public string Direccion {get;set;}
        public string Telefono {get;set;}
    }
}













