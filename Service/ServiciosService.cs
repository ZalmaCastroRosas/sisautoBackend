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
    public class ServiciosService : IService<Servicios>
    {
        //Inyeccion de dependencias
        private readonly ServiciosRepository _serviciosRepository;
        public ServiciosService(ServiciosRepository serviciosrepository)
        {
            _serviciosRepository = serviciosrepository;
        }
        public async Task<Servicios> Create(Servicios entity)
        {
            return await _serviciosRepository.Create(entity);
        }

        public async Task<Servicios> Delete(int id)
        {
            return await _serviciosRepository.Delete(id);
        }

        public async Task<List<Servicios>> GetAll()
        {
            return await _serviciosRepository.GetAll();
        }

        public async Task<Servicios> GetById(int id)
        {
            return await _serviciosRepository.GetById(id);
        }

        public async Task<Servicios> Update(Servicios entity)
        {
            return await _serviciosRepository.Update(entity);
        }
    }
}
