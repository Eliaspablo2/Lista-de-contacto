using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lista_de_contactos
{
    internal class GestorDeContactos
    {
        static List<Contacto> Contactos = new List<Contacto>();
        static int ProximoId = 1;

        public static void agregar()
        {
            var contacto = new Contacto
            {
                ID = ProximoId++,
                Nombre = Utils.LeerString("Nombre: "),
                Telefono = Utils.LeerLong("Telefono: "),  // Cambiado a LeerLong
                Email = Utils.LeerString("Email: ")
            };
            Contactos.Add(contacto);
            Guardar();
            Console.WriteLine("Contacto agregado");
            Console.ReadKey();
        }

        public static void buscar()
        {
            string entrada = Utils.LeerString("Ingrese el nombre o teléfono del contacto: ");

            var resultados = Contactos.FindAll(c =>
                c.Nombre.Contains(entrada, StringComparison.OrdinalIgnoreCase) ||
                c.Telefono.ToString().Contains(entrada)
            );

            if (resultados.Count > 0)
            {
                foreach (var contacto in resultados)
                {
                    Console.WriteLine($@"
                        ID: {contacto.ID}
                        Nombre: {contacto.Nombre}
                        Telefono: {contacto.Telefono}
                        Email: {contacto.Email}
                    ");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron contactos.");
            }
            Console.ReadKey();
        }

        public static void lista()
        {
            Console.WriteLine("Listado de Contactos");
            foreach (var contacto in Contactos)
            {
                Console.WriteLine($@"
                    ID: {contacto.ID}
                    Nombre: {contacto.Nombre}
                    Telefono: {contacto.Telefono}
                    Email: {contacto.Email}
                ");
            }
            Console.ReadKey();
        }

        public static void Eliminar()
        {
            string entrada = Utils.LeerString("Ingrese el nombre o teléfono del contacto que desea eliminar: ");

            var contacto = Contactos.FirstOrDefault(c =>
                c.Nombre.Contains(entrada, StringComparison.OrdinalIgnoreCase) ||
                c.Telefono.ToString().Contains(entrada)
            );

            if (contacto != null)
            {
                Contactos.Remove(contacto);
                Guardar();
                Console.WriteLine("Contacto eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }
            Console.ReadKey();
        }

        public static void Guardar()
        {
            try
            {
                var json = JsonConvert.SerializeObject(Contactos);
                File.WriteAllText("Contacto.Json", json);
                Console.WriteLine("Datos guardados correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar los datos: " + ex.Message);
            }
        }

        public static void Cargar()
        {
            if (File.Exists("Contacto.Json"))
            {
                try
                {
                    var json = File.ReadAllText("Contacto.Json");
                    Contactos = JsonConvert.DeserializeObject<List<Contacto>>(json);
                    ProximoId = Contactos.Count > 0 ? Contactos.Max(c => c.ID) + 1 : 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al leer el archivo Contacto.Json: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("No existe el archivo Contacto.Json");
            }
            Console.ReadKey();
        }
    }
}
