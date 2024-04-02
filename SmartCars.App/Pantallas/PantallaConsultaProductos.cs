using SmartCarts.Libreria.Modelos;
using SmartCarts.Libreria.Negocio;

namespace SmartCarts.App.Pantallas;

public class PantallaConsultaProductos
{
    public void ListarProductos()
    {
        ProductoServicio productoServicio = new ProductoServicio();
        List<Productos> listadoProductos = productoServicio.ObtenerProductos();
        
        foreach (Productos productos in listadoProductos) 
        {
            Console.WriteLine($"Id producto: {productos.IdProducto} - {productos.TipoProducto} - {productos.Descripcion} - {productos.Precio} - {productos.Iva}");
        }
        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar");
        Console.WriteLine();
        //Console.ReadLine();
    }
}
