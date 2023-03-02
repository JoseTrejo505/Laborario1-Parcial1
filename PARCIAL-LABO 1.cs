using System;
using System.Collections.Generic;

public class Libro
{
    // Atributos
    public string Titulo { get; }
    public string Autor { get; }
    public string Descripcion { get; }
    public decimal Precio { get; }
    public int CantidadEnInventario { get; private set; }
    public string Categoria { get; }

    // Constructor
    public Libro(string titulo, string autor, string descripcion, decimal precio, int cantidadEnInventario, string categoria)
    {
        Titulo = titulo;
        Autor = autor;
        Descripcion = descripcion;
        Precio = precio;
        CantidadEnInventario = cantidadEnInventario;
        Categoria = categoria;
    }

    // Métodos
    public decimal ObtenerPrecio()
    {
        return Precio;
    }

    public string ObtenerTitulo()
    {
        return Titulo;
    }

    public string ObtenerAutor()
    {
        return Autor;
    }

    public string ObtenerDescripcion()
    {
        return Descripcion;
    }

    public int ObtenerCantidad()
    {
        return CantidadEnInventario;
    }

    public string ObtenerCategoria()
    {
        return Categoria;
    }

    public void DisminuirCantidad(int cantidad)
    {
        if (cantidad <= CantidadEnInventario)
        {
            CantidadEnInventario -= cantidad;
        }
        else
        {
            Console.WriteLine("No hay suficientes libros en inventario.");
        }
    }

    public void AumentarCantidad(int cantidad)
    {
        CantidadEnInventario += cantidad;
    }
}

public class CarritoDeCompras
{
    // Atributos
    private List<Libro> libros = new List<Libro>();

    // Constructor
    public CarritoDeCompras() { }

    // Métodos
    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
    }

    public void RemoverLibro(Libro libro)
    {
        libros.Remove(libro);
    }

    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (Libro libro in libros)
        {
            total += libro.ObtenerPrecio();
        }
        return total;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        // Crear algunos libros
        Libro libro1 = new Libro("El código Da Vinci", "Dan Brown", "Un asesinato en el Louvre", 10.99m, 5, "Ficción");
        Libro libro2 = new Libro("Introducción a la programación con C#", "John Doe", "Un libro para principiantes", 29.99m, 3, "No ficción");

        // Crear un carrito de compras
        CarritoDeCompras carrito = new CarritoDeCompras();

        // Agregar algunos libros al carrito
        carrito.AgregarLibro(libro1);
        carrito.AgregarLibro(libro2);

        // Calcular el total
        decimal total = carrito.CalcularTotal();
        Console.WriteLine("El total es: $" + total);
    }
}
