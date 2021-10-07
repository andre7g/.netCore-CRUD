using System.ComponentModel.DataAnnotations;
namespace api_empresa.Models{
    public class Estados{
        [Key]
        public int Id {get;set;}
        public string Estado {get;set;}
    }
}