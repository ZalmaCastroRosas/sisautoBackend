using DB.Models;
using Repository;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DetalleOrdenesService : IService<DetalleOrdenes>
    {
        //Inyeccion de dependencias
        private readonly DetalleOrdenesRepository _detalleOrdenesRepository;
        public DetalleOrdenesService(DetalleOrdenesRepository detalleOrdenesrepository)
        {
            _detalleOrdenesRepository = detalleOrdenesrepository;
        }
        public async Task<DetalleOrdenes> Create(DetalleOrdenes entity)
        {
            return await _detalleOrdenesRepository.Create(entity);
        }

        public async Task<DetalleOrdenes> Delete(int id)
        {
            return await _detalleOrdenesRepository.Delete(id);
        }

        public async Task<List<DetalleOrdenes>> GetAll()
        {
            return await _detalleOrdenesRepository.GetAll();
        }

        public async Task<DetalleOrdenes> GetById(int id)
        {
            return await _detalleOrdenesRepository.GetById(id);
        }

        public async Task<DetalleOrdenes> Update(DetalleOrdenes entity)
        {
            return await _detalleOrdenesRepository.Update(entity);
        }
    }
}
