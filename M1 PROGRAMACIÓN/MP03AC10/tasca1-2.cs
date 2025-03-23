
// internal class Program
// {
//     static int opcionSeleccionada = 0;
//     static List<string> mensajesAlmacenados = new List<string>();

//     private static void Main(string[] args)
//     {
//         do
//         {
//             MostrarMenu();

//             switch (opcionSeleccionada)
//             {
//                 case 1:
//                     AgregarMensajeLocal();
//                     break;

//                 case 2:
//                     MostrarUsuarios();
//                     break;

//                 case 3:
//                     MostrarMensajeLocal();
//                     break;

//                 case 4:
//                     MostrarTodosLosMensajes();
//                     break;

//                 case 5:
//                     GuardarMensajesEnArchivo();
//                     break;

//                 case 6:
//                     LeerMensajesDesdeArchivo();
//                     break;
//             }
//         } while (opcionSeleccionada != 7);
//     }

//     static void MostrarMenu()
//     {
//         Console.WriteLine("Selecciona una opción:");
//         Console.WriteLine("1 - Agregar mensaje local");
//         Console.WriteLine("2 - Mostrar todos los usuarios");
//         Console.WriteLine("3 - Ver un mensaje local");
//         Console.WriteLine("4 - Mostrar todos los mensajes locales");
//         Console.WriteLine("5 - Guardar mensajes locales en archivo");
//         Console.WriteLine("6 - Leer mensajes desde archivo");
//         Console.WriteLine("7 - Salir");
//         opcionSeleccionada = Convert.ToInt32(Console.ReadLine());
//     }

//     private static void AgregarMensajeLocal()
//     {
//         Console.Write("Nombre del usuario: ");
//         string usuario = Console.ReadLine();

//         Console.Write("Asunto: ");
//         string asunto = Console.ReadLine();

//         Console.Write("Mensaje: ");
//         string contenidoMensaje = Console.ReadLine();

//         string mensajeCompleto = $"{usuario};{asunto};{contenidoMensaje}";
//         mensajesAlmacenados.Add(mensajeCompleto);
//     }

//     private static void MostrarUsuarios()
//     {
//     }

//     private static void MostrarMensajeLocal()
//     {
//     }

//     private static void MostrarTodosLosMensajes()
//     {
//         foreach (var mensaje in mensajesAlmacenados)
//         {
//             Console.WriteLine(mensaje);
//         }
//     }

//     private static void GuardarMensajesEnArchivo()
//     {
//         StreamWriter archivo = new StreamWriter("mensajes_guardados.txt", true);
//         foreach (var mensaje in mensajesAlmacenados)
//         {
//             archivo.WriteLine(mensaje);
//         }
//         archivo.Close();
//     }

//     private static void LeerMensajesDesdeArchivo()
//     {
//         StreamReader archivo = new StreamReader("mensajes_guardados.txt");

//         bool continuarLeyendo = true;

//         while (continuarLeyendo)
//         {
//             string linea = archivo.ReadLine();
//             if (linea != null && linea != "")
//             {
//                 Console.WriteLine(linea);
//             }
//             else
//             {
//                 continuarLeyendo = false;
//             }
//         }

//         archivo.Close();
//     }
// }



internal class Biblioteca
{
    static int opcionUsuario;

    static void Main()
    {
        do
        {
            string archivoLibros = "catalogo.txt";

            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1 - Registrar un libro");
            Console.WriteLine("2 - Registrar varios libros");
            Console.WriteLine("3 - Ver todos los libros");
            Console.WriteLine("4 - Salir");

            opcionUsuario = Convert.ToInt32(Console.ReadLine());

            switch (opcionUsuario)
            {
                case 1:
                    RegistrarUnLibro(archivoLibros);
                    break;

                case 2:
                    RegistrarVariosLibros(archivoLibros);
                    break;

                case 3:
                    MostrarLibros(archivoLibros);
                    break;
            }
        } while (opcionUsuario != 4);
    }

    private static void RegistrarUnLibro(string archivo)
    {
        Console.WriteLine("Ingrese el título del libro: ");
        string nombreLibro = Console.ReadLine();
        Console.WriteLine("Ingrese el autor del libro: ");
        string autorLibro = Console.ReadLine();
        Console.WriteLine("Ingrese el código ISBN del libro: ");
        string codigoIsbn = Console.ReadLine();

        StreamWriter catalogo = new StreamWriter(archivo, true);

        catalogo.WriteLine("{0};{1};{2}", nombreLibro, autorLibro, codigoIsbn);

        catalogo.Close();
    }

    private static void RegistrarVariosLibros(string archivo)
    {
        Console.WriteLine("¿Cuántos libros desea registrar?");
        int cantidadLibros = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < cantidadLibros; i++)
        {
            Console.WriteLine("Ingrese el título del libro: ");
            string nombreLibro = Console.ReadLine();
            Console.WriteLine("Ingrese el autor del libro: ");
            string autorLibro = Console.ReadLine();
            Console.WriteLine("Ingrese el código ISBN del libro: ");
            string codigoIsbn = Console.ReadLine();

            StreamWriter catalogo = new StreamWriter(archivo, true);

            catalogo.WriteLine("{0};{1};{2}", nombreLibro, autorLibro, codigoIsbn);
            catalogo.Close();
        }
    }

    private static void MostrarLibros(string archivo)
    {
        List<string> listaLibros = new List<string>();

        StreamReader catalogo = new StreamReader(archivo);

        string lineaLibro;

        while ((lineaLibro = catalogo.ReadLine()) != null)
        {
            listaLibros.Add(lineaLibro);
        }
        catalogo.Close();

        foreach (string libro in listaLibros)
        {
            string[] datosLibro = libro.Split(';');

            Console.WriteLine($"Título: {datosLibro[0]}");
            Console.WriteLine($"Autor: {datosLibro[1]}");
            Console.WriteLine($"ISBN: {datosLibro[2]}");
        }
    }
}
