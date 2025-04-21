using System;
using System.Collections.Generic;
using System.Linq;

public interface IEntity
{
    int Id { get; set; }
}

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}


public interface IRepository<T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T Get(int id);
    void Add(T item);
    void Update(T item);
    void Delete(int id);
}

public class Repository<T> : IRepository<T> where T : class, IEntity
{
    private readonly Dictionary<int, T> _storage = new();
    private int _nextId = 1;

    public IEnumerable<T> GetAll() => _storage.Values;

    public T Get(int id) => _storage.TryGetValue(id, out var item) ? item : null;

    public void Add(T item)
    {
        item.Id = _nextId++;
        _storage[item.Id] = item;
        Console.WriteLine($"{typeof(T).Name} added with ID: {item.Id}");
    }

    public void Update(T item)
    {
        if (_storage.ContainsKey(item.Id))
        {
            _storage[item.Id] = item;
            Console.WriteLine($"{typeof(T).Name} updated.");
        }
        else
        {
            Console.WriteLine($"{typeof(T).Name} not found.");
        }
    }

    public void Delete(int id)
    {
        if (_storage.Remove(id))
        {
            Console.WriteLine($"{typeof(T).Name} deleted.");
        }
        else
        {
            Console.WriteLine($"{typeof(T).Name} not found.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        IRepository<Product> productRepo = new Repository<Product>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu:\n1. Add Product\n2. Get Product\n3. Update Product\n4. Delete Product\n5. List All Products\n6. Exit");
            Console.Write("\nChoose option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var newProduct = new Product();
                    Console.Write("\nEnter product name: ");
                    newProduct.Name = Console.ReadLine();
                    Console.Write("Enter price: ");
                    newProduct.Price = int.Parse(Console.ReadLine());
                    productRepo.Add(newProduct);
                    break;

                case "2":
                    Console.Write("\nEnter Product ID: ");
                    int idToGet = int.Parse(Console.ReadLine());
                    var found = productRepo.Get(idToGet);
                    if (found != null)
                        Console.WriteLine($"\nID: {found.Id}, Name: {found.Name}, Price: {found.Price}");
                    else
                        Console.WriteLine("\nProduct not found.");
                    break;

                case "3":
                    Console.Write("\nEnter ID to update: ");
                    int idToUpdate = int.Parse(Console.ReadLine());
                    var productToUpdate = productRepo.Get(idToUpdate);
                    if (productToUpdate != null)
                    {
                        Console.Write("\nNew name: ");
                        productToUpdate.Name = Console.ReadLine();
                        Console.Write("New price: ");
                        productToUpdate.Price = int.Parse(Console.ReadLine());
                        productRepo.Update(productToUpdate);
                    }
                    else
                    {
                        Console.WriteLine("\nProduct not found.");
                    }
                    break;

                case "4":
                    Console.Write("\nEnter ID to delete: ");
                    int idToDelete = int.Parse(Console.ReadLine());
                    productRepo.Delete(idToDelete);
                    break;

                case "5":
                    var products = productRepo.GetAll();
                    if (!products.Any())
                        Console.WriteLine("\nNo products found.");
                    else
                    {
                        Console.WriteLine("\n------Products------");
                        foreach (var p in products)
                            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price}");
                    }
                    break;

                case "6":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Try again.");
                    break;
            }
        }
    }
}
