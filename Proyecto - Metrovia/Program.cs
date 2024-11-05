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
            Dictionary<string, Dictionary<string, string>> conductores = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, Dictionary<string, string>> usuarios = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, Dictionary<string, string>> estaciones = new Dictionary<string, Dictionary<string, string>>();

            int opcion;

            do
            {
                Console.WriteLine("\n--- Proyecto 01 - Sistema Metrovia ---");
                Console.WriteLine("1. Agregar Conductor");
                Console.WriteLine("2. Buscar Conductor");
                Console.WriteLine("3. Agregar Usuario");
                Console.WriteLine("4. Buscar Usuario");
                Console.WriteLine("5. Agregar Paradas");
                Console.WriteLine("6. Agregar Reporte de Paradas");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine();
                            AgregarConductor(conductores);
                            break;
                        case 2:
                            Console.WriteLine();
                            BuscarConductor(conductores);
                            break;
                        case 3:
                            Console.WriteLine();
                            AgregarUsuario(usuarios);
                            break;
                        case 4:
                            Console.WriteLine();
                            BuscarUsuario(usuarios);
                            break;
                        case 5:
                            Console.WriteLine();
                            AgregarParada(estaciones);
                            break;
                        case 6:
                            Console.WriteLine();
                            AgregarReporte(estaciones);
                            break;
                        case 7:
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

            } while (opcion != 7);
        }

        public static void AgregarConductor(Dictionary<string, Dictionary<string, string>> conductores)
        {
            string cedula = ValidarCedula();

            if (conductores.ContainsKey(cedula))
            {
                Console.WriteLine("Error: la cedula ingresada ya existe.");
                return;
            }

            Console.WriteLine("Ingrese el nombre del conductor: ");
            string nombre = Console.ReadLine();

            int edad;
            Console.WriteLine("Ingrese la edad del conductor: ");
            while (!int.TryParse(Console.ReadLine(), out edad) || edad < 18)
            {
                Console.WriteLine("Error: Numero invalido o menor de edad");
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
            string cedula = ValidarCedula();

            if (usuarios.ContainsKey(cedula))
            {
                Console.WriteLine("Error: la cedula ingresada ya existe.");
                return;
            }

            Console.WriteLine("Ingrese el nombre del usuario: ");
            string nombre = Console.ReadLine();

            int edad;
            Console.WriteLine("Ingrese la edad del usuario: ");
            while (!int.TryParse(Console.ReadLine(), out edad) || edad <= 5)
            {
                Console.WriteLine("Error: Número inválido o menor de 5 años");
            }

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
        public static void AgregarParada(Dictionary<string, Dictionary<string, string>> estaciones)
        {
            Console.WriteLine("Ingrese el nombre de la Estacion: ");
            string parada = Console.ReadLine().ToUpper();

            if (estaciones.ContainsKey(parada))
            {
                Console.WriteLine("la Estacion ingresada ya existe");
                return;
            }

            Console.WriteLine("Ingrese la direccion de la Estacion: ");
            string direccion = Console.ReadLine().ToUpper();

            Console.WriteLine("Ingrese el saldo inicial de la Estacion: ");

            int saldo;

            while (!int.TryParse(Console.ReadLine(), out saldo) || saldo < 0)
            {
                Console.WriteLine("Error: no puede ser menor de 0");
            }

            estaciones[parada] = new Dictionary<string, string>
            {
                { "Estacion", parada },
                { "Direccion", direccion },
                { "Saldo", saldo.ToString() }
            };

            Console.WriteLine("Parada agregada exitosamente.");
        }

        public static void AgregarReporte(Dictionary<string, Dictionary<string, string>> estaciones)
        {
            if (estaciones.Count == 0)
            {
                Console.WriteLine("No hay Estaciones registradas en el sistema.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Estaciones Registradas: ");
            foreach (var estacion in estaciones)
            {
                var datosEstaciones = estacion.Value;
                Console.WriteLine($"Estacion: {datosEstaciones["Estacion"]}, Direccion: {datosEstaciones["Direccion"]}, Saldo {datosEstaciones["Saldo"]}");
                Console.WriteLine();
                Console.WriteLine("Ingrese el nombre de la Estacion para actualizar el saldo: ");
                Console.WriteLine("Ingrese SALIR para regresar");
                string nombreEstacion = Console.ReadLine().ToUpper();

                if(nombreEstacion == "SALIR")
                {
                    return;
                }

                if (!estaciones.ContainsKey(nombreEstacion))
                {
                    Console.WriteLine("La Estacion ingresada no existe.");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Ingrese el nuevo saldo: ");
                int nuevoSaldo;
                while (!int.TryParse(Console.ReadLine(), out nuevoSaldo) || nuevoSaldo < 0)
                {
                    Console.WriteLine("Error: el saldo no puede ser menor de 0");
                }

                estaciones[nombreEstacion]["Saldo"] = nuevoSaldo.ToString();

                Console.WriteLine("Saldo actualizado exitosamente.");
                Console.ReadKey();


            }
        }
    }
}
