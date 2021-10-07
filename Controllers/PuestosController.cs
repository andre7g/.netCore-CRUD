using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using api_empresa.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace api_empresa.Controllers{
    [Route("api/[controller]")]
    public class PuestosController : Controller{

        private Connection dbConnection;

        public PuestosController(){
            dbConnection = Conectar.Create();
        }

        [HttpGet]
        public async Task<ActionResult> Get(){
            IEnumerable<Puestos> Lista = await dbConnection.Puestos.ToListAsync();
            return Ok(Lista);
        }
    }
}