using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Consola.Helpers
{
    public class ConsolaHelper
    {
        public static string PedirString(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            string s = Console.ReadLine();

            return s;
        }

        public static int PedirInt(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            int s = int.Parse(Console.ReadLine());

            return s;
        }

        public static double PedirDouble(string msg)
        {
            Console.WriteLine("Ingrese " + msg);
            double s = double.Parse(Console.ReadLine());

            return s;
        }
    }
}
