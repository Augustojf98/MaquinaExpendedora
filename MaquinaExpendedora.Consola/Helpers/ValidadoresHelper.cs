using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Consola.Helpers
{
    public class ValidadoresHelper
    {
        public static bool EsOpcionValida(string input, string opcionesValidas)
        {
            try
            {
                if (string.IsNullOrEmpty(input)
                    || input.Length > 1
                    || !opcionesValidas.ToUpper().Contains(input.ToUpper())
                    )
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
