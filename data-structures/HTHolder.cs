
namespace data_structures
{
    internal class HTHolder
    {
        private string key;

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private HTPerson value;

        public HTPerson Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public HTHolder(string key, HTPerson value)
        {
            this.key = key;
            this.value = value;
        }

    }
}
