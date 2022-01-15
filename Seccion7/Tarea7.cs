namespace Tarea7
{
    class Tarea7
    {
        static void Main()
        {
            string nombreAr, apellidoAr, direccionAr, rfcAr;
            double saldoAr, montoAr = 0;

            Console.WriteLine("Bienvenido a Industrias Oscorp");
            Console.WriteLine("Ingrese los siguientes datos solicitados");
            Console.Write("Nombre: ");    nombreAr = Console.ReadLine();
            Console.Write("Apellido: ");  apellidoAr = Console.ReadLine();
            Console.Write("Saldo: ");     saldoAr = Convert.ToDouble(Console.ReadLine());
            Console.Write("Dirección: "); direccionAr = Console.ReadLine();
            Console.Write("Clave RFC: "); rfcAr = Console.ReadLine();
            Console.Clear();

            int opcion;
            do
            {
                Console.WriteLine("Elija la siguiente operación: ");
                Console.WriteLine("1) Depositar una cantidad.");
                Console.WriteLine("2) Retirar una cantidad.");
                Console.WriteLine("3) Consultar saldo actual.");
                Console.WriteLine("4) Información de la cuenta.");
                Console.WriteLine("5) Salir.");

                Console.Write("--> "); opcion = Convert.ToInt32(Console.ReadLine());
                if (opcion == 1 || opcion == 2)
                {
                    Console.Write("Ingrese el monto: ");
                    montoAr = Convert.ToDouble(Console.ReadLine());
                }

                // Instanciamos la clase CuentaBancaria
                CuentaBancaria cuenta = new CuentaBancaria(nombreAr, apellidoAr, saldoAr, direccionAr, rfcAr, opcion, montoAr);
                //cuenta.Opcion = opcion;
                Console.WriteLine(cuenta.ToString()); // esta línea está mal?
            }
            while (opcion != 5);
            Console.ReadKey();
        }
    }

    public class CuentaBancaria
    {
        private string nombre, apellido, direccion, rfc, saldoFinal;
        private double saldo, monto;
        private int opcion;

        // Propiedad
        //public int Opcion
        //{
        //    set => opcion = value; // escribir en opcion lo que está en value
        //}

        // Constructor
        public CuentaBancaria(string nombrePa, string apellidoPa, double saldoPa, string direccionPa, string rfcPa, int opcionPa, double montoPa)
        {
            nombre = nombrePa;
            apellido = apellidoPa;
            saldo = saldoPa;
            direccion = direccionPa;
            rfc = rfcPa;
            opcion = opcionPa;
            monto = montoPa;

            if (opcion == 1) saldoFinal = Deposito(monto);
            if (opcion == 2) saldoFinal = Retiro(monto);
            if (opcion == 3) saldoFinal = ConsultaSaldo();
            if (opcion == 4) saldoFinal = ToString();
        }

        // Métodos
        public string Deposito (double deposito)
        {
            string saldoDeposito;

            saldo += deposito;

            saldoDeposito = saldo.ToString();
            return saldoDeposito;
        }
        public string Retiro (double retiro)
        {
            string saldoRetiro;

            if(retiro <= saldo) saldo -= retiro;

            saldoRetiro = saldo.ToString();
            return saldoRetiro;
        }
        public string ConsultaSaldo ()
        {
            string saldoConsulta;

            saldoConsulta = saldo.ToString();
            return saldoConsulta;
        }
        public string InfoCuenta()
        {
            string infoCuenta;

            infoCuenta = "Empleado: " + nombre + " " + apellido + "\nSaldo: " + $"{saldo}" + "\nDirección: " + direccion + "\nClave: " + rfc;
            return infoCuenta;
        }
        public override string ToString()
        {
            string mensaje = "";

            mensaje = saldoFinal;
            return mensaje;
        }
    }
}