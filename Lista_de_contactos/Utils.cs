using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_de_contactos
{
    internal class Utils
    {
        public static string LeerString(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        public static long LeerLong(string mensaje)  // Cambiado a long
        {
            long resultado;
            while (true)
            {
                Console.Write(mensaje);
                if (long.TryParse(Console.ReadLine(), out resultado))
                    break;
                else
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero largo.");
            }
            return resultado;
        }
    }
}
