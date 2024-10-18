using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table
{
    internal class HashMap
    {
        private int size;
        private (string, object)[] table;

        public HashMap(int size)
        {
            this.size = size;
            this.table = new (string, object)[size];
        }

        private int Hash(string key)
        {
            return (Math.Abs(key.GetHashCode()) % this.size);
        }

        public void Add(string key, object value)
        {
            int index = Hash(key);
            int count = 0;

            while (count < this.size)
            {
                // Exit if found space.
                if (this.table[index].Item1 == null)
                {
                    this.table[index] = (key, value);
                    return;
                }

                // Iterate though each index of the array.
                index++;
                index = index % size;

                count++;
            }
        }

        public int Find(string key)
        {
            int index = Hash(key);
            int count = 0;

            // Loop until all indexes have been checked.
            while (count < this.size)
            {
                // Exit if found space.
                if (this.table[index].Item1 == key)
                {
                    return index;
                }

                // Iterate though each index of the array.
                index++;
                index = index % size;

                count++;
            }

            // Returns -1 if key not in map.
            return -1;
        }
    }
}
