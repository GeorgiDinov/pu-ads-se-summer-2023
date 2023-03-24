using System;

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
            ListBackedStack<Person> listBackedStack = new ListBackedStack<Person>();
            Queue<Person> queue = new Queue<Person>(5);
            ListBackedQueue<Person> listBackedQueue = new ListBackedQueue<Person>();

            foreach (Person person in persons)
            {
                //minHeap.Add(person);
                //maxHeap.Add(person);
                //stack.Push(person);
                //listBackedStack.Push(person);
                //queue.Add(person);
                //listBackedQueue.Add(person);
            }
            //IteratorPrinter(minHeap.Iterator());
            //IteratorPrinter(maxHeap.Iterator());
            //IteratorPrinter(stack.Iterator());
            //IteratorPrinter(listBackedStack.Iterator());
            //IteratorPrinter(queue.Iterator());
            //IteratorPrinter(listBackedQueue.Iterator());



            //QueueWrapSim();
            //LinkedListSim();
            //ArrayListSim();
            //HTLinearProbingSim();
            BSTreeSim();
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

        private static void BSTreeSim()
        {
            int[] values = { 25, 20, 15, 27, 30, 29, 26, 22, 32, 17 };
            BSTree<int> tree = new BSTree<int>();
            foreach (int value in values)
            {
                tree.Insert(value);
            }

            tree.TraverseInOrder();
            tree.TraversePreOrder();
            tree.TraversePostOrder();

            Console.WriteLine("min = " + tree.Min());
            Console.WriteLine("max = " + tree.Max());

            Console.WriteLine("get 30 = " + tree.Get(30));
            Console.WriteLine("get 15 = " + tree.Get(15));
            Console.WriteLine("get 25 = " + tree.Get(25));
            Console.WriteLine("get 8888 = " + tree.Get(8888));// will return default - '0'

            Console.WriteLine("Deleting 30 ");
            tree.Delete(30);
            tree.TraverseInOrder();
            Console.WriteLine("Deleting 15");
            tree.Delete(15);
            tree.TraverseInOrder();
            Console.WriteLine("Deleting 25");
            tree.Delete(25);
            tree.TraverseInOrder();
            Console.WriteLine("Deleting 8888");
            tree.Delete(8888);
            tree.TraverseInOrder();
        }


        private static void ArrayListSim()
        {
            ArrayList<Person> arrayList = new ArrayList<Person>(5);
            arrayList.Add(0, new Person("TST", 100));

            Person[] people = PersonProducer();
            for (int i = 0; i < people.Length; i++)
            {
                arrayList.Add(people[i]);
            }

            IteratorPrinter(arrayList.Iterator());

            Console.WriteLine("Size = " + arrayList.Size());
            for (int i = 0; i < arrayList.Size(); i++)
            {
                Console.WriteLine(arrayList.Get(i));
            }

            Console.WriteLine(arrayList.Contains(people[3]));
            Console.WriteLine(arrayList.Contains(null));
            Console.WriteLine(arrayList.Contains(new Person("Test", 5)));

            //Console.WriteLine(arrayList.Remove(new Person("Test", 5)));
            Console.WriteLine("Removing " + arrayList.Remove(people[4]));
            Console.WriteLine("Size = " + arrayList.Size());
            Console.WriteLine();
            IteratorPrinter(arrayList.Iterator());

            Console.WriteLine("Removing " + arrayList.Remove(people[0]));
            Console.WriteLine("Size = " + arrayList.Size());
            Console.WriteLine();
            IteratorPrinter(arrayList.Iterator());

            Console.WriteLine("Removing " + arrayList.Remove(people[people.Length - 1]));
            Console.WriteLine("Size = " + arrayList.Size());
            Console.WriteLine();
            IteratorPrinter(arrayList.Iterator());

            Console.WriteLine("Removing " + arrayList.Remove(0));
            Console.WriteLine("Size = " + arrayList.Size());
            Console.WriteLine();
            IteratorPrinter(arrayList.Iterator());

            Console.WriteLine("Removing " + arrayList.Remove(2));
            Console.WriteLine("Size = " + arrayList.Size());
            Console.WriteLine();
            IteratorPrinter(arrayList.Iterator());


            Console.WriteLine("Removing " + arrayList.Remove(arrayList.Size() - 1));
            Console.WriteLine("Size = " + arrayList.Size());
            Console.WriteLine();
            IteratorPrinter(arrayList.Iterator());

            while (!arrayList.IsEmpty())
            {
                Console.WriteLine("Removing " + arrayList.Remove(0));
                //Console.WriteLine("Removing " + arrayList.Remove(arrayList.Size() - 1));
            }
            Console.WriteLine("Size = " + arrayList.Size());
        }


        private static void LinkedListSim()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            IteratorLinePrinter(linkedList.Iterator());
            Console.WriteLine("LinkedList size = " + linkedList.Size());

            linkedList.AddLast(4);
            Console.WriteLine("LinkedList size = " + linkedList.Size());
            IteratorLinePrinter(linkedList.Iterator());

            linkedList.Add(5);
            Console.WriteLine("LinkedList size = " + linkedList.Size());
            IteratorLinePrinter(linkedList.Iterator());

            Console.WriteLine("Removing " + linkedList.RemoveFirst());
            Console.WriteLine("LinkedList size = " + linkedList.Size());
            IteratorLinePrinter(linkedList.Iterator());

            Console.WriteLine("Removing " + linkedList.RemoveLast());
            Console.WriteLine("LinkedList size = " + linkedList.Size());
            IteratorLinePrinter(linkedList.Iterator());


            linkedList.AddFirst(10);
            Console.WriteLine("LinkedList size = " + linkedList.Size());
            IteratorLinePrinter(linkedList.Iterator());

            linkedList.AddFirst(11);
            Console.WriteLine("LinkedList size = " + linkedList.Size());
            IteratorLinePrinter(linkedList.Iterator());

            Console.WriteLine("Removing " + linkedList.RemoveFirst());
            Console.WriteLine("LinkedList size = " + linkedList.Size());
            IteratorLinePrinter(linkedList.Iterator());

            linkedList.AddLast(20);
            Console.WriteLine("LinkedList size = " + linkedList.Size());
            IteratorLinePrinter(linkedList.Iterator());

            while (!linkedList.IsEmpty())
            {
                Console.WriteLine("Peek first " + linkedList.PeekFirst());
                Console.WriteLine("Peek last" + linkedList.PeekLast());
                Console.WriteLine("Removing " + linkedList.RemoveFirst());
                IteratorLinePrinter(linkedList.Iterator());
            }
            Console.WriteLine("LinkedList size = " + linkedList.Size());
            linkedList.PeekFirst();
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

        private static void HTLinearProbingSim()
        {
            int someLentgh = 10;
            for (int i = 0; i < someLentgh; i++)
            {
                string msg = i + " % " + someLentgh + " = " + (i % someLentgh);
                Console.WriteLine(msg);
            }
            string msg2 = 135 + " % " + someLentgh + " = " + (135 % someLentgh);
            Console.WriteLine(msg2);
            Console.WriteLine();
            Console.WriteLine("HT sim start point");

            HTPerson p1 = new HTPerson("Ivan", "Ivanov");
            HTPerson p2 = new HTPerson("Stoqn", "Stefanov");
            HTPerson p3 = new HTPerson("Marin", "Petev");
            HTPerson p4 = new HTPerson("Georgi", "Petrov");
            HTPerson p5 = new HTPerson("John", "Doe");

            HTLinearProbing hashTable = new HTLinearProbing();
            hashTable.Put(p1.LastName, p1);
            hashTable.Put(p2.LastName, p2);
            hashTable.Put(p3.LastName, p3);
            hashTable.Put(p4.LastName, p4);
            hashTable.Put(p5.LastName, p5);

            Console.WriteLine("HT size = " + hashTable.Size());
            Console.WriteLine(String.Format("Load Factor = {0, -20}", hashTable.LoadFactor()));
            Console.WriteLine();
            Console.WriteLine("HT state: ");
            hashTable.Print();

            Console.WriteLine();

            Console.WriteLine("Remove " + hashTable.Remove(p2.LastName));
            Console.WriteLine("HT size = " + hashTable.Size());
            Console.WriteLine(String.Format("Load Factor = {0, -20}", hashTable.LoadFactor()));
            Console.WriteLine();
            Console.WriteLine("HT state: ");
            hashTable.Print();

            Console.WriteLine();

            Console.WriteLine("Remove " + hashTable.Remove(p1.LastName));
            Console.WriteLine("HT size = " + hashTable.Size());
            Console.WriteLine(String.Format("Load Factor = {0, -20}", hashTable.LoadFactor()));
            Console.WriteLine();
            Console.WriteLine("HT state: ");
            hashTable.Print();

            HTPerson p6 = new HTPerson("John", "Smit");
            hashTable.Put(p6.LastName, p6);
            Console.WriteLine("HT size = " + hashTable.Size());
            Console.WriteLine(String.Format("Load Factor = {0, -20}", hashTable.LoadFactor()));
            Console.WriteLine();
            Console.WriteLine("HT state: ");
            hashTable.Print();

            HTPerson p7 = new HTPerson("Dan", "Don");
            hashTable.Put(p7.LastName, p7);
            Console.WriteLine("HT size = " + hashTable.Size());
            Console.WriteLine(String.Format("Load Factor = {0, -20}", hashTable.LoadFactor()));
            Console.WriteLine();
            Console.WriteLine("HT state: ");
            hashTable.Print();

            Console.WriteLine();

            Console.WriteLine("Remove " + hashTable.Remove(p4.LastName));
            Console.WriteLine("HT size = " + hashTable.Size());
            Console.WriteLine(String.Format("Load Factor = {0, -20}", hashTable.LoadFactor()));
            Console.WriteLine();
            Console.WriteLine("HT state: ");
            hashTable.Print();

            Console.WriteLine();

            //removing non existing
            Console.WriteLine("Remove " + hashTable.Remove(p4.LastName));
            Console.WriteLine("HT size = " + hashTable.Size());
            Console.WriteLine(String.Format("Load Factor = {0, -20}", hashTable.LoadFactor()));
            Console.WriteLine();
            Console.WriteLine("HT state: ");
            hashTable.Print();

            Console.WriteLine();

            Console.WriteLine("Remove " + hashTable.Remove(p5.LastName));
            Console.WriteLine("HT size = " + hashTable.Size());
            Console.WriteLine(String.Format("Load Factor = {0, -20}", hashTable.LoadFactor()));
            Console.WriteLine();
            Console.WriteLine("HT state: ");
            hashTable.Print();

        }

    }
}
