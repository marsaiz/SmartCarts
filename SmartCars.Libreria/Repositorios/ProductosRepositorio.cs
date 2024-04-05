using Microsoft.EntityFrameworkCore;
using SmartCarts.Libreria.Negocio;
using SmartCarts.Libreria.Modelos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization.Metadata;

namespace SmartCarts.Libreria.Repositorios;

public class ProductosRepositorio
{
    private readonly SmartCartsContexto _smartCartsConexto;

    public ProductosRepositorio()
    {
        _smartCartsConexto = SmartCartsContexto.CrearInstancia();
    }

    internal List<Productos> ObtenerProductos()
    {
        return _smartCartsConexto.Productos.ToList();
    }

    internal List<Productos> ObtenerProductoPorId(int idProducto)
    {
        return _smartCartsConexto.Productos.Where(d => d.IdProducto == idProducto).ToList();
    }

    public List<Productos> ListarProductos()
    {
        return _smartCartsConexto.Productos.Include(d => d.IdProducto).ToList();
    }

    internal List<Productos> ListarProductosPorNombre(string nombre)
    {
        return _smartCartsConexto.Productos.Where(d => d.Descripcion.ToLower().Contains(nombre.ToLower())).ToList();
    }

    internal void CargarArchivo(Productos productos)
    {
        //productos.Id_producto = Guid.NewGuid();
        Productos controlProducto = _smartCartsConexto.Productos.Find(productos.IdProducto);

        if (controlProducto != null)
        {
            controlProducto.Ean = productos.Ean;
            controlProducto.TipoProducto = productos.TipoProducto;
            controlProducto.Descripcion = productos.Descripcion;
            controlProducto.Precio = productos.Precio;
            controlProducto.Iva = productos.Iva;
        }
        else
        {
            _smartCartsConexto.Productos.Add(productos);

        }

        _smartCartsConexto.SaveChanges();
    }
    internal void ModificarPrecio(int idProducto, double nuevoPrecio)
    {
        var producto = _smartCartsConexto.Productos.SingleOrDefault(d => d.IdProducto == idProducto);

        if (producto != null)
        {
            producto.Precio = nuevoPrecio;
            _smartCartsConexto.SaveChanges();
        }
        else
        {
            Console.WriteLine("El producto no fue encontrado");
        }
    }
}
