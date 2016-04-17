using System;
using System.Collections;

namespace SequentialCollections
{
    class RunQueue
    {
        static void Main(string[] args)
        {
            //Creating a queue
            Queue newQueue = new Queue();
            newQueue.Enqueue("First");
            newQueue.Enqueue("Second");
            newQueue.Enqueue("Third");
            newQueue.Enqueue("Fourth");

            Console.WriteLine("First element: {0}", newQueue.Peek());
            while (newQueue.Count > 0)
            {
                object obj = newQueue.Dequeue();
                Console.WriteLine("From queue: {0}", obj);
            }

            //Write blank line
            Console.WriteLine();

            //Creating a stack
            Stack newStack = new Stack();
            newStack.Push("First");
            newStack.Push("Second");
            newStack.Push("Third");
            newStack.Push("Fourth");

            Console.WriteLine("First element: {0}", newStack.Peek());
            while (newStack.Count > 0)
            {
                object obj = newStack.Pop();
                Console.WriteLine("From stack: {0}", obj);
            }
            
            Console.ReadKey();
        }
    }
}
