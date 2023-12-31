using GardenAppV1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GardenAppV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorTemperaturaController : ControllerBase
    {
        private readonly DBGARDENAPPV1Context _DBContext;

        public SensorTemperaturaController(DBGARDENAPPV1Context context)
        {
            _DBContext = context;
        }

        [HttpGet]
        [Route("GetAllSensorTemperatura")]
        public async Task<IActionResult> GetAllSensorTemperatura()
        {
            List<Sensortemperatura> lista = await _DBContext.Sensortemperaturas.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }
    }

}
