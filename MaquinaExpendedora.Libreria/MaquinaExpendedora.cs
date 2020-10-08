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

        public Lata HayStock(string codigo)
        {
            foreach (Lata l in _latas)
            {
                if (codigo == l.Codigo && l.Precio != 0 && l.Volumen != 0)
                    return l;
            }
            return null;
        }

        public void AgregarLata(string codigo, double precio, double volumen)
        {

                if (HayStock(codigo) != null)
                {
                    throw new SinCapacidadException(BuscarStockPorCodigo(codigo).Nombre + " " + BuscarStockPorCodigo(codigo).Sabor);
                }
                else
                {
                    Lata lata = new Lata(codigo, BuscarModeloPorCodigo(codigo).Nombre, BuscarModeloPorCodigo(codigo).Sabor, precio, volumen);

                    this._latas.Add(lata);
                }
        }

        public void RetirarLata(string codigo, double dineroIngresado)
        {
            if (HayStock(codigo) != null)
            {
                if (HayStock(codigo).Precio > dineroIngresado)
                {
                    throw new DineroInsuficienteException("Se devuelven sus $" + dineroIngresado);
                }
                else
                {
                    this._latas.Remove(HayStock(codigo));
                }
            }
            else
            {
                throw new SinStockException("No hay stock para la lata seleccionada, de código " + codigo);
            }
        }

    }
    
}
