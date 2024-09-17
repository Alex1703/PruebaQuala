using Application.Interfaces.Content.Sucursales;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace QualaSucursalAPI.Controllers.Content
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : Controller
    {

        private readonly ISucursal _SucursalService;

        public SucursalController(ISucursal SucursalService)
        {
            _SucursalService = SucursalService;
        }

        #region Get All Sucursales Endpoint
        // GET: SucursalesController
        [HttpGet("GET_ALLSucursales")]
        public async Task<IActionResult> GetAllSucursales()
        {
            var categries = await _SucursalService.GetAll();
            if (categries is null)
                return NotFound("No data here!");
            return Ok(categries);
        }
        #endregion

        #region Get Sucursal Endpoint
        // GET: SucursalesController/Details/5
        [HttpGet("GET_Sucursal")]
        public async Task<ActionResult> Details(int id)
        {
            var Sucursal = await _SucursalService.GetById(id);

            if (Sucursal == null)
                return NotFound($"No Sucursal has found with this {id} ");

            return Ok(Sucursal);
        }
        #endregion

        #region Create Sucursal Endpoint
        // POST: SucursalesController/Create
        [HttpPost("Add_NewSucursal")]
        public async Task<IActionResult> CreateSucursal([FromQuery] Sucursal model)
        {
            if (ModelState.IsValid is false)
            {
                return BadRequest("Invalid Inputs");
            }

            if (await _SucursalService.SucursalIsExist(model.Identificacion))
                return BadRequest(" this Sucursal name is already registred");

            var Sucursal = new Sucursal
            {
                Codigo = model.Codigo,
                Identificacion = model.Identificacion,
                Descripcion= model.Descripcion, 
                Direccion=model.Direccion,
                FechaCreacion=model.FechaCreacion,
                Moneda= model.Moneda,  
                MonedaId = model.MonedaId
            };

            _SucursalService.AddSucursal(Sucursal);

            return Ok(await _SucursalService.GetAll());
        }
        #endregion

        #region Update Sucursal
        // POST: SucursalesController/Edit/5
        [HttpPut("Edit_Sucursal")]
        public async Task<IActionResult> UpdateSucursal(int id, Sucursal model)
        {
            var Sucursal = await _SucursalService.GetById(id);

            if (Sucursal == null)
                return NotFound($"No Sucursal was found with ID {id}");

            if (await _SucursalService.SucursalIsExist(model.Identificacion))
                return BadRequest(" this Sucursal name is already registred");

            Sucursal.Identificacion = model.Identificacion;

            _SucursalService.UpdateSucursal(Sucursal);

            return Ok(Sucursal);
        }
        #endregion

        #region Delete Sucursal
        // POST: SucursalesController/Delete/5
        [HttpDelete("Delete_Sucursal")]
        public async Task<IActionResult> Delete(int id)
        {
            var Sucursal = await _SucursalService.GetById(id);

            if (Sucursal == null)
                return NotFound($"No Ctegory was found with ID {id}");

            _SucursalService.DeleteSucursal(Sucursal);

            return Ok($"Sucursal : {Sucursal.Identificacion} with Id : ({Sucursal.Id}) is deleted");
        }
        #endregion

    }


}
