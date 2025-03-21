
using Xunit;
public class testProgram
{
   [Fact] 
   public void passingAddTest()
   {
      Assert.Equal(4, Program.sum(2, 2)); 
      Assert.InRange(Program.sum(4, 6), 9, 11); 
   }

   [Fact] 
   public void Restar_DosNumeros_RetornaResta()
   {
      Assert.NotEqual(2, Program.Restar(10, 5)); 
      Assert.False(Program.Restar(10, 5) == 2); 
   }

   [Fact] 
   public void Multiplicar_DosNumeros_RetornaMultiplicacion()
   {
      Assert.True(Program.Multiplicar(3, 4) > 10); 
      Assert.Equal(12, Program.Multiplicar(3, 4)); 
   }

   [Fact] 
   public void Dividir_EntreCero_LanzaExcepcion()
   {
      Assert.Throws<DivideByZeroException>(() => Program.Dividir(10, 0)); 
   }

   [Fact] 
   public void EsPar_NumeroPar_DevuelveTrue()
   {
      Assert.True(Program.EsPar(8)); 
      Assert.False(Program.EsPar(9)); 
   }
}