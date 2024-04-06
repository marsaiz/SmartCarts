using SmartCarts.Libreria.Modelos;
using SmartCarts.Libreria.Negocio;

namespace SmartCarts.App.Pantallas;

public class PantallaConsultaProductos
{
    private readonly ProductoServicio _productoServicio;

    public PantallaConsultaProductos()
    {
        _productoServicio = new ProductoServicio();
    }
    public void ListarProductos()
    {
        ProductoServicio productoServicio = new ProductoServicio();
        List<Productos> listadoProductos = _productoServicio.ObtenerProductos();

        foreach (Productos productos in listadoProductos)
        {
            Console.WriteLine($"Id producto: {productos.IdProducto} - {productos.Descripcion} - {productos.TipoProducto} - {productos.Precio} - {productos.Iva}");
        }
        
        Console.WriteLine();
        Console.WriteLine("Si desea buscar un producto especfico por la descrición");
        Console.WriteLine("Ingrese el nombre del producto o parte del nombre: ");

        string entradaUsuario = Console.ReadLine();
        List<Productos> listado = _productoServicio.ObtenerProductosPorNombre(entradaUsuario);

        Console.Clear();
        foreach (Productos item in listado)
        {
            Console.WriteLine("Producto/s encontrados: ");
            Console.WriteLine(item);
            Console.WriteLine();
        }
        Console.WriteLine();
        //Console.WriteLine("Presione una tecla para continuar");
        Console.WriteLine();
        //Console.ReadKey();
    }
}
