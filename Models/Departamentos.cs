using System.ComponentModel.DataAnnotations;
namespace api_empresa.Models{
    public class Departamentos{
        [Key]
        public int Id {get;set;}
        public string Departamento {get;set;}
        public int Estados_Id {get;set;}
    }
}