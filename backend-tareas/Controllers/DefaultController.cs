using Microsoft.AspNetCore.Mvc;

namespace backend_tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET: api/<DefaultController>
        [HttpGet]
        public string Get()
        {
            return "Aplicación corriendo";
        }        
    }
}
