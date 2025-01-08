using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFDI.API.v2.ModelsV4;

namespace ProyectoFDI.API.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VistaResultadosBloqueMixtoController : ControllerBase
    {
        private readonly ProyectoFdiV2Context _context;

        public VistaResultadosBloqueMixtoController(ProyectoFdiV2Context context)
        {
            _context = context;
        }

        // GET: api/VistaResultadosBloqueMixto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VistaResultadosBloqueMixto>>> GetVistaResultadosBloqueMixto()
        {
            if (_context.VistaResultadosBloqueMixtos == null)
            {
                return NotFound();
            }
            return await _context.VistaResultadosBloqueMixtos.ToListAsync();
        }

 

    }
}
