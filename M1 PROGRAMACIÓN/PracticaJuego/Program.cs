using System;
using System.Threading;

internal class Program
{
    private static void Main(string[] args)
    {
        Hollows grimmjow = new Grimmjow(200, 70, 50); 
        Hollows ulquiorra = new Ulquiorra(220, 80, 60);
        Hollows nel = new Nel(180, 75, 55);

        Shinigamis aizen = new Aizen(210, 85, 65);
        Shinigamis ichigo = new Ichigo(190, 90, 70);
        Shinigamis kenpachi = new Kenpachi(180, 80, 60);

        Console.WriteLine("Bienvenido al juego de Bleach!");
        Console.WriteLine("Elige tu personaje:");
        Console.WriteLine("1. Grimmjow");
        Console.WriteLine("2. Ulquiorra");
        Console.WriteLine("3. Nel");
        Console.Write("Selecciona un número: ");

        int seleccion = int.Parse(Console.ReadLine());
        Hollows personajeSeleccionado = seleccion switch
        {
            1 => grimmjow,
            2 => ulquiorra,
            3 => nel,
            _ => null
        };

        if (personajeSeleccionado == null)
        {
            Console.WriteLine("Selección inválida. Saliendo del juego.");
            return;
        }

        Console.WriteLine("Ahora elige a tu enemigo:");
        Console.WriteLine("1. Aizen");
        Console.WriteLine("2. Ichigo");
        Console.WriteLine("3. Kenpachi");
        Console.Write("Selecciona un número: ");

        int seleccionEnemigo = int.Parse(Console.ReadLine());
        Shinigamis enemigoSeleccionado = seleccionEnemigo switch
        {
            1 => aizen,
            2 => ichigo,
            3 => kenpachi,
            _ => null
        };

        if (enemigoSeleccionado == null)
        {
            Console.WriteLine("Selección inválida. Saliendo del juego.");
            return;
        }

        Console.Clear();
        Console.WriteLine($"Has seleccionado: {personajeSeleccionado.GetType().Name}");
        Console.WriteLine($"Enemigo seleccionado: {enemigoSeleccionado.GetType().Name}");
        Console.WriteLine("¡Comienza la batalla!");

        int turno = 1;

        
        while (personajeSeleccionado.vida > 0 && enemigoSeleccionado.vida > 0)
        {
            Console.WriteLine($"\n--- Turno {turno} ---");

            
            if (personajeSeleccionado.CombateAutomatico(enemigoSeleccionado.defensa))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                EscribirConEfecto("¡Tu nivel supera al enemigo! Ganas automáticamente el combate.");
                Console.ResetColor();
                enemigoSeleccionado.vida = 0;
                personajeSeleccionado.SubirNivel();
                break;
            }

            
            int ataqueJugador = personajeSeleccionado.CalcularAtaque() / 2;  
            enemigoSeleccionado.vida -= ataqueJugador;
            if (enemigoSeleccionado.vida < 0) enemigoSeleccionado.vida = 0;

        
            ImpactoDeAtaque($"¡{personajeSeleccionado.GetType().Name} realiza un ataque!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            EscribirConEfecto($"{enemigoSeleccionado.GetType().Name} tiene {enemigoSeleccionado.vida} puntos de vida restantes.");
            Console.ResetColor();

            if (enemigoSeleccionado.vida == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                EscribirConEfecto($"\n{enemigoSeleccionado.GetType().Name} ha sido derrotado.");
                Console.ResetColor();
                personajeSeleccionado.SubirNivel();
                break;
            }

            
            FondoIntenso();

            
            int dadosEnemigo = enemigoSeleccionado.TiraDeDados();
            int ataqueEnemigo = dadosEnemigo + enemigoSeleccionado.ataque;

            
            SonidoDeAtaque();
            Console.WriteLine($"{enemigoSeleccionado.GetType().Name} contraataca con una tirada de {dadosEnemigo} + Ataque base {enemigoSeleccionado.ataque} = Total: {ataqueEnemigo}");

            
            personajeSeleccionado.vida -= ataqueEnemigo / 2;
            if (personajeSeleccionado.vida < 0) personajeSeleccionado.vida = 0;

            Console.ForegroundColor = ConsoleColor.Red;
            EscribirConEfecto($"{personajeSeleccionado.GetType().Name} tiene {personajeSeleccionado.vida} puntos de vida restantes.");
            Console.ResetColor();

            if (personajeSeleccionado.vida == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                EscribirConEfecto($"\n{personajeSeleccionado.GetType().Name} ha sido derrotado.");
                Console.ResetColor();
                break;
            }

            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
            turno++;
        }

        Console.WriteLine("\n--- Fin de la batalla ---");
        Console.WriteLine("Gracias por jugar.");
    }

    
    static void EscribirConEfecto(string texto)
    {
        foreach (char c in texto)
        {
            Console.Write(c);
            Thread.Sleep(100); 
        }
        Console.WriteLine(); 
    }

    
    static void EfectoExplosivo()
    {
        string[] particulas = { "*", ".", "o", "#", "+" };
        Random random = new Random();

        for (int i = 0; i < 10; i++) 
        {
            int delay = random.Next(50, 100); 
            Console.SetCursorPosition(random.Next(0, Console.WindowWidth), random.Next(0, Console.WindowHeight)); 
            Console.ForegroundColor = (ConsoleColor)random.Next(1, 16); 
            Console.Write(particulas[random.Next(0, particulas.Length)]);
            Thread.Sleep(delay);
        }

        Console.ResetColor();
    }

    
    static void FondoIntenso()
    {
        Random random = new Random();
        for (int i = 0; i < 5; i++)  
        {
            Console.BackgroundColor = (ConsoleColor)random.Next(1, 16);  
            Console.Clear(); 
            Thread.Sleep(100); 
        }

        Console.BackgroundColor = ConsoleColor.Black; 
        Console.Clear();
    }


    static void SonidoDeAtaque()
    {
        Console.Beep(500, 300);  
        Console.Beep(700, 300);  
    }

    
    static void ImpactoDeAtaque(string mensaje)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.ForegroundColor = (ConsoleColor)new Random().Next(1, 16);  
            Console.WriteLine(mensaje.ToUpper()); 
            Thread.Sleep(100);
        }
        Console.ResetColor();
    }
}
