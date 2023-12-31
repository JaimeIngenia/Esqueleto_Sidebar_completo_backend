using GardenAppV1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GardenAppV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JardinController : ControllerBase
    {
        private readonly DBGARDENAPPV1Context _DBContext;

        public JardinController(DBGARDENAPPV1Context context)
        {
            _DBContext = context;
        }

        //[HttpGet]
        //[Route("GetAllJardines")]
        //public async Task<IActionResult> GetAllJardines()
        //{
        //    List<Jardin> lista = await _DBContext.Jardins.ToListAsync();
        //    return StatusCode(StatusCodes.Status200OK, lista);
        //}
        [HttpGet]
        [Route("GetAllJardines")]
        public async Task<IActionResult> GetAllJardines()
        {
            List<Jardin> lista = await _DBContext.Jardins.ToListAsync();

            // Agregar encabezados CORS
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        // Controlador para editar
        [HttpPut]
        [Route("EditarJardin/{id}")]
        public async Task<IActionResult> EditarJardin(int id, [FromBody] Jardin jardinActualizado)
        {
            // Buscar la película por ID en la base de datos
            var jardinExistente = await _DBContext.Jardins.FindAsync(id);

            // Verificar si la película existe
            if (jardinExistente == null)
            {
                return NotFound(); // Devolver 404 si el jardin no se encuentra
            }

            // Actualizar los campos de la película existente con la información proporcionada
            jardinExistente.CreatedAt = jardinActualizado.CreatedAt;
            jardinExistente.ValorSensor = jardinActualizado.ValorSensor;
            jardinExistente.SensorId = jardinActualizado.SensorId;


            // Guardar los cambios en la base de datos
            await _DBContext.SaveChangesAsync();

            return Ok(jardinExistente); // Devolver la película actualizada
        }

        // Controlador para eliminar
        [HttpDelete]
        [Route("EliminarJardin/{id}")]
        public async Task<IActionResult> EliminarJardin(int id)
        {
            // Buscar la película por ID en la base de datos
            var jardinExistente = await _DBContext.Jardins.FindAsync(id);

            // Verificar si la película existe
            if (jardinExistente == null)
            {
                return NotFound(); // Devolver 404 si la película no se encuentra
            }

            // Eliminar la película de la base de datos
            _DBContext.Jardins.Remove(jardinExistente);
            await _DBContext.SaveChangesAsync();

            return Ok("El Jardín ha sido eliminada exitosamente");
        }


        // Controlador para Agregar
        [HttpPost]
        [Route("GuardarJardin")]
        public async Task<IActionResult> GuardarJardin([FromBody] Jardin request)
        {
            await _DBContext.Jardins.AddAsync(request);
            await _DBContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "OK");
        }




    }
}
