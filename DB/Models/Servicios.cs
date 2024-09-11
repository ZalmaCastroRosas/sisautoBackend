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
    public class Servicios
    {
        //Key es para decir que IDCliente va hacer una clave
        [Key]
        //Autonumerico
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicioID { get; set; }
        public string NombreServicio { get; set; }
        public string DescripcionServicio { get; set; }
        public decimal Costo { get; set; }
    }
}
