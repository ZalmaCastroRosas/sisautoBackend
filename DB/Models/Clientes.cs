/*
 * DataAnnotaciones
 * Se poenen arriba del campo que se va a realizar la anotacion
 * [Requeried]-- Campo requerido 
 * [MinLength(2, ErrorMessage ="")]
 * [StringLength(10, MinimumLength=2)]--- Para que te establezca un maximo y un minimo
 * [EmailAddress]
 * [RegularExpression(@"^\+(52)\s?d{10}$")]---Expresion regular para telefono con lada de mexico
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    //IValidatableObject -- Validaciones personalizadas
    public class Clientes : IValidatableObject
    {    
        //Key es para decir que IDCliente va hacer una clave
        [Key]
        //Autonumerico
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID  { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        //llave foranea
        [ForeignKey ("PaisID")]
        public int PaisID { get; set; }
        //Clase virtual (Referenciar con la tabla Paises)
        //Que no sera requerido (?)
        public virtual Paises ?Pais { get; set; }

        //Validacion personalizada
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Forma negativa
            if (Nombre.Length < 2 || Nombre.Length > 10)
            {
                yield return new ValidationResult("La longitud del nombre tiene que estar entre 2 y 10", new[] {"Nombre"});
            }
        }
    }
}
