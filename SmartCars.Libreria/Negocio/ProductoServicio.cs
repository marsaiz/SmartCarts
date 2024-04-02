using SmartCarts.Libreria.Modelos;
using SmartCarts.Libreria.Repositorios;

namespace SmartCarts.Libreria.Negocio
{
    public class ProductoServicio
    {
        private readonly ProductosRepositorio _productosRepositorio;

        public ProductoServicio()
        {
            _productosRepositorio = new ProductosRepositorio();
        }

        public void AgregarProductos(Productos productos)
        {
            _productosRepositorio.CargarArchivo(productos);
        }

        public void ModificarPrecioProducto(int idProducto, double nuevoPrecio)
        {
            _productosRepositorio.ModificarPrecio(idProducto, nuevoPrecio);
        }
        public List<Productos> ObtenerProductos()
        {
            return _productosRepositorio.ObtenerProductos();
        }

        public List<Productos> ObtenerProductoPorId(int idProducto)
        {
            return _productosRepositorio.ObtenerProductoPorId(idProducto);
        }

        public List<Productos> ObtenerProductosPorNombre(string nombre)
        {
            return _productosRepositorio.ListarProductosPorNombre(nombre);
        }
    }
}