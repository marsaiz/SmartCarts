using SmartCarts.Libreria.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;


namespace SmartCarts.Libreria.Repositorios;

public class SmartCartsContexto : DbContext
{
    private static SmartCartsContexto instanciaContexto;
    private readonly string _cadenaConexion;
    private SmartCartsContexto(string cadenaConexion)
    {
        _cadenaConexion = cadenaConexion;
    }

    public DbSet<Productos> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(_cadenaConexion);
        optionsBuilder.UseNpgsql(_cadenaConexion);
        base.OnConfiguring(optionsBuilder);

    }

    public static SmartCartsContexto CrearInstancia()
    {
        if (instanciaContexto == null)
        {
            instanciaContexto = new SmartCartsContexto("Server=localhost;Database=smartcarts;User Id=postgres;Password=marcelo");
            //instanciaContexto = new SmartCartsContexto("User ID=marcelo_user;Password=marcelo;Host=localhost;Port=5432;Database=postgres;");
            ///instanciaContexto = new SmartCartsContexto("User ID=marcelo_user;Password=marcelo;Host=localhost;Port=5432;Database=postgres;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;");

        }
        return instanciaContexto;
    }
}