using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lista_de_contactos
{
    public class Contacto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
    }

}
