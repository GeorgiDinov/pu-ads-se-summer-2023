using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    internal class Person : IComparable<Person>
    {


        private string name;

        public string MyProperty
        {
            get { return name; }
            set { name = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }



        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return "Person={age=" + age + ", name=" + name + "}";
        }

        public int CompareTo(Person other)
        {
            int otherAge = other.age;
            if (age == otherAge)
            {
                return 0;
            }
            if (age < otherAge)
            {
                return -1;
            }
            return 1;
        }
    }
}
