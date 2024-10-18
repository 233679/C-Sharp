using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practical
{
    internal class Space_object
    {
        private string name;
        private int hit_points;

        public Space_object(string name, int hit_points)
        {
            this.name = name;
            this.hit_points = hit_points;
        }

        public string get_name() { return name; }
        public int get_hit_points() { return hit_points; }
    }
}
