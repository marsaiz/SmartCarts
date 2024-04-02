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
        PantallaConsultaProductos pantallaConsultaProductos = new PantallaConsultaProductos();
        pantallaConsultaProductos.ListarProductos();

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
}