public class Shinigamis
{
    public int vida { get; set; }
    public int ataque { get; set; }
    public int defensa { get; set; }

    public Shinigamis(int vida, int ataque, int defensa)
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
        Random random = new Random();
        int dado1 = random.Next(1, 7);
        int dado2 = random.Next(1, 7); 
        return dado1 + dado2;
    }
}