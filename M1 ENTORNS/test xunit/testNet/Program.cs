// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
 internal partial class Program
 {
    private static void Main(string[] args)
    {
    }
    public static int sum(int a, int b){
        return a+b;
    }

    public static int Restar(int a, int b) => a - b; 

    public static int Multiplicar(int a, int b) => a * b;

    public static double Dividir(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("No se puede dividir por cero");
        return a / b;
    }
    public static bool EsPar(int numero) => numero % 2 == 0;
 }