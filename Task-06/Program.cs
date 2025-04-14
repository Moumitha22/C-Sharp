using System;
using System.Threading;

namespace Task_06
{
    // Define a delegate
    public delegate void ThresholdReachedHandler(int value);

    class Counter
    {
        private int value = 0;
        private int threshold;
        private int end;

        // Declare the event using the delegate
        public event ThresholdReachedHandler ThresholdReached;

        public Counter(int threshold, int end)
        {
            this.threshold = threshold;
            this.end = end;
        }

        // Increment method
        public void Increment()
        {
            value++;
            Console.WriteLine($"Counter: {value}");

            if (value == threshold || value == end)
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
            Console.WriteLine($"\n[ALERT] Threshold reached at: {value}");
        }

        // Event handler method 2
        static void LogHandler(int value)
        {
            Console.WriteLine($"[LOG] Counter hit {value}.\n");
        }

        static void Main(string[] args)
        {
            Counter counter = new Counter(threshold: 5, end : 10);

            // Subscribe methods to the event
            counter.ThresholdReached += AlertHandler;
            counter.ThresholdReached += LogHandler;

            for (int i = 0; i < 10; i++)
            {
                counter.Increment();

                if (i == 4) // When i == 4, counter value becomes 5 -> we unsubscribe LogHandler
                {
                    counter.ThresholdReached -= LogHandler; // Unsubscribe
                    Console.WriteLine("[INFO] LogHandler unsubscribed.\n");
                }

                Thread.Sleep(500); // Slow down
            }
        }
    }
}
