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
    public class Paises
    {
        //Key es para decir que IDCliente va hacer una clave
        [Key]
        //Autonumerico
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaisID { get; set; }
        public string Nombre { get; set; }
        [JsonIgnore]//Ya no se va a incluir en el json 
        //Clase virtual (Referenciar a la tabla de Clientes)
        //Que no sera requerido (?)
        public virtual ICollection<Clientes> ?Clientes { get; set; }
    }
}
