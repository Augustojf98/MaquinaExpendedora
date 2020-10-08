using MaquinaExpendedora.Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaExpendedora.Consola
{
    class Program
    {
        static void Main(string[] args)
        {

            bool continuarActivo = true;

            string menu = "1)Listar códigos de latas \n2)Agregar lata \n3)Comprar lata \n4)Ver balance \n5)Listar latas en stock \nX)Cerrar programa";
            Libreria.MaquinaExpendedora maquina = new Libreria.MaquinaExpendedora(12);

            do
            {
                Console.WriteLine(menu); //mostramos el menú

                try
                {
                    //capturamos la seleccion
                    string opcionSeleccionada = Console.ReadLine();

                    // validamos si el input es válido (en este caso podemos tmb dejar que el switch se encargue en el default.
                    // lo dejo igual por las dudas si quieren usar el default del switch para otra cosa.
                    if (Helpers.ValidadoresHelper.EsOpcionValida(opcionSeleccionada, "1234567X"))
                    {
                        if (opcionSeleccionada.ToUpper() == "X")
                        {
                            continuarActivo = false;
                            continue;
                        }

                        switch (opcionSeleccionada)
                        {
                            case "1":
                                // listar
                                Program.ListarCodigos(maquina);
                                break;

                            case "2":
                                // agregar
                                Program.AgregarLata(maquina);
                                break;

                            case "3":
                                // alta
                                Program.RetirarLata(maquina);
                                break;

                            //case "4":
                            //    // alta
                            //    Program.EliminarRepuesto(viel);
                            //    break;

                            //case "5":
                            //    // borrar
                            //    Program.AgregarStockRepuesto(viel);
                            //    break;

                            //case "6":
                            //    // borrar
                            //    Program.QuitarStockRepuesto(viel);
                            //    break;

                            case "7":
                                Console.Clear();
                                break;

                            //etc... si tenemos más opciones...
                            default:
                                Console.WriteLine("Opción inválida.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error durante la ejecución del comando. Por favor intente nuevamente. Mensaje: " + ex.Message);
                }
                Console.WriteLine("Ingrese una tecla para continuar.");

                Console.ReadKey();
                Console.Clear();
            }
            while (continuarActivo);

            Console.WriteLine("Gracias por usar la app.");
            Console.ReadKey();
        }

        private static void ListarCodigos(Libreria.MaquinaExpendedora maquina)
        {
            foreach(Lata lata in maquina.Latas)
            {
                if(lata.Precio == 0 && lata.Volumen == 0)
                {
                    MostrarCodigoNombre(lata);
                }
            }
        }

        private static void MostrarCodigoNombre(Lata lata)
        {
            Console.WriteLine(lata.Codigo + " - " + lata.Nombre + " - " + lata.Sabor);
        }

        private static void AgregarLata(Libreria.MaquinaExpendedora maquinaExpendedora)
        {
            try
            {
                Console.WriteLine("Ingrese un código de la lista");
                ListarCodigos(maquinaExpendedora);
                string c = Helpers.ConsolaHelper.PedirString("Codigo");
                Console.Clear();
                Console.WriteLine(string.Format("Codigo: {0} - {1} {2}", c, maquinaExpendedora.ExisteCodigo(c).Nombre, maquinaExpendedora.ExisteCodigo(c).Sabor));
                if(maquinaExpendedora.BuscarStockPorCodigo(c) == null)
                {
                    Console.WriteLine("No hay stock de " + maquinaExpendedora.ExisteCodigo(c).Nombre + maquinaExpendedora.ExisteCodigo(c).Sabor);
                    double p = Helpers.ConsolaHelper.PedirDouble("Precio");
                    double v = Helpers.ConsolaHelper.PedirDouble("Volumen");
                    maquinaExpendedora.AgregarLata(c, p, v);
                    Console.WriteLine("Se agregó una lata de " + maquinaExpendedora.BuscarModeloPorCodigo(c).Nombre + " - " + maquinaExpendedora.BuscarModeloPorCodigo(c).Sabor);
                }
                else
                {
                    throw new Libreria.Exceptions.SinCapacidadException(maquinaExpendedora.BuscarModeloPorCodigo(c).Nombre + " - " + maquinaExpendedora.BuscarModeloPorCodigo(c).Sabor);
                }
            }
            catch (Libreria.Exceptions.SinStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Libreria.Exceptions.CodigoInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RetirarLata(Libreria.MaquinaExpendedora maquinaExpendedora)
        {
            try
            {
                Console.WriteLine("Ingrese un código de la lista");
                ListarCodigos(maquinaExpendedora);
                string c = Helpers.ConsolaHelper.PedirString("Codigo");
                Console.Clear();
                Console.WriteLine(string.Format("Codigo: {0} - {1} {2}", c, maquinaExpendedora.ExisteCodigo(c).Nombre, maquinaExpendedora.ExisteCodigo(c).Sabor));

                if (maquinaExpendedora.BuscarStockPorCodigo(c) == null)
                {
                    throw new Libreria.Exceptions.SinStockException(maquinaExpendedora.BuscarModeloPorCodigo(c).Nombre + " - " + maquinaExpendedora.BuscarModeloPorCodigo(c).Sabor);
                }
                else
                {
                    Console.WriteLine("No hay stock de " + maquinaExpendedora.ExisteCodigo(c).Nombre + maquinaExpendedora.ExisteCodigo(c).Sabor);
                    double p = Helpers.ConsolaHelper.PedirDouble("Precio");
                    maquinaExpendedora.RetirarLata(c, p);

                    Console.WriteLine("Se retiró una lata de " + maquinaExpendedora.BuscarModeloPorCodigo(c).Nombre + " - " + maquinaExpendedora.BuscarModeloPorCodigo(c).Sabor);
                }

            }
            catch(Libreria.Exceptions.SinStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Libreria.Exceptions.DineroInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    
}
