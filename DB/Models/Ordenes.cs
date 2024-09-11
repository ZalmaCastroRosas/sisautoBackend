using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DB.Models
{
    public class Ordenes
    {
        //Key es para decir que IDCliente va hacer una clave
        [Key]
        //Autonumerico
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdenID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        //Esta orden pertenece a un cliente
        public virtual Clientes Cliente { get; set; }
        //DEvuelve lista de los detalles de las ordenes
        public virtual ICollection<DetalleOrdenes> DetalleOrdenes { get; set; }

    }
}
