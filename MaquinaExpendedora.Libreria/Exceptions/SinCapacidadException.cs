using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Libreria.Exceptions
{
    public class SinCapacidadException: Exception
    {
        public SinCapacidadException()
        {

        }

        public SinCapacidadException(string message)
        : base(String.Format("La máquina no tiene más capacidad para: {0}", message))
        {

        }
    }
}
