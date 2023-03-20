
namespace data_structures
{
    internal class HTPerson
    {

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public HTPerson(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return "HT_Person={firstName={'" + firstName + "', lastName='" + lastName + "'}";
        }

    }
}
