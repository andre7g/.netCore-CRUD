using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using api_empresa.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api_empresa.Controllers{
    [Route("api/[controller]")]
    public class EmpleadosController : Controller{

        private Connection dbConnection;

        public EmpleadosController(){
            dbConnection = Conectar.Create();
        }

        [HttpGet]
        public async Task<ActionResult> Get(){
            IEnumerable<Empleados> Lista = await dbConnection.Empleados.Include(x => x.Puestos).Include(x => x.Departamentos).Include(x => x.Estados).ToListAsync();
            return Ok(Lista);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id){
            var empleados = await dbConnection.Empleados.FindAsync(id);
            if(empleados != null){
                return Ok(empleados);
            }else{
                return NotFound();
            }
            
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Empleados _empleados ){
            if(ModelState.IsValid){
                dbConnection.Empleados.Add(_empleados);
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
        public async Task<ActionResult> Put(int put_Id,[FromBody] Empleados _empleados ){
            var v_empleados = dbConnection.Empleados.SingleOrDefault(x => x.Id == put_Id);
            _empleados.Id = put_Id;

            if(v_empleados != null){
                dbConnection.Entry(v_empleados).CurrentValues.SetValues(_empleados);
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
            var v_empleados = dbConnection.Empleados.SingleOrDefault(x => x.Id == put_Id);
            if(v_empleados != null){
                dbConnection.Empleados.Remove(v_empleados);
                await dbConnection.SaveChangesAsync();
                return Ok();
            }
            else{
                return BadRequest();
            }
        }

    }
}