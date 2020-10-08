using MaquinaExpendedora.Libreria.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Libreria
{
    public class MaquinaExpendedora
    {
        private List<Lata> _latas;
        private int _capacidad;
        private double _dinero;
        private bool _encendida;

        public List<Lata> Latas
        {
            get
            {
                return this._latas;
            }
        }

        public MaquinaExpendedora(int capacidad)
        {
            this._capacidad = capacidad;

            this._latas = new List<Lata>();
            this._latas.Add(new Lata("CO1", "Coca Cola", "Regular"));
            this._latas.Add(new Lata("CO2", "Coca Cola", "Zero"));
            this._latas.Add(new Lata("SP1", "Sprite", "Regular"));
            this._latas.Add(new Lata("SP2", "Sprite", "Zero"));
            this._latas.Add(new Lata("FA1", "Fanta", "Regular"));
            this._latas.Add(new Lata("FA2", "Fanta", "Zero"));
        }

        public List<Lata> TraerStockLatas()
        {

            List<Lata> latas = new List<Lata>();

            foreach (Lata lata in Latas)
            {
                if(lata.Precio != 0 || lata.Volumen != 0)
                {
                    latas.Add(lata);
                }
            }

            if(latas.Count > 0)
            {
                return latas;
            }
            else
            {
                throw new SinStockException("Ninguna lata");
            }
        }

        public void EncenderMaquina()
        {
            if (!this._encendida)
                this._encendida = true;
            else throw new Exception("La máquina ya está encendida!");
        }

        public void ApagarMaquina()
        {
            if (this._encendida)
                this._encendida = false;
            else throw new Exception("La máquina no está encendida!");
        }

        public bool MaquinaEncendida
        {
            get
            {
                return this._encendida;
            }
        }

        public Lata BuscarStockPorCodigo(string codigo)
        {
            foreach (Lata l in _latas)
            {
                if (codigo == l.Codigo && (l.Precio != 0 || l.Volumen != 0))
                    return l;
            }
            return null;
        }

        public Lata BuscarModeloPorCodigo(string codigo)
        {
            foreach (Lata l in _latas)
            {
                if (codigo == l.Codigo && l.Precio == 0 && l.Volumen == 0)
                    return l;
            }
            return null;
        }

        public Lata ExisteCodigo(string codigo)
        {
            foreach (Lata l in _latas)
            {
                if (codigo == l.Codigo)
                {
                    return BuscarModeloPorCodigo(codigo);
                }
            }
            return null;
            throw new CodigoInvalidoException(codigo);
        }

        public void AgregarLata(string codigo, double precio, double volumen)
        {
            Lata lata = new Lata(codigo, BuscarModeloPorCodigo(codigo).Nombre, BuscarModeloPorCodigo(codigo).Sabor, precio, volumen);

            this._latas.Add(lata);
        }

        public void RetirarLata(string codigo, double dineroIngresado)
        {
            if (BuscarStockPorCodigo(codigo).Precio > dineroIngresado)
            {
                throw new DineroInsuficienteException("Se devuelven sus $" + dineroIngresado);
            }
            else
            {
                double vuelto = 0;

                vuelto = dineroIngresado - BuscarStockPorCodigo(codigo).Precio;

                this._latas.Remove(BuscarStockPorCodigo(codigo));

                this._dinero = this._dinero + dineroIngresado - vuelto;

                if (vuelto > 0)
                {
                    throw new Exception("Su vuelto es de $" + vuelto);
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Dinero acumulado: ${0} - Cantidad de latas en stock: {1} unidades", this._dinero, this.TraerStockLatas().Count());
        }

    }
    
}
