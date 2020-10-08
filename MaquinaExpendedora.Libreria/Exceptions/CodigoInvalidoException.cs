using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Libreria.Exceptions
{
    public class CodigoInvalidoException: Exception
    {
        public CodigoInvalidoException()
        {

        }

        public CodigoInvalidoException(string message)
           : base(String.Format("El código ingresado es inválido: {0}", message))
        {

        }
    }
}
