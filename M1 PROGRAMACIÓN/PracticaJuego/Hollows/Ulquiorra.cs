public class Ulquiorra : Hollows
{
    public Ulquiorra(int vida, int ataque, int defensa) : base(vida, ataque, defensa)
    {
        this.vida = vida;
        this.ataque = ataque;
        this.defensa = defensa;
    }

    public override void Atacar()
    {
        Console.WriteLine("Ulquiorra ataca con su Cero!");
    }
    
    public override int TiraDeDados()
    {
        Random random = new Random();
        int dado1 = random.Next(1, 7);
        int dado2 = random.Next(1, 7); 
        return dado1 + dado2;
    }
}