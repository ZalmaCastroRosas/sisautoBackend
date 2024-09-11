using DB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    //Cuando se utiliza un servidor de identidad ya no se utiliza el DbContext, ahora es un IdentityDbContext
    public class SisautoContext : IdentityDbContext
    {
        //Construir un constructor -ctor
        //Llamar a las opciones que va a recibir el contexto y que se manden como parametro 
        public SisautoContext(DbContextOptions<SisautoContext> options)
            //llamar a la base con las opciones
            : base(options) { }

        //Enlazar cada modelo con una tabla, DbSet (este modelo quiero que se convierta en una tabla de la base de datos)
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<DetalleOrdenes> DetalleOrdenes { get;set; }
    }
}
