using System;
using System.ComponentModel;

namespace data_structures
{
    internal class Program


    {
        static void Main(string[] args)
        {
            Person[] persons = PersonProducer();
            BinaryHeap<Person> minHeap = new BinaryHeap<Person>(0);
            BinaryHeap<Person> maxHeap = new BinaryHeap<Person>(5, new PersonAgeDESCComparer());
            Stack<Person> stack = new Stack<Person>();
            Queue<Person> queue = new Queue<Person>(5);
            foreach (Person person in persons)
            {
                //minHeap.Add(person);
                //maxHeap.Add(person);
                //stack.Push(person);
                //queue.Add(person);
            }
            //IteratorPrinter(minHeap.Iterator());
            //IteratorPrinter(maxHeap.Iterator());
            //IteratorPrinter(stack.Iterator());
            //IteratorPrinter(queue.Iterator());

            //QueueWrapSim();
        }


        private static void IteratorPrinter<T>(Iterator<T> iterator)
        {
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
            Console.WriteLine();
        }

        private static void IteratorLinePrinter<T>(Iterator<T> iterator)
        {
            while (iterator.HasNext())
            {
                Console.Write(iterator.Next() + " ");
            }
            Console.WriteLine();
        }

        private static Person[] PersonProducer()
        {
            Person[] persons = new Person[]
            {
                new Person("GrandMother", 11),
                new Person("GrandFather", 13),
                new Person("GrandGrandMother", 15),
                new Person("Brother", 5),
                new Person("Sister", 3),
                new Person("GrandGrandFather", 17),
                new Person("Mother", 7),
                new Person("Father", 9),
                new Person("SisterDuplicate", 3)
            };

            return persons;
        }




        //private static void QueueWrapSim()
        //{
        //    Queue<int> queue = new Queue<int>(5);
        //    queue.Add(1);
        //    queue.Add(2);
        //    queue.Add(3);
        //    queue.Add(4);
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Removing " + queue.Remove());
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Removing " + queue.Remove());
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Adding 5 ");
        //    queue.Add(5);
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Adding 6 ");
        //    queue.Add(6);
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Removing " + queue.Remove());
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Adding 7 ");
        //    queue.Add(7);
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Adding 8 ");
        //    queue.Add(8);
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Removing " + queue.Remove());
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Adding 9, 10, 11, 12 ");
        //    queue.Add(9);
        //    queue.Add(10);
        //    queue.Add(11);
        //    queue.Add(12);
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Adding 13 ");
        //    queue.Add(13);
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();

        //    Console.WriteLine("Adding 14 ");
        //    queue.Add(14);
        //    IteratorLinePrinter(queue.Iterator());
        //    queue.PrintInternalState();
        //}

    }
}
