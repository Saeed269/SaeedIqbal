public class Hollows
{
    public int vida { get; set; }
    public int ataque { get; set; }
    public int defensa { get; set; }

    public int nivel { get; set; } = 10;
    public int puntosHabilidad { get; set; } = 0;
    public int contadorVictorias { get; set; } = 0;

    private Random random = new Random();

    public Hollows(int vida, int ataque, int defensa)
    {
        this.vida = vida;
        this.ataque = ataque;
        this.defensa = defensa;
    }

    public virtual void Atacar()
    {
        Console.WriteLine("Atacando al enemigo...");
    }

    public virtual int TiraDeDados()
    {
        int dado1 = random.Next(1, 7);
        int dado2 = random.Next(1, 7); 
        return dado1 + dado2;
    }

    public int CalcularAtaque()
    {
        int tirada = TiraDeDados();
        int bonus = (int)(puntosHabilidad * 0.10);
        int totalAtaque = tirada + ataque + bonus;

        Console.WriteLine($"{GetType().Name} realiza una tirada: {tirada} + Ataque base {ataque} + Bonus ({bonus}) = Total: {totalAtaque}");
        return totalAtaque;
    }

    public void SubirNivel()
    {
        nivel++;
        contadorVictorias++;

        Console.WriteLine($"{GetType().Name} sube al nivel {nivel}");

        if (contadorVictorias % 2 == 0)
        {
            puntosHabilidad++;
            Console.WriteLine($"{GetType().Name} gana un punto de habilidad. Total: {puntosHabilidad}");
        }
    }

    public bool CombateAutomatico(int nivelEnemigo)
    {
        return this.nivel > nivelEnemigo;
    }
}
