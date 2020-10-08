using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Libreria.Exceptions
{
    public class SinStockException : Exception
    {
        public SinStockException()
        {

        }

        public SinStockException(string message)
           : base(String.Format("No hay stock suficiente: {0}", message))
        {

        }
    }
}
