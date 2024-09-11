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
    public class OrdenesRepository : IRepository<Ordenes>
    {
        //Inyeccion de dependencias (_context)
        private readonly SisautoContext _context;
        public OrdenesRepository(SisautoContext context)
        {
            _context = context;
        }

        public async Task<Ordenes> Create(Ordenes entity)
        {
            _context.Ordenes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Ordenes> Delete(int id)
        {
            var entity = await _context.Ordenes.FindAsync(id);
            if (entity != null)
            {
                _context.Ordenes.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<List<Ordenes>> GetAll()
        {
            //Devuelve una lista asincrona
            return await _context.Ordenes.ToListAsync();
        }

        public async Task<Ordenes> GetById(int id)
        {
            //Ejemplo:1
            //Obtener la orden que se manda en el parametro de la funcion
            //var orden = await _context.Ordenes
            //    .Where(o => o.OrdenID == id)
            //    .FirstOrDefaultAsync();
            ////Verificar si el valor que se esta mandando es nulo o no
            //if (orden != null)
            //{
            //    //Para que me devuelva solo un elemento
            //    await _context.Entry(orden).Reference(o => o.Cliente).LoadAsync();

            //}
            //return orden;

            //Ejemplo:2
            //LinQ
            var orden = await _context.Ordenes
                .Include(c => c.Cliente)
                .Include(dt => dt.DetalleOrdenes)
                    //Entonces incluye (recibe el objeto de detalle de ordenes)
                    .ThenInclude(d => d.Servicio)
                .Where(o => o.OrdenID == id)
                .FirstOrDefaultAsync();

            return orden;

        }

        public async Task<Ordenes> Update(Ordenes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
