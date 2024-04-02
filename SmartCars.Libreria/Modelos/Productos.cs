using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Dynamic;

namespace SmartCarts.Libreria.Modelos;

[Table("productos")]
public class Productos
{
    [Key]
    [Column("id_producto")]
    public Guid Id_producto { get; set; }
    
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
        return string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}", IdProducto, Ean, TipoProducto, Descripcion, Precio, Iva);
    }
}
