using System;
using System.Collections.Generic;
using System.Linq;

namespace EmpleadosConsola
{
    class Program
    {
        private static List<Empleado> lista = new List<Empleado>()
        {
            new Empleado()
            {
                Edad=22,
                Estudios = Enumerados.Estudios.Basico,
                Puesto = Enumerados.Puestos.Programador,
                Nombre = "Pepe Gomez"
                    
            },
            new Empleado()
            {
                Edad=23,
                Estudios = Enumerados.Estudios.Doctor,
                Puesto = Enumerados.Puestos.Programador,
                Nombre = "Pepe Jimenez"

            },
            new Empleado()
            {
                Edad=24,
                Estudios = Enumerados.Estudios.Medio,
                Puesto = Enumerados.Puestos.Programador,
                Nombre = "Juan Gomez"

            },
            new Empleado()
            {
                Edad=25,
                Estudios = Enumerados.Estudios.Doctor,
                Puesto = Enumerados.Puestos.Analista,
                Nombre = "Juan Gomez"

            },
        };
        static void Main(string[] args)
        {

            int r = 0;
            do
            {
                // Menu
                Console.WriteLine("*************MENU*************");
                Console.WriteLine("1. Alta");
                Console.WriteLine("2. Listar");
                Console.WriteLine("3. Buscar");
                Console.WriteLine("4. Salir");
                Console.Write("Que quieres hacer:");
                r = Convert.ToInt32(Console.ReadLine());
                switch (r)
                {
                    case 1:
                        alta();
                        break;
                    case 2:
                        listar();
                        break;
                    case 3:
                        buscar();
                        break;
                }

            } while (r != 4);


        }

        private static void listar()
        {
            foreach (var empleado in lista)
            {
                Console.WriteLine("{0} Estudios {1} Puesto {2}",
                    empleado.Nombre, empleado.Estudios,
                    empleado.Puesto);
            }
        }

        private static void alta()
        {
            try
            {
                var e = new Empleado();
                Console.WriteLine("Nombre: ");
                e.Nombre = Console.ReadLine();
                Console.WriteLine("Edad: ");
                e.Edad = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Estudios:");

                var es = Console.ReadLine();
                var esN = 0;

                if (int.TryParse(es, out esN))
                {
                    if (Enum.IsDefined(typeof(Enumerados.Estudios), esN))
                        e.Estudios = (Enumerados.Estudios)esN;

                }
                else
                {
                    Enumerados.Estudios est;
                    Enumerados.Estudios.TryParse(es, out est);
                    e.Estudios = est;

                }
                Console.WriteLine("Puesto: ");
                var pu = Console.ReadLine();
                var puN = 0;
                if (int.TryParse(pu, out puN))
                {
                    if (Enum.IsDefined(typeof(Enumerados.Puestos), puN))
                        e.Puesto = (Enumerados.Puestos)puN;

                }
                else
                {
                    Enumerados.Puestos est;
                    Enumerados.Puestos.TryParse(pu, out est);
                    e.Puesto = est;

                }

                lista.Add(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        private static void buscar()
        {
            Console.Write("Nombre: ");
            var n = Console.ReadLine();

            Console.Write("Edad: ");
            var e = Convert.ToInt32(Console.ReadLine());

            // ejemplo con expresiones Lambda
            var empleados = lista.Where(o => o.Edad > e || o.Nombre.Contains(n))
                .OrderBy(p=>p.Nombre).Take(3);

            if (!empleados.Any())
                Console.Write("No hay registros \n");
            else
                {
                    foreach (var em in empleados)
                        Console.Write(em);
                }

            

            // ejemplo con expresiones de consultas LINQ

            var empleado = from o in lista where o.Nombre.Contains(n) && o.Edad == e orderby o.Edad descending select o;

            // o es cada elemento de la lista de tipo persona
            // p por cada elemento de la lista donde p.Nombre



            // 1. metodo de extensión: metodo que declaro en una clase sin necesidad de modificar las mismas
            // 2. LINQ
            // 3. expresiones lambda
            
        }


    }
}