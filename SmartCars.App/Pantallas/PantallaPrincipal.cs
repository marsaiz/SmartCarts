using SmartCarts.App.Pantallas;

namespace Programa.App.Pantallas
{
    public class PantallaPrincipal
    {
        public PantallaPrincipal()
        {

        }
        public void MostrarPantallaPrincipal()
        {
            string? readResult;
            string menuSeleccion = "";
            do
            {
                //Menú de opciones
                Console.Clear();
                Console.WriteLine("1. Cargar archivo y visualizar datos cargados");
                Console.WriteLine("2. Modificar precio del producto");
                Console.WriteLine("3. Busqueda y visualización de productos cargados en el sistema");
                Console.WriteLine();
                Console.WriteLine("Digite una selección (o digite exit para salir)");

                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    menuSeleccion = readResult.ToLower();
                }
                
                switch (menuSeleccion)
                {
                    case "1":
                        PantallaCargaArchivo pantallaCargaArchivo = new PantallaCargaArchivo();
                        pantallaCargaArchivo.MostrarPantallaCargaArchivo();
                        break;
                    case "2":
                        PantallaModificarProducto pantallaModificarProducto = new PantallaModificarProducto();
                        pantallaModificarProducto.MostrarPantallaAccion();
                        break;
                    case "3":
                        PantallaConsultaProductos pantallaConsultaProductos = new PantallaConsultaProductos();
                        pantallaConsultaProductos.ListarProductos();
                        break;
                }
            } while (menuSeleccion != "exit");
        }
    }
}
