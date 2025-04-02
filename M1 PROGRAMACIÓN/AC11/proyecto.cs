using System;

// Tarea 1: Gestión de Proyectos
class Proyecto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int DiasRestantes { get; set; }
    public List<Empleado> Empleados { get; set; } = new List<Empleado>();
    public List<Tarea> Tareas { get; set; } = new List<Tarea>();
    public decimal CostoEstimado { get => DiasRestantes * PrecioPorDia; }
    public string Estado { get; set; }
    private const decimal PrecioPorDia = 100m; 

    public int TotalTareasPendientes() => Tareas.Count(t => t.Estado == "Pendiente");
    public int NumeroDeEmpleados() => Empleados.Count;
}

class Empleado
{
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
}

class Tarea
{
    public string Nombre { get; set; }
    public string Estado { get; set; }
    public string Descripcion { get; set; }
}

// Tarea 2: Gestión de Clientes y Proveedores
class Cliente
{
    public string Nombre { get; set; }
    public string DNI { get; set; }
    public decimal PagoRealizado { get; set; }
    public decimal Adelanto { get; set; }
}

class Proveedor
{
    public string Nombre { get; set; }
    public string DNI { get; set; }
}

class Program
{
    static void Main()
    {
        Proyecto proyecto = new Proyecto
        {
            Nombre = "Desarrollo Web",
            Descripcion = "Creación de una plataforma web",
            DiasRestantes = 30,
            Estado = "En progreso"
        };
        
        proyecto.Empleados.Add(new Empleado { Nombre = "Juan", Cargo = "Desarrollador", Salario = 2500 });
        proyecto.Tareas.Add(new Tarea { Nombre = "Diseño UI", Estado = "Pendiente", Descripcion = "Diseñar la interfaz gráfica" });
        
        Cliente cliente = new Cliente { Nombre = "Empresa X", DNI = "12345678A", PagoRealizado = 5000, Adelanto = 2000 };
        Proveedor proveedor = new Proveedor { Nombre = "Proveedor Y", DNI = "87654321B" };
        
        Console.WriteLine($"Proyecto: {proyecto.Nombre}");
        Console.WriteLine($"Tareas pendientes: {proyecto.TotalTareasPendientes()}");
        Console.WriteLine($"Número de empleados: {proyecto.NumeroDeEmpleados()}");
        Console.WriteLine($"Costo estimado: {proyecto.CostoEstimado}€");
        
        Console.WriteLine($"Cliente: {cliente.Nombre}, DNI: {cliente.DNI}, Pago Realizado: {cliente.PagoRealizado}€, Adelanto: {cliente.Adelanto}€");
        Console.WriteLine($"Proveedor: {proveedor.Nombre}, DNI: {proveedor.DNI}");
    }
}
