using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto___Metrovia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,string>>conductores=new Dictionary<string,Dictionary<string,string>>();
            Dictionary<string,Dictionary<string,string>>usuarios=new Dictionary<string,Dictionary<string,string>>();

            int opcion;

            do
            {
                Console.WriteLine("\n--- Proyecto 01 - Sistema Metrovia ---");
                Console.WriteLine("1. Agregar Conductor");
                Console.WriteLine("2. Buscar Conductor");
                Console.WriteLine("3. Agregar Usuario");
                Console.WriteLine("4. Buscar Usuario");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarConductor(conductores); 
                            break;
                        case 2:
                            BuscarConductor(conductores);
                            break;
                        case 3:
                            AgregarUsuario(usuarios);
                            break;
                        case 4:
                            BuscarUsuario(usuarios);
                            break;
                        case 5:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Error: Intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Error: ingrese un número.");
                }

            } while (opcion != 5);
        }

        public static void AgregarConductor(Dictionary<string,Dictionary<string,string>> conductores)
        {
            Console.WriteLine("Ingrese el nombre del conductor: ");
            string nombre = Console.ReadLine();
            int edad;
            Console.WriteLine("Ingrese la edad del conductor: ");
            while (!int.TryParse(Console.ReadLine(), out edad) || edad <18)
            {
                Console.WriteLine("Error: Numero invalido o menor de edad");
            }

            string cedula;
            Console.WriteLine("Ingrese el número de cédula del conductor: ");
            while (true)
            {
                cedula = Console.ReadLine();
                
                if (cedula.Length == 10 && cedula.All(char.IsDigit)) 
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Error: Cedula debe contener 10 digitos.");
                }
            }

            Console.WriteLine("Ingrese el tipo de licencia del conductor: ");
            string licencia = Console.ReadLine().ToUpper();
            while (licencia != "E") 
            {
                Console.WriteLine("Error: Debe poseer licencia tipo E para registrar");
                licencia = Console.ReadLine().ToUpper();
            }

            conductores[cedula] = new Dictionary<string, string>()
            {
                { "Nombre",nombre},
                { "Edad",edad.ToString() },
                { "Licencia",licencia}

            };

            Console.WriteLine("Conductor agregado exitosamente.");
        }
        public static void BuscarConductor(Dictionary<string, Dictionary<string, string>> conductores)
        {
            if (conductores.Count == 0)
            {
                Console.WriteLine("No hay conductores registrados en el sistema.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Conductores registrados:");
            foreach (var conductor in conductores)
            {
                var datosConductor = conductor.Value;
                Console.WriteLine($"Cédula: {conductor.Key}, Nombre: {datosConductor["Nombre"]}, Edad: {datosConductor["Edad"]}, Licencia: {datosConductor["Licencia"]}");
            }

            string cedula = ValidarCedula();

            if (conductores.TryGetValue(cedula, out var datosEncontrados))
            {
                Console.WriteLine("Conductor encontrado:");
                Console.WriteLine($"Nombre: {datosEncontrados["Nombre"]}");
                Console.WriteLine($"Edad: {datosEncontrados["Edad"]}");
                Console.WriteLine($"Licencia: {datosEncontrados["Licencia"]}"); 
            }
            else
            {
              
                Console.WriteLine("Error: Conductor no encontrado con la cédula ingresada.");
            }
        }
        public static void AgregarUsuario(Dictionary<string, Dictionary<string, string>> usuarios)
        {
            Console.WriteLine("Ingrese el nombre del usuario: ");
            string nombre = Console.ReadLine();

            int edad;
            Console.WriteLine("Ingrese la edad del usuario: ");
            while (!int.TryParse(Console.ReadLine(), out edad) || edad <= 5) 
            {
                Console.WriteLine("Error: Número inválido o menor de 5 años");
            }

            string cedula = ValidarCedula();

            Console.WriteLine("¿Tiene discapacidad? (S/N): ");
            string validacion_discapacidad = Console.ReadLine().ToUpper();
            
            while (validacion_discapacidad != "S" && validacion_discapacidad != "N")
            {
                Console.WriteLine("Error: Respuesta inválida.");
                validacion_discapacidad = Console.ReadLine().ToUpper();
            }

            string discapacidad = validacion_discapacidad;

            usuarios[cedula] = new Dictionary<string, string> 
            {
                { "Nombre", nombre },
                { "Edad", edad.ToString() },
                { "Discapacidad", discapacidad }
            };

            Console.WriteLine("Usuario agregado exitosamente.");
        }
        public static void BuscarUsuario(Dictionary<string, Dictionary<string, string>> usuarios)
        {
            if (usuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios registrados en el sistema.");
                Console.ReadKey();
                return; 
            }

            Console.WriteLine("Usuarios registrados:");
            foreach (var usuario in usuarios)
            {
                var datosUsuario = usuario.Value;
                Console.WriteLine($"Cédula: {usuario.Key}, Nombre: {datosUsuario["Nombre"]}, Edad: {datosUsuario["Edad"]}, Discapacidad: {datosUsuario["Discapacidad"]}");
            }

            string cedula = ValidarCedula();
            
            
            if (usuarios.TryGetValue(cedula, out var datosEncontrados))
            {
                Console.WriteLine("Usuario encontrado:");
                Console.WriteLine($"Nombre: {datosEncontrados["Nombre"]}");
                Console.WriteLine($"Edad: {datosEncontrados["Edad"]}");
                Console.WriteLine($"Discapacidad: {datosEncontrados["Discapacidad"]}");
            }
            else
            {
                Console.WriteLine("Error: Usuario no encontrado.");
            }
        }

        public static string ValidarCedula()
        {
            string cedula;
            Console.WriteLine("Ingrese el número de cédula: ");
            while (true)
            {
                cedula = Console.ReadLine();
                if (cedula.Length == 10 && cedula.All(char.IsDigit))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: La cédula debe contener 10 dígitos.");
                }
            }
            return cedula;
        }
    }
}
