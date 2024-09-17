using Application.Interfaces.Content.Monedas;
using Domain.Models;
using Infrastructure.Content.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Content.Services
{
    public class MonedaService : IMoneda
    {
        private readonly AppDbContext _context;

        public MonedaService(AppDbContext context)
        {
            _context = context;
        }

        #region GetAll
        public async Task<List<Moneda>> GetAll()
        {
            return await _context.Monedas
                  .AsNoTracking()
                .ToListAsync();
        }
        #endregion

        #region GetById
        public async Task<Moneda> GetById(int id)
        {
            return await _context.Monedas
              .FindAsync(id);
        }
        #endregion

        #region AddMoneda
        public async Task<Moneda> AddMoneda(Moneda model)
        {
            _context.Monedas.Add(model);

            _context.SaveChanges();

            return model;
        }
        #endregion

        #region UpdateMoneda
        public Moneda UpdateMoneda(Moneda model)
        {
            _context.Update(model);
            _context.SaveChanges();
            return model;
        }
        #endregion

        #region DeleteMoneda
        public Moneda DeleteMoneda(Moneda model)
        {
            _context.Remove(model);
            _context.SaveChanges();
            return model;
        }
        #endregion

        #region MonedaIsExist
        public async Task<bool> MonedaIsExist(string MonedaName)
        {
            return await _context.Monedas.AnyAsync(p => p.Nombre == MonedaName);
        }
        #endregion
    }
}
