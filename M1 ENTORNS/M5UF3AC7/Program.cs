using System;
using System.Collections.Generic;
using System.Linq;

public class Ingredient
{
    public string Nom { get; set; }
    public float QuantitatEnGrams { get; set; }

    public Ingredient(string nom, float quantitatEnGrams)
    {
        Nom = nom;
        QuantitatEnGrams = quantitatEnGrams;
    }

    public override string ToString()
    {
        return $"{Nom} - {QuantitatEnGrams}g";
    }
}

public class Plat
{
    public string Nom { get; set; }
    private List<Ingredient> ingredients = new List<Ingredient>();

    public Plat(string nom)
    {
        Nom = nom;
    }

    public void AfegirIngredient(Ingredient ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void EliminarIngredient(string nomIngredient)
    {
        ingredients.RemoveAll(i => i.Nom.ToLower() == nomIngredient.ToLower());
    }

    public void MostrarIngredients()
    {
        Console.WriteLine($"Ingredients del plat '{Nom}':");
        foreach (var ingredient in ingredients)
        {
            Console.WriteLine($"- {ingredient}");
        }
    }

    public List<Ingredient> GetIngredients()
    {
        return ingredients;
    }
}

public class GestorReceptes
{
    private List<Plat> plats = new List<Plat>();

    public void AfegirPlat(Plat plat)
    {
        plats.Add(plat);
    }

    public void MostrarPlats()
    {
        foreach (var plat in plats)
        {
            Console.WriteLine($"\nPlat: {plat.Nom}");
            plat.MostrarIngredients();
        }
    }
}


class Program
{
    static void Main()
    {
        var gestor = new GestorReceptes();

        var paella = new Plat("Paella");
        paella.AfegirIngredient(new Ingredient("Arròs", 200));
        paella.AfegirIngredient(new Ingredient("Pollastre", 150));
        paella.AfegirIngredient(new Ingredient("Pebrot", 50));

        gestor.AfegirPlat(paella);

        var amanida = new Plat("Amanida");
        amanida.AfegirIngredient(new Ingredient("Enciam", 100));
        amanida.AfegirIngredient(new Ingredient("Tomàquet", 80));
        amanida.AfegirIngredient(new Ingredient("Ceba", 30));

        gestor.AfegirPlat(amanida);

        gestor.MostrarPlats();
    }
}

