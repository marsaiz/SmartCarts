using System.Reflection;
using Programa.App.Pantallas;
using SmartCarts.Libreria.Modelos;
using SmartCarts.Libreria.Negocio;
using SmartCarts.Libreria.Repositorios;

namespace SmartCarts.App.Pantallas;

public class PantallaModificarProducto
{
    private readonly ProductoServicio _productoServicio;

    public PantallaModificarProducto()
    {
        _productoServicio = new ProductoServicio();
    }

    public void MostrarPantallaAccion()
    {
        bool validEntry = false;

        do
        {
            Console.WriteLine("Ingrese el nombre o parte de el para hacer una busqueda:");
            string entradaUsuario = Console.ReadLine();

            List<Productos> listado = _productoServicio.ObtenerProductosPorNombre(entradaUsuario);

            foreach (Productos item in listado)
            {
                Console.WriteLine("Producto/s encontrados: ");
                Console.WriteLine(item);
            }
            Console.WriteLine("Para continuar precione s/n");
            string respuesta = Console.ReadLine().ToLower();

            if (respuesta == "s")
            {
                Console.Write("Ingrese el id del producto: ");
                int productoSeleccionado = Int32.Parse(Console.ReadLine());


                ProductoServicio productoServicio = new ProductoServicio();
                productoServicio.ObtenerProductoPorId(productoSeleccionado);

                double nuevoPrecio = 0;
                Console.WriteLine("Escriba el nuevo precio");
                nuevoPrecio = Convert.ToDouble(Console.ReadLine());

                _productoServicio.ModificarPrecioProducto(productoSeleccionado, nuevoPrecio);

                Console.WriteLine("Precio modificado");
                Console.WriteLine();
            }
            else
            {
                PantallaPrincipal pantallaPrincipal1 = new PantallaPrincipal();
                pantallaPrincipal1.MostrarPantallaPrincipal();
            }
        } while (validEntry == false);
    }
}