using System;

namespace Task_06
{
    // Define a delegate
    public delegate void ThresholdReachedHandler(int value);

    // Define the Counter class
    class Counter
    {
        private int value = 0;
        private int threshold;

        // Declare the event using the delegate
        public event ThresholdReachedHandler ThresholdReached;

        public Counter(int threshold)
        {
            this.threshold = threshold;
        }

        // Increment method
        public void Increment()
        {
            value++;
            Console.WriteLine($"Counter: {value}");

            if (value >= threshold)
            {
                // Raise the event
                ThresholdReached?.Invoke(value);
            }
        }
    }

    class Program
    {
        // Event handler method 1
        static void AlertHandler(int value)
        {
            Console.WriteLine($"[ALERT] Threshold reached at: {value}");
        }

        // Event handler method 2
        static void LogHandler(int value)
        {
            Console.WriteLine($"[LOG] Counter hit {value}, logged to file (pretend).");
        }

        static void Main(string[] args)
        {
            Counter counter = new Counter(threshold: 5);

            // Subscribe methods to the event
            counter.ThresholdReached += AlertHandler;
            counter.ThresholdReached += LogHandler;

            // Main loop - simulate counting
            for (int i = 0; i < 10; i++)
            {
                counter.Increment();
                System.Threading.Thread.Sleep(500); // Slow down
            }
        }
    }
}
