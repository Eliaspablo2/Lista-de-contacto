using Lista_de_contactos;
using System.Collections;

bool inicio = true;
Console.Clear();

while (inicio)
{
    Console.Clear();
    Console.WriteLine(@"Menú de Contactos:
        1. Agregar contacto
        2. Buscar contacto
        3. Listar contactos
        4. Eliminar contacto
        5. Guardar contactos
        6. Cargar contactos
        7. Salir
    ");

    string opcion = Console.ReadLine();

    switch (opcion.ToLower())
    {
        case "1":
            GestorDeContactos.agregar();
        break;

        case "2":
            GestorDeContactos.buscar();
        break;

        case "3":
            GestorDeContactos.lista();
        break;

        case "4":
            GestorDeContactos.Eliminar();
        break;

        case "5":
            GestorDeContactos.Guardar();
        break;

        case "6":
            GestorDeContactos.Cargar();
        break;

        case "7":
            Console.WriteLine("Gracias Por Utilizar esta App");
            inicio = false;
        break;

        default:
            Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
            Console.ReadKey();
        break;
    }
    
};
