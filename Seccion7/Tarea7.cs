namespace Tarea7
{
    class Tarea7
    {
        static void Main()
        {
            string nombreAr, apellidoAr, direccionAr, rfcAr, saldoFinal;
            double saldoAr, montoAr;

            Console.WriteLine("Bienvenido a Industrias Oscorp");
            Console.WriteLine("Ingrese los siguientes datos solicitados");
            Console.Write("Nombre: ");    nombreAr = Console.ReadLine();
            Console.Write("Apellido: ");  apellidoAr = Console.ReadLine();
            Console.Write("Saldo: ");     saldoAr = Convert.ToDouble(Console.ReadLine());
            Console.Write("Dirección: "); direccionAr = Console.ReadLine();
            Console.Write("Clave RFC: "); rfcAr = Console.ReadLine();
            Console.Clear();

            // Instanciamos la clase CuentaBancaria
            CuentaBancaria cuenta = new CuentaBancaria(nombreAr, apellidoAr, ref saldoAr, direccionAr, rfcAr);

            int opcion;
            do
            {
                Console.WriteLine("\nElija la siguiente operación: ");
                Console.WriteLine("1) Depositar una cantidad.");
                Console.WriteLine("2) Retirar una cantidad.");
                Console.WriteLine("3) Consultar saldo actual.");
                Console.WriteLine("4) Información de la cuenta.");
                Console.WriteLine("5) Salir.");

                Console.Write("--> "); opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Console.Write("Monto a depositar: ");
                        montoAr = Convert.ToDouble(Console.ReadLine());
                        
                        saldoFinal = cuenta.Deposito(montoAr);
                        break;
                    case 2:
                        Console.Write("Monto a retirar: ");
                        montoAr = Convert.ToDouble(Console.ReadLine());

                        if (montoAr <= cuenta.Saldo) saldoFinal = cuenta.Retiro(montoAr);
                        else Console.Write("Cantidad superada.");
                        break;
                    case 3:
                        Console.Write("Su saldo actual es: " + cuenta.ConsultaSaldo());
                        break;
                    case 4:
                        Console.WriteLine("Información de cliente:");
                        Console.Write(cuenta.ToString());
                        break;
                }
            }
            while (opcion != 5);
            Console.ReadKey();
        }
    }

    public class CuentaBancaria
    {
        private string nombre, apellido, direccion, rfc;
        private double saldo;

        // Constructor
        public CuentaBancaria(string nombrePa, string apellidoPa, ref double saldoPa, string direccionPa, string rfcPa)
        {
            nombre = nombrePa;
            apellido = apellidoPa;
            saldo = saldoPa;
            direccion = direccionPa;
            rfc = rfcPa;  
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
        public override string ToString()
        {
            string mensaje = "";
           
            mensaje = "Empleado: " + nombre + " " + apellido + "\nSaldo: " + $"{saldo}" + "\nDirección: " + direccion + "\nClave: " + rfc;
            return mensaje;
        }
        public double Saldo
        {
            get => saldo;
            set => saldo = value; // escribir en nip lo que está en value
        }
    }
}