# **Task 8: Generics and Interfaces with a Repository Pattern**

## **Objective:**

Build a **generic in-memory repository** using C# that performs basic **CRUD operations**, demonstrating how to work with **interfaces, generics**, and **type constraints** effectively. The application includes a simple **console-based UI** for interacting with a sample entity (`Product`).

---

## **Requirements:**

- Define an `IRepository<T>` interface for CRUD operations.
- Implement a **generic repository class** with in-memory storage.
- Use **type constraints** to enforce structure (`where T : class, IEntity`).
- Create a sample entity class (`Product`) that implements `IEntity`.
- Implement a **console menu** for user interaction.

---

## **Key Components:**

### `IEntity` Interface
- Defines the required `Id` property for all entities.

```csharp
public interface IEntity
{
    int Id { get; set; }
}
```
### `Product` Class
- Sample entity to demonstrate CRUD operations.

```csharp
public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}
```

### `IRepository<T>` Interface

- Generic interface defining CRUD operations.

```csharp
public interface IRepository<T> where T : class, IEntity
{
    IEnumerable<T> GetAll();
    T Get(int id);
    void Add(T item);
    void Update(T item);
    void Delete(int id);
}
```

### `Repository<T>` Class

- In-memory implementation of the IRepository<T> interface.

```csharp
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
```


## **Sample Output:**