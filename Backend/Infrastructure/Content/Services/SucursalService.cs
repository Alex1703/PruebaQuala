using Application.Interfaces.Content.Sucursales;
using Domain.Models;
using Infrastructure.Content.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Content.Services
{
    public class SucursalService : ISucursal
    {
        private readonly AppDbContext _context;

        public SucursalService(AppDbContext context)
        {
            _context = context;
        }

        #region GetAll
        public async Task<List<Sucursal>> GetAll()
        {
            return await _context.Sucursals
                  .AsNoTracking()
                .ToListAsync();
        }
        #endregion

        #region GetById
        public async Task<Sucursal> GetById(int id)
        {
            return await _context.Sucursals
              .FindAsync(id);
        }
        #endregion

        #region AddSucursal
        public async Task<Sucursal> AddSucursal(Sucursal model)
        {
            _context.Sucursals.Add(model);

            _context.SaveChanges();

            return model;
        }
        #endregion

        #region UpdateSucursal
        public Sucursal UpdateSucursal(Sucursal model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }
        #endregion

        #region DeleteSucursal
        public Sucursal DeleteSucursal(Sucursal model)
        {
            _context.Remove(model);
            _context.SaveChanges();
            return model;
        }
        #endregion

        #region SucursalIsExist
        public async Task<bool> SucursalIsExist(string Identificacion)
        {
            return await _context.Sucursals.AnyAsync(p => p.Identificacion == Identificacion);
        }
        #endregion
    }
}
