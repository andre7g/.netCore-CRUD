using System.ComponentModel.DataAnnotations;
namespace api_empresa.Models{
    public class Puestos{
        [Key]
        public int Id {get;set;}
        public string Puesto {get;set;}
        public string Descripcion {get;set;}
        public int Estados_Id {get;set;}
    }
}