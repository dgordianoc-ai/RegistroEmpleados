namespace RegistroEmpleados
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ============================================================
            // Registro de Empleados
            // ============================================================

            string opcion;
            List<Empleado> empleados = new List<Empleado>();
            int siguienteId = 1;

            do
            {
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case "1":
                        AgregarEmpleado(empleados, ref siguienteId);
                        break;

                    case "2":
                        ListarEmpleados(empleados);
                        break;

                    case "3":
                        BuscarEmpleado(empleados);
                        break;

                    case "4":
                        CalcularFactorial();
                        break;

                    case "5":
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            while (opcion != "5");
        }

        // ============================================================
        // Método para mostrar el menú
        // ============================================================

        private static string LeerOpcionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== REGISTRO DE EMPLEADOS ===");
            Console.WriteLine("1. Agregar empleado");
            Console.WriteLine("2. Listar empleados");
            Console.WriteLine("3. Buscar empleado");
            Console.WriteLine("4. Calcular factorial");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");

            return Console.ReadLine();
        }

        // ============================================================
        // Agregar empleado
        // ============================================================

        private static void AgregarEmpleado(List<Empleado> empleados, ref int id)
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine().Trim();

            Console.Write("Salario base: ");
            bool salarioOk = decimal.TryParse(
                Console.ReadLine(),
                out decimal salarioBase);

            Console.Write("Horas extra: ");
            bool horasOk = int.TryParse(
                Console.ReadLine(),
                out int horasExtra);

            if (string.IsNullOrWhiteSpace(nombre)
                || !salarioOk
                || salarioBase <= 0
                || !horasOk
                || horasExtra < 0)
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            empleados.Add(new Empleado
            {
                Id = id,
                Nombre = nombre,
                SalarioBase = salarioBase,
                HorasExtra = horasExtra
            });

            id++;

            Console.WriteLine("Empleado agregado.");
        }

        // ============================================================
        // Listar empleados
        // ============================================================

        private static void ListarEmpleados(List<Empleado> empleados)
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
                return;
            }

            decimal totalGeneral = 0;

            Console.WriteLine(
                $"{"Id",-3} {"Nombre",-20} {"Salario",10} {"Horas",-6} {"Pago Total",12}");

            foreach (Empleado e in empleados)
            {
                Console.WriteLine(e);
                totalGeneral += e.PagoTotal();
            }

            Console.WriteLine();
            Console.WriteLine($"TOTAL DE NÓMINA: Q {totalGeneral:N2}");
        }

        // ============================================================
        // Buscar empleado
        // ============================================================

        private static void BuscarEmpleado(List<Empleado> empleados)
        {
            Console.Write("Nombre a buscar: ");

            string texto = Console.ReadLine().Trim().ToUpper();

            bool encontrado = false;

            foreach (Empleado e in empleados)
            {
                if (e.Nombre.ToUpper().Contains(texto))
                {
                    Console.WriteLine(e);
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Sin coincidencias.");
            }
        }

        // ============================================================
        // Calcular factorial
        // ============================================================

        private static void CalcularFactorial()
        {
            Console.Write("Número (entero, 0 o mayor): ");

            bool numeroOk = int.TryParse(
                Console.ReadLine(),
                out int numero);

            if (!numeroOk || numero < 0)
            {
                Console.WriteLine("Dato inválido.");
                return;
            }

            Console.WriteLine($"{numero}! = {Factorial(numero)}");
        }

        private static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}