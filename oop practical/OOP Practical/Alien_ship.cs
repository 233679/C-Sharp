using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practical
{
    internal class Alien_ship : Space_object
    {
        private int speed;
        private int damage;
        private bool friendly;

        public Alien_ship(string name, int hit_points, int speed, int damage, bool friendly) : base(name, hit_points)
        {
            this.speed = speed;
            this.damage = damage;
            this.friendly = friendly;
        }

        public int get_speed() { 
            return speed; }

        public int get_damage() { return damage; }

        public bool get_friendly() { return friendly; }

        public void set_speed(int speed) { this.speed = speed; }
        public void set_damage(int damage) { this.damage = damage; }
        public void set_friendly(bool friendly) { this.friendly = friendly; }
    }
}
