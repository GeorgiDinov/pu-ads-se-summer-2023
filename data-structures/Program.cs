using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (Person person in persons)
            {
                minHeap.Add(person);
                maxHeap.Add(person);
                stack.Push(person);
            }

            //IteratorPrinter(minHeap.Iterator());
            //IteratorPrinter(maxHeap.Iterator());
            //IteratorPrinter(stack.Iterator());
        }


        private static void IteratorPrinter<T>(Iterator<T> iterator)
        {
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
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
    }
}
