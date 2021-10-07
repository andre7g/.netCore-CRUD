using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using api_empresa.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace api_empresa.Controllers{
    [Route("api/[controller]")]
    public class DepartamentosController : Controller{

        private Connection dbConnection;

        public DepartamentosController(){
            dbConnection = Conectar.Create();
        }

        [HttpGet]
        public async Task<ActionResult> Get(){
            IEnumerable<Departamentos> Lista = await dbConnection.Departamentos.ToListAsync();
            return Ok(Lista);
        }
    }
}