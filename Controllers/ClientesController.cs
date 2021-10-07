using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using api_empresa.Models;

namespace api_empresa.Controllers{
    [Route("api/[controller]")]
    public class ClientesController : Controller{

        private Connection dbConnection;

        public ClientesController(){
            dbConnection = Conectar.Create();
        }

        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConnection.Clientes.ToArray());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id){
            var clinetes = await dbConnection.Clientes.FindAsync(id);
            if(clinetes != null){
                return Ok(clinetes);
            }else{
                return NotFound();
            }
            
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Clientes _clientes ){
            if(ModelState.IsValid){
                dbConnection.Clientes.Add(_clientes);
                await dbConnection.SaveChangesAsync();
                return Ok();
            }
            else{
                return BadRequest();
            }
            
        }
        //https://localhost:5001/api/Clientes/Update/id
        [HttpPut]
        [Route("Update/{put_Id?}")]
        public async Task<ActionResult> Put(int put_Id,[FromBody] Clientes _clientes ){
            var v_clientes = dbConnection.Clientes.SingleOrDefault(x => x.id == put_Id);
            _clientes.id = put_Id;

            if(v_clientes != null){
                dbConnection.Entry(v_clientes).CurrentValues.SetValues(_clientes);
                await dbConnection.SaveChangesAsync();
                return Ok();
            }
            else{
                return BadRequest();
            }
            
        }
        //crud de empleados lleva puestos para hacer el ddl
        //https://localhost:5001/api/Clientes/Delete/id
        [HttpDelete]
        [Route("Delete/{put_Id?}")]
        public async Task<ActionResult> Delete(int put_Id) {
            var v_clientes = dbConnection.Clientes.SingleOrDefault(x => x.id == put_Id);
            if(v_clientes != null){
                dbConnection.Clientes.Remove(v_clientes);
                await dbConnection.SaveChangesAsync();
                return Ok();
            }
            else{
                return BadRequest();
            }
        }

    }
}