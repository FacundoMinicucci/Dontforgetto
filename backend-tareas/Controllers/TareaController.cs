using backend_tareas.Context;
using backend_tareas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace backend_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TareaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listTareas = await _context.Tareas.ToListAsync();

                return Ok(listTareas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            try
            {
                _context.Tareas.Add(tarea);

                await _context.SaveChangesAsync();

                return Ok("¡La tarea fue registrada con éxito!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tarea tarea)
        {
            // Recibe la tarea en su estado actual y le cambia su estado.
            try
            {            
                if (id != tarea.Id)
                {
                    return NotFound("No se encontró la tarea solicitada.");
                }

                tarea.Estado = !tarea.Estado;

                _context.Update(tarea);                

                await _context.SaveChangesAsync();

                return Ok("La tarea fue actualizada con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);   
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarea = await _context.Tareas.FindAsync(id);

                if (tarea == null) return NotFound("La tarea ingresada no existe.");

                _context.Tareas.Remove(tarea);

                await _context.SaveChangesAsync();

                return Ok("¡Tarea eliminada exitosamente!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
