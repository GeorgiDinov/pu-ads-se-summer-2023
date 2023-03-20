using System;

namespace data_structures
{
    internal class HTLinearProbing
    {

        private const int DefaultCapacity = 10;

        private int size;
        private HTHolder[] ht;

        public HTLinearProbing() : this(DefaultCapacity)
        {

        }

        public HTLinearProbing(int capacity)
        {
            this.size = 0;
            if (capacity < 10)
            {
                capacity = DefaultCapacity;
            }
            this.ht = new HTHolder[capacity];
        }

        public void Put(string key, HTPerson value)
        {
            int hashedKey = HashTheKey(key);
            if (IsTaken(hashedKey))
            {
                // prepare for linear probing
                int stopPoint = hashedKey;
                if (hashedKey == ht.Length - 1)
                {
                    hashedKey = 0;
                }
                else
                {
                    hashedKey = hashedKey + 1;
                }
                // Execute probing while we are not wrapped back to the starting point
                // Or we find free spot
                while (hashedKey != stopPoint && IsTaken(hashedKey))
                {
                    hashedKey = (hashedKey + 1) % ht.Length;
                }
            }
            if (IsTaken(hashedKey))
            {
                //No free spot, we are full, growing the array based on load factor, rehashing strategy
                Console.WriteLine("No space available");
            }
            else
            {
                ht[hashedKey] = new HTHolder(key, value);
                size++;
            }
        }

        public HTPerson Get(string key)
        {
            int hashedKey = FindKey(key);
            if (hashedKey == -1)
            {
                return null;
            }
            return ht[hashedKey].Value;
        }

        public HTPerson Remove(string key)
        {
            int hashedKey = FindKey(key);
            if (hashedKey == -1)
            {
                return null;
            }
            HTPerson value = ht[hashedKey].Value;
            ht[hashedKey] = null;
            //rehashing on removal
            HTHolder[] oldHT = ht;
            ht = new HTHolder[oldHT.Length];
            size = 0;
            foreach (HTHolder holder in oldHT)
            {
                if (holder != null)
                {
                    Put(holder.Key, holder.Value);
                }
            }
            return value;
        }

        public int Size()
        {
            return this.size;
        }

        public double LoadFactor()
        {
            return (double)size / ht.Length;
        }

        private int FindKey(string key)
        {
            int hashedKey = HashTheKey(key);
            if (ht[hashedKey] != null && ht[hashedKey].Key.Equals(key))
            {
                return hashedKey;
            }
            //prepare for linear probing
            int stopPoint = hashedKey;
            if (hashedKey == ht.Length - 1)
            {
                hashedKey = 0;
            }
            else
            {
                hashedKey = hashedKey + 1;
            }
            // Execute probing while we are not wrapped back to the starting point, while there is element
            // int the ht and while it is not a match - 'equals'
            while (hashedKey != stopPoint && IsTaken(hashedKey) && !ht[hashedKey].Key.Equals(key))
            {
                hashedKey = (hashedKey + 1) % ht.Length;
            }
            //First check if we didn't drop out of the loop because of no data, then compare the key
            if (ht[hashedKey] != null && ht[hashedKey].Key.Equals(key))
            {
                return hashedKey;
            }

            return -1;
        }

        private int HashTheKey(string key)
        {
            return key.Length % ht.Length;
        }

        private bool IsTaken(int index)
        {
            return ht[index] != null;
        }

        //For testing / demostrating purposes
        public void Print()
        {
            for (int i = 0; i < ht.Length; i++)
            {
                string msg = ht[i] != null ? i + ". " + ht[i].Value : i + ". ";
                Console.WriteLine(msg);
            }
        }

    }
}
