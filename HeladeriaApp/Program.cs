using HeladeriaApp.Modelo;
using HeladeriaApp.Servicios;

// Crear servicios
var servicioHelado = new ServicioHelado();
var servicioCliente = new ServicioCliente();
var servicioPedido = new ServicioPedido();

// Crear cliente
var cliente = new Cliente
{
    Id = 1,
    Nombre = "Juan",
    Telefono = "123456"
};

servicioCliente.Crear(cliente);

// Crear helados
var helado1 = new Helado
{
    Id = 1,
    Nombre = "Chocolate",
    Precio = 5000,
    Sabor = new Sabor { Id = 1, Nombre = "Chocolate" }
};

var helado2 = new Helado
{
    Id = 2,
    Nombre = "Vainilla",
    Precio = 4000,
    Sabor = new Sabor { Id = 2, Nombre = "Vainilla" }
};

servicioHelado.Crear(helado1);
servicioHelado.Crear(helado2);

// Crear pedido
var pedido = new Pedido
{
    Id = 1,
    Fecha = DateTime.Now,
    Cliente = cliente,
    Detalles = new List<DetallePedido>
    {
        new DetallePedido { Id = 1, Helado = helado1, Cantidad = 2 },
        new DetallePedido { Id = 2, Helado = helado2, Cantidad = 1 }
    }
};

servicioPedido.Crear(pedido);

// Mostrar datos
Console.WriteLine("=== HELADOS ===");
foreach (var h in servicioHelado.Leer())
{
    Console.WriteLine($"{h.Id} - {h.Nombre} - {h.Precio}");
}

Console.WriteLine("\n=== CLIENTES ===");
foreach (var c in servicioCliente.Leer())
{
    Console.WriteLine($"{c.Id} - {c.Nombre} - {c.Telefono}");
}

Console.WriteLine("\n=== PEDIDOS ===");
foreach (var p in servicioPedido.Leer())
{
    Console.WriteLine($"Pedido {p.Id} - Cliente: {p.Cliente.Nombre}");
}