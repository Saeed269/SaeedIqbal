using System;

internal class Programa
{
    static void Main()
    {
        Console.WriteLine("===== Nave Estelar =====");
        NaveEstelar naveBasica = new NaveEstelar("Explorer I", 15000, 9000);
        naveBasica.ActivarSistemas();
        naveBasica.EjecutarMision();
        naveBasica.ApagarSistemas();

        Console.WriteLine("\n===== Nave de Combate =====");
        NaveCombate naveCombate = new NaveCombate("Fighter X", 12000, 15000, 7);
        naveCombate.ActivarSistemas();
        naveCombate.RealizarAtaque();
        naveCombate.EjecutarMision();
        naveCombate.ApagarSistemas();

        Console.WriteLine("\n===== Nave de Carga Especializada =====");
        NaveCargaEspecial naveCarga = new NaveCargaEspecial("Cargo Titan", 25000, 8000, 10, 2500);
        naveCarga.ActivarSistemas();
        naveCarga.RealizarAtaque();
        naveCarga.EjecutarMision(); 
        naveCarga.MostrarCarga();
        naveCarga.ApagarSistemas();
    }
}


class NaveEstelar
{
    public string Nombre { get; set; }
    public int CapacidadCarga { get; set; } 
    public int VelocidadMaxima { get; set; }

    public NaveEstelar(string nombre, int capacidadCarga, int velocidadMaxima)
    {
        Nombre = nombre;
        CapacidadCarga = capacidadCarga;
        VelocidadMaxima = velocidadMaxima;
    }

    public virtual void ActivarSistemas()
    {
        Console.WriteLine($"La nave estelar {Nombre} ha activado sus sistemas.");
    }

    public virtual void EjecutarMision()
    {
        Console.WriteLine($"La nave estelar {Nombre} está realizando una misión de exploración.");
    }

    public virtual void ApagarSistemas()
    {
        Console.WriteLine($"La nave estelar {Nombre} ha apagado sus sistemas.");
    }
}


class NaveCombate : NaveEstelar
{
    public int PotenciaAtaque { get; set; }

    public NaveCombate(string nombre, int capacidadCarga, int velocidadMaxima, int potenciaAtaque)
        : base(nombre, capacidadCarga, velocidadMaxima)
    {
        PotenciaAtaque = potenciaAtaque;
    }

    public override void ActivarSistemas()
    {
        Console.WriteLine($"La nave de combate {Nombre} ha activado sus sistemas de combate.");
    }

    public virtual void RealizarAtaque()
    {
        Console.WriteLine($"La nave de combate {Nombre} está atacando con potencia de fuego nivel {PotenciaAtaque}.");
    }
}


class NaveCargaEspecial : NaveCombate
{
    public int KilosCargados { get; set; }

    public NaveCargaEspecial(string nombre, int capacidadCarga, int velocidadMaxima, int potenciaAtaque, int kilosCargados)
        : base(nombre, capacidadCarga, velocidadMaxima, potenciaAtaque)
    {
        KilosCargados = kilosCargados;
    }

    public override void EjecutarMision()
    {
        Console.WriteLine($"La nave de carga especializada {Nombre} está defendiendo el espacio alrededor del planeta X.");
    }

    public void MostrarCarga()
    {
        Console.WriteLine($"La nave de carga lleva una cantidad de carga de {KilosCargados}Kg");
    }

    public override void ApagarSistemas()
    {
        Console.WriteLine($"La nave de carga especializada {Nombre} ha apagado sus sistemas.");
    }

    public override void RealizarAtaque()
    {
        Console.WriteLine($"La nave de carga especializada {Nombre} está atacando con potencia de fuego nivel {PotenciaAtaque}.");
    }
}
