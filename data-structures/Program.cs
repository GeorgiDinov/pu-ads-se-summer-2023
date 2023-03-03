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
            foreach (Person person in persons)
            {
                minHeap.Add(person);
                maxHeap.Add(person);
            }

            Console.WriteLine("Iterate over min heap: ");
            Iterator<Person> minHeapIterator = minHeap.Iterator();
            while (minHeapIterator.HasNext())
            {
                Console.WriteLine(minHeapIterator.Next());
            }

            Console.WriteLine("Iterate over max heap: ");
            Iterator<Person> maxHeapIterator = maxHeap.Iterator();
            while (maxHeapIterator.HasNext())
            {
                Console.WriteLine(maxHeapIterator.Next());
            }

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
