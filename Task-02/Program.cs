namespace Task_02
{
    class Person
    {
        // Fields
        string name = string.Empty; // Prevent null warning
        private int age;

        // Default Constructor
        public Person() { }

        // Parameterized Constructor
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        // Auto - properties
        //public string Name { get; set; }
        //public int Age { get; set; }

        // Method
        public void Introduce()
        {
            Console.WriteLine($"Hi, I am {name}. \nI am {age} years old!\n");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Using default constructor
            Person person1 = new Person();
            person1.Introduce();

            // Using parameterized constructor
            Person person2 = new Person("Kalki", 38);
            person2.Introduce();

            // Property initialization
            Person person3 = new Person();
            person3.Name = "Dia";
            person3.Age = 18;
            person3.Introduce();

            // Object initializer
            Person person4 = new Person() { Name = "Nila", Age = 21 };
            person4.Introduce();

            // Shorthand initializer
            Person person5 = new() { Name = "Thara", Age = 32 };
            person5.Introduce();
        }
    }
}
