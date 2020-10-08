using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Libreria
{
    public class Lata
    {
        private string _codigo;
        private string _nombre;
        private string _sabor;
        private double _precio;
        private double _volumen;

        public Lata()
        {

        }

        public Lata(string codigo, string nombre, string sabor)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._sabor = sabor;
        }

        public Lata(string codigo, string nombre, string sabor, double precio, double volumen)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._sabor = sabor;
            this._precio = precio;
            this._volumen = volumen;
        }

        public string Codigo
        {
            get
            {
                return this._codigo;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
        }

        public string Sabor
        {
            get
            {
                return this._sabor;
            }
        }

        public double Precio
        {
            get
            {
                return this._precio;
            }
            set
            {
                this._precio = value;
            }
        }

        public double Volumen
        {
            get
            {
                return this._volumen;
            }
            set
            {
                this._volumen = value;
            }
        }

        private double GetPrecioPorLitro
        {
            get
            {
                return 1000 * this._precio / this._volumen;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} $ {2} / $/L {3}", this._nombre, this._sabor, this._precio, this.GetPrecioPorLitro);
        }
    }
}
