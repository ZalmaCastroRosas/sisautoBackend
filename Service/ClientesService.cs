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
    public class ClientesService : IService<Clientes>
    {
        //Inyeccion de dependencias
        private readonly ClientesRepository _clientesRepository;
        public ClientesService(ClientesRepository clientesrepository)
        {
            _clientesRepository = clientesrepository;
        }
        public async Task<Clientes> Create(Clientes entity)
        {
            return await _clientesRepository.Create(entity);
        }

        public async Task<Clientes> Delete(int id)
        {
            return await _clientesRepository.Delete(id);
        }

        public async Task<List<Clientes>> GetAll()
        {
            return await _clientesRepository.GetAll();
        }

        public async Task<Clientes> GetById(int id)
        {
            return await _clientesRepository.GetById(id);
        }

        public async Task<Clientes> Update(Clientes entity)
        {
            return await _clientesRepository.Update(entity);
        }
    }
}
