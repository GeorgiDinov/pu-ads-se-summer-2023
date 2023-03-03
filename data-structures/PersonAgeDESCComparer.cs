using System.Collections.Generic;

namespace data_structures
{
    internal class PersonAgeDESCComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            // -1 to reverse the result, in the class is to give smaller age, this will return the greater as natural ordering
            return (-1) * x.Age.CompareTo(y.Age);
        }
    }
}
