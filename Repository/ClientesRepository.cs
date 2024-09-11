using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientesRepository : IRepository<Clientes>
    {
        //Inyeccion de dependencias (_context)
        private readonly SisautoContext _context;
        public ClientesRepository(SisautoContext context)
        {
            _context = context;
        }

        public async Task<Clientes> Create(Clientes entity)
        {
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Clientes> Delete(int id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            if (entity != null)
            {
                _context.Clientes.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<List<Clientes>> GetAll()
        {
            //Devuelve una lista asincrona
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Clientes> Update(Clientes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
