using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_08
{
    // 1. IEntity Interface
    public interface IEntity
    {
        int Id { get; set; }
    }

    // 2. Generic Repository Interface
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T item);
        void Delete(int id);
    }

    // 3. In-Memory Repository Implementation
    public class InMemoryRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item) => _items.Add(item);

        public IEnumerable<T> GetAll() => _items;

        public T GetById(int id) => _items.FirstOrDefault(x => x.Id == id);

        public void Update(T item)
        {
            var index = _items.FindIndex(x => x.Id == item.Id);
            if (index != -1)
                _items[index] = item;
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
                _items.Remove(item);
        }
    }

    // 4. Product Class (Sample Entity)
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    // 5. Program with Console UI
    class Program
    {
        static void Main()
        {
            IRepository<Product> repository = new InMemoryRepository<Product>();

            while (true)
            {
                Console.WriteLine("\n===== Product Repository Menu =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Get Product by ID");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        var p = new Product();
                        Console.Write("Enter Product ID: ");
                        p.Id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Product Name: ");
                        p.Name = Console.ReadLine();
                        Console.Write("Enter Product Price: ");
                        p.Price = double.Parse(Console.ReadLine());
                        repository.Add(p);
                        Console.WriteLine("Product added.");
                        break;

                    case "2":
                        var allProducts = repository.GetAll();
                        Console.WriteLine("\n--- All Products ---");
                        foreach (var prod in allProducts)
                            Console.WriteLine($"ID: {prod.Id}, Name: {prod.Name}, Price: ₹{prod.Price}");
                        break;

                    case "3":
                        Console.Write("Enter Product ID to find: ");
                        int findId = int.Parse(Console.ReadLine());
                        var found = repository.GetById(findId);
                        if (found != null)
                            Console.WriteLine($"Found: ID: {found.Id}, Name: {found.Name}, Price: ₹{found.Price}");
                        else
                            Console.WriteLine("Product not found.");
                        break;

                    case "4":
                        var update = new Product();
                        Console.Write("Enter Product ID to update: ");
                        update.Id = int.Parse(Console.ReadLine());
                        Console.Write("Enter new Name: ");
                        update.Name = Console.ReadLine();
                        Console.Write("Enter new Price: ");
                        update.Price = double.Parse(Console.ReadLine());
                        repository.Update(update);
                        Console.WriteLine("Product updated.");
                        break;

                    case "5":
                        Console.Write("Enter Product ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        repository.Delete(deleteId);
                        Console.WriteLine("Product deleted (if it existed).");
                        break;

                    case "6":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
