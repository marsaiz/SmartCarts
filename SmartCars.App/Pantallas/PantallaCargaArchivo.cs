using SmartCarts.Libreria.Modelos;
using SmartCarts.Libreria.Negocio;
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
            int id = 0;
            long ean = 0;
            string tipoProducto = "";
            string descripcion = "";
            double precio = 0;
            double iva = 0;
            try
            {
                Console.WriteLine("Ingrese la ruta del archivo:");
                string? rutaArchivo = Console.ReadLine();

                if (!File.Exists(rutaArchivo))
                {
                    Console.WriteLine("El archivo no existe.");
                    Console.WriteLine();
                    return;
                }

                using (StreamReader archivo = new StreamReader(rutaArchivo))
                {
                    string separador = ",";
                    string linea;

                    while ((linea = archivo.ReadLine()) != null)
                    {
                        //archivo.ReadLine();//Leer la primera linea del archivo y descartarla por que es el encabezado
                        string[] fila = linea.Split(separador);
                        id = Int32.Parse(fila[0]);
                        ean = long.Parse(fila[1]);
                        tipoProducto = fila[2];
                        descripcion = fila[3];
                        precio = double.Parse(fila[4], CultureInfo.InvariantCulture);
                        iva = double.Parse(fila[5], CultureInfo.InvariantCulture);
                        Console.WriteLine("{0}-{1}-{2}-{3}-{4}-{5}", id, ean, tipoProducto, descripcion, precio, iva);

                        Console.WriteLine();

                        string? readResult;
                        Console.WriteLine("¿Desea guardar el archivo en sistema: s/n?");
                        readResult = Console.ReadLine();

                        if (readResult != null)
                        {
                            readResult = readResult.ToLower();
                        }
                        
                        if (readResult == "s")
                        {
                            Productos productos = new Productos();
                            //productos.Id_producto = new Guid();
                            productos.IdProducto = id;
                            productos.Ean = ean;
                            productos.TipoProducto = tipoProducto;
                            productos.Descripcion = descripcion;
                            productos.Precio = precio;
                            productos.Iva = iva;

                            _productoServicio.AgregarProductos(productos);

                            Console.WriteLine("Archivo cargado con exito");
                            Console.WriteLine();
                            //Console.ReadKey();
                        }
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
