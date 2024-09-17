using Application.Interfaces.Content.Monedas;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace QualaSucursalAPI.Controllers.Content
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : Controller
    {
        private readonly IMoneda _MonedaService;

        public MonedaController(IMoneda MonedaService)
        {
            _MonedaService = MonedaService;
        }

        #region Get All Monedas Endpoint
        // GET: MonedasController
        [HttpGet("GET_ALLMonedas")]
        public async Task<IActionResult> GetAllMonedas()
        {
            var categries = await _MonedaService.GetAll();
            if (categries is null)
                return NotFound("No data here!");
            return Ok(categries);
        }
        #endregion

        #region Get Moneda Endpoint
        // GET: MonedasController/Details/5
        [HttpGet("GET_Moneda")]
        public async Task<ActionResult> Details(int id)
        {
            var Moneda = await _MonedaService.GetById(id);

            if (Moneda == null)
                return NotFound($"No Moneda has found with this {id} ");

            return Ok(Moneda);
        }
        #endregion

        #region Create Moneda Endpoint
        // POST: MonedasController/Create
        [HttpPost("Add_NewMoneda")]
        public async Task<IActionResult> CreateMoneda([FromQuery] Moneda model)
        {
            if (ModelState.IsValid is false)
            {
                return BadRequest("Invalid Inputs");
            }

            if (await _MonedaService.MonedaIsExist(model.Nombre))
                return BadRequest(" this Moneda name is already registred");

            var moneda = new Moneda
            {
                Nombre = model.Nombre,
            };

            _MonedaService.AddMoneda(moneda);

            return Ok(await _MonedaService.GetAll());
        }
        #endregion

        #region Update Moneda
        // POST: MonedasController/Edit/5
        [HttpPut("Edit_Moneda")]
        public async Task<IActionResult> UpdateMoneda(int id, Moneda model)
        {
            var Moneda = await _MonedaService.GetById(id);

            if (Moneda == null)
                return NotFound($"No Moneda was found with ID {id}");

            if (await _MonedaService.MonedaIsExist(model.Nombre))
                return BadRequest(" this Moneda name is already registred");

            Moneda.Nombre = model.Nombre;

            _MonedaService.UpdateMoneda(Moneda);

            return Ok(Moneda);
        }
        #endregion

        #region Delete Moneda
        // POST: MonedasController/Delete/5
        [HttpDelete("Delete_Moneda")]
        public async Task<IActionResult> Delete(int id)
        {
            var Moneda = await _MonedaService.GetById(id);

            if (Moneda == null)
                return NotFound($"No Ctegory was found with ID {id}");

            _MonedaService.DeleteMoneda(Moneda);

            return Ok($"Moneda : {Moneda.Nombre} with Id : ({Moneda.Id}) is deleted");
        }
        #endregion
    }
}
