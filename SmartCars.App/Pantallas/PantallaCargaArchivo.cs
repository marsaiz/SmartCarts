using SmartCarts.Libreria.Modelos;
using SmartCarts.Libreria.Negocio;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace SmartCarts.App.Pantallas
{
    public class PantallaCargaArchivo
    {
        private ProductoServicio _productoServicio;

        public PantallaCargaArchivo()
        {
            _productoServicio = new ProductoServicio();
        }
        public void MostrarPantallaCargaArchivo()
        {
            //Declaración de variables temporales para almacenar los datos extradidos del archivo cvs
            int id = 0;
            long ean = 0;
            string descripcion = "";
            string tipoProducto = "";
            double precio = 0;
            double iva = 0;
            try
            {
                Console.WriteLine("Ingrese la ruta del archivo:");
                string? rutaArchivo = Console.ReadLine();

                //Comprobar si la ruta ingresada tiene un arcivo, devueleve true si existe.
                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("El archivo no existe.");
                    Console.WriteLine();
                    return;
                }
                //Crear una lista para recorrer los datos del arhivo
                List<Productos> productos = new List<Productos>();
                
                using (StreamReader archivo = new StreamReader(rutaArchivo))
                {
                    string separador = ",";
                    string linea;
                    archivo.ReadLine();//Leer la primera linea del archivo y descartarla por que es el encabezado

                    while ((linea = archivo.ReadLine()) != null)
                    {
                        string[] fila = linea.Split(separador);
                        id = Int32.Parse(fila[0]);
                        ean = long.Parse(fila[1]);
                        descripcion = fila[2];
                        tipoProducto = fila[3];
                        precio = double.Parse(fila[4], CultureInfo.InvariantCulture);
                        iva = double.Parse(fila[5], CultureInfo.InvariantCulture);
                        Console.WriteLine("{0}-{1}-{2}-{3}-{4}-{5}", id, ean, tipoProducto, descripcion, precio, iva);

                        Productos producto = new Productos();
                        producto.IdProducto = id;
                        producto.Ean = ean;
                        producto.Descripcion = descripcion;
                        producto.TipoProducto = tipoProducto;
                        producto.Precio = precio;
                        producto.Iva = iva;

                        productos.Add(producto);

                    }
                    string? readResult;
                    Console.WriteLine("¿Desea guardar el archivo en sistema: s/n?");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        readResult = readResult.ToLower();
                    }

                    if (readResult == "s")
                    {
                        foreach (var value in productos)
                        {
                            _productoServicio.AgregarProductos(value);
                        }

                        Console.WriteLine("Archivo cargado con exito");
                        Console.WriteLine();
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("El archivo es incorrecto");
                Console.WriteLine(e.Message);
            }
        }
    }
}
