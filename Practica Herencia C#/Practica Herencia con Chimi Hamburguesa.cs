using System;
using System.Collections.Generic;

public class Hamburguesa
{
    protected string tipoPan;
    protected string tipoCarne;
    protected double precioBase;
    protected List<string> ingredientesAdicionales;
    protected double precioIngredientesAdicionales;

    public Hamburguesa(string tipoPan, string tipoCarne, double precioBase)
    {
        this.tipoPan = tipoPan;
        this.tipoCarne = tipoCarne;
        this.precioBase = precioBase;
        this.ingredientesAdicionales = new List<string>();
        this.precioIngredientesAdicionales = 0;
    }

    public void AgregarIngrediente(string ingrediente, double precioAdicional)
    {
        if (ingredientesAdicionales.Count < 4)
        {
            ingredientesAdicionales.Add(ingrediente);
            precioIngredientesAdicionales += precioAdicional;
        }
        else
        {
            Console.WriteLine("¡Ya ha alcanzado el máximo de ingredientes adicionales!");
        }
    }

    public virtual void MostrarPrecio()
    {
        Console.WriteLine("Hamburguesa " + tipoCarne + " con " + tipoPan + ":");
        Console.WriteLine("Precio Base: $" + precioBase);
        Console.WriteLine("Ingredientes Adicionales:");
        foreach (var ingrediente in ingredientesAdicionales)
        {
            Console.WriteLine("- " + ingrediente);
        }
        Console.WriteLine("Precio Ingredientes Adicionales: $" + precioIngredientesAdicionales);
        Console.WriteLine("Total: $" + (precioBase + precioIngredientesAdicionales));
    }
}

public class HamburguesaSaludable : Hamburguesa
{
    private List<string> ingredientesSaludables;
    private double precioIngredientesSaludables;

    public HamburguesaSaludable(string tipoPan, string tipoCarne, double precioBase) 
        : base(tipoPan, tipoCarne, precioBase)
    {
        ingredientesSaludables = new List<string>();
        precioIngredientesSaludables = 0;
    }

    public void AgregarIngredienteSaludable(string ingrediente, double precioAdicional)
    {
        if (ingredientesSaludables.Count < 2)
        {
            ingredientesSaludables.Add(ingrediente);
            precioIngredientesSaludables += precioAdicional;
        }
        else
        {
            Console.WriteLine("¡Ya ha alcanzado el máximo de ingredientes saludables!");
        }
    }

    public override void MostrarPrecio()
    {
        base.MostrarPrecio();
        Console.WriteLine("Ingredientes Saludables:");
        foreach (var ingrediente in ingredientesSaludables)
        {
            Console.WriteLine("- " + ingrediente);
        }
        Console.WriteLine("Precio Ingredientes Saludables: $" + precioIngredientesSaludables);
        Console.WriteLine("Total: $" + (precioBase + precioIngredientesAdicionales + precioIngredientesSaludables));
    }
}

public class HamburguesaPremium : Hamburguesa
{
    private const double PrecioPapitas = 2.5;
    private const double PrecioBebida = 1.5;

    public HamburguesaPremium(string tipoPan, string tipoCarne, double precioBase) 
        : base(tipoPan, tipoCarne, precioBase)
    {
        AgregarIngrediente("Papitas", PrecioPapitas);
        AgregarIngrediente("Bebida", PrecioBebida);
    }

    public override void MostrarPrecio()
    {
        base.MostrarPrecio();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Hamburguesa hamburguesaClasica = new Hamburguesa("Blanco", "Res", 5.0);
        hamburguesaClasica.AgregarIngrediente("Lechuga", 1.0);
        hamburguesaClasica.AgregarIngrediente("Tomate", 0.5);
        hamburguesaClasica.MostrarPrecio();

        HamburguesaSaludable hamburguesaSaludable = new HamburguesaSaludable("Integral", "Pavo", 6.0);
        hamburguesaSaludable.AgregarIngrediente("Espinacas", 1.0);
        hamburguesaSaludable.AgregarIngredienteSaludable("Aguacate", 1.5);
        hamburguesaSaludable.MostrarPrecio();

        HamburguesaPremium hamburguesaPremium = new HamburguesaPremium("Blanco", "Pollo", 7.0);
        hamburguesaPremium.MostrarPrecio();
    }
}
