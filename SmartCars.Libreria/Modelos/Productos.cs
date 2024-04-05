using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Dynamic;

namespace SmartCarts.Libreria.Modelos;

[Table("producto")]
public class Productos
{
    /* [Key]
    [Column("id_producto")]
    public Guid Id_producto { get; set; } */
    [Key]
    [Column("id")]
    public int IdProducto { get; set; }

    [Column("ean")]
    public long Ean {get ; set; }

    [Column("tipoproducto")]
    public string? TipoProducto {get ; set; }

    [Column("descripcion")]
    public string? Descripcion {get ; set; }

    [Column("precio")]
    public double Precio {get ; set; }

    [Column("iva")]
    public double Iva {get ; set; }

    public override string ToString()
    {
        return string.Format("Id Producto-{0}-Tipo Producto-{1}-Descripción-{2}-Precio Producto-${3}", IdProducto, TipoProducto, Descripcion, Precio);
    }
}
