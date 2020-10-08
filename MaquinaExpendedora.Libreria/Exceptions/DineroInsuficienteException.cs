using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Libreria.Exceptions
{
    public class DineroInsuficienteException: Exception
    {
        public DineroInsuficienteException()
        {

        }

        public DineroInsuficienteException(string message)
           : base(String.Format("El dinero ingresado es insuficiente: {0}", message))
        {

        }
    }
}
