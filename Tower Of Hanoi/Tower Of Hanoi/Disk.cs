using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Of_Hanoi
{
    internal class Disk
    {

        public int id { get; }

        public Disk(int id)
        {
            this.id = id;
        }

        public override string? ToString()
        {
            return this.id.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Disk disk &&
                   id == disk.id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id);
        }
    }
}
