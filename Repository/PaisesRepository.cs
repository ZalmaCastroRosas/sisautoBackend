/*En esta capa es el guardado de los datos*/
using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Repository.interfaces;

namespace Repository
{
    //Implementar los metodos de la interfaz
    public class PaisesRepository : IRepository<Paises>
    {
        //Inyeccion de dependencias (_context)
        private readonly SisautoContext _context;
        public PaisesRepository(SisautoContext context)
        {
            _context = context;
        }

        public async Task<Paises> Create(Paises entity)
        {
            _context.Paises.Add(entity);
            await _context.SaveChangesAsync();
            return  entity;
        }

        public async Task<Paises> Delete(int id)
        {
            var entity = await _context.Paises.FindAsync(id);
            if (entity != null)
            {
                _context.Paises.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<List<Paises>> GetAll()
        {
            //Devuelve una lista asincrona
            return await _context.Paises.ToListAsync();
        }

        public  async Task<Paises> GetById(int id)
        {
            return await _context.Paises.FindAsync(id);
        }

        public async Task<Paises> Update(Paises entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
