using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Content.Sucursales
{
    public interface ISucursal
    {
        Task<List<Sucursal>> GetAll();

        Task<Sucursal> GetById(int id);


        Task<Sucursal> AddSucursal(Sucursal model);


        Sucursal UpdateSucursal(Sucursal model);



        Sucursal DeleteSucursal(Sucursal model);

        Task<bool> SucursalIsExist(string Identificacion);
    }
}
