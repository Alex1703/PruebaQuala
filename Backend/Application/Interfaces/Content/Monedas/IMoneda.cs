using Domain.Models;

namespace Application.Interfaces.Content.Monedas
{
    public interface IMoneda
    {
        Task<List<Moneda>> GetAll();

        Task<Moneda> GetById(int id);


        Task<Moneda> AddMoneda(Moneda model);


        Moneda UpdateMoneda(Moneda model);



        Moneda DeleteMoneda(Moneda model);

        Task<bool> MonedaIsExist(string MonedaName);
    }
}
