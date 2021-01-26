using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEmpleado.Models;

namespace WebEmpleado.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {

        private readonly EmployeCtx _context;
        
        public EmployesController(EmployeCtx context)
        {
            _context = context;
        }
        //instruccion para que el controller acepte más de un Get
        [AcceptVerbs("GET")]
        //Primer Get que se ejecuta cuando complilamos la aplicación    
        [HttpGet]
        public string GetHello(string H)
        {
            return "     HOLA MUNDO     ";
        }

       
        //Metodo que mostrará el empleado filtrando por id 

        [HttpGet("{id}")]

        public async Task<ActionResult<Employe>> GetEmploye(int id)
        {
            var employe = await _context.Employe.FindAsync(id);
            if (employe == null)
            {
                return NotFound();

            }
            return employe;
        }
        private bool EmployeExists(int id)
        {
            return _context.Employe.Any(e => e.id == id);
        }
        [HttpGet]
        [Route("api/[controller]/n")]
        public async Task<ActionResult<IEnumerable<Employe>>> GetEmployes()
        {
            return await _context.Employe.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<Employe>> PostEmploye(Employe employe)
        {
            _context.Employe.Add(employe);
            await _context.SaveChangesAsync();
           return CreatedAtAction("GetEmploye", new { id = employe.id }, employe);

        }


        // Método que actualiza todo el registro/campo filtrando por id 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploye(int id, Employe employe)
        {
            if (!EmployeExists(id))
            {
                return BadRequest();
            }
            _context.Entry(employe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (id != employe.id)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //Medodo que borra el registro filtrando por id 
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employe>> DeleteEmploye(int id)
        {

            var employe = await _context.Employe.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            _context.Employe.Remove(employe);
            await _context.SaveChangesAsync();
            return employe;
        }
       
        }
    }

    

