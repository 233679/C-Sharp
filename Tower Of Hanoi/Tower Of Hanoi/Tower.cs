using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tower_Of_Hanoi
{
    internal class Tower
    {
        private readonly int size;
        private Queue<Disk> tower_A;
        private Queue<Disk> tower_B;
        private Queue<Disk> tower_C;

        public Tower(int size)
        {
            this.size = size;
            this.tower_A = new Queue<Disk>();
            this.tower_B = new Queue<Disk>();
            this.tower_C = new Queue<Disk>();

            for (int i = 0; i < size; i++) {
                tower_A.Enqueue(new Disk(i));
                //this.tower_A.Append(new Disk(i));
            }
            tower_A.Reverse();

            //Console.WriteLine(tower_A.LongCount());
        }

        public static void solve(int number, string beg, string end, string aux)
        {
            if (number == 1)
            {
                System.Console.WriteLine("Move disk from pole " + beg + " to pole " + end);
            }
            else
            {
                solve(number - 1, beg, aux, end);
                solve(1, beg, end, aux);
                solve(number - 1, aux, end, beg);
            }
        }

        public void my_solve()
        {
            my_solve(size, tower_A, tower_B, tower_C);
        }

        private static void my_solve(int number, Queue<Disk> tower_a, Queue<Disk> tower_b, Queue<Disk> tower_c)
        {
            if (number == 1)
            {
                if (tower_a.Count != 0)
                {
                    Disk disk1 = tower_a.Dequeue();
                    tower_b.Reverse();
                    tower_b.Enqueue(disk1);
                    tower_b.Reverse();
                }
                System.Console.WriteLine(new Tower(number, tower_a, tower_b, tower_c).ToString());
                // System.Console.WriteLine("Tower A: " + tower_a.ToString() + "\nTower B: " + tower_b.ToString() + "\nTower C: " + tower_c.ToString() + "\n");

            } else
            {
                my_solve(number - 1, tower_a, tower_b, tower_c);
                my_solve(1, tower_a, tower_c, tower_b);
                my_solve(number - 1, tower_b, tower_c, tower_a);
            }
        }

        public override string? ToString()
        {
            string data = "";
            data += "\nTower A: ";
            foreach (var disk in tower_A)
            {
                data += disk + ", ";
            }
            data += "\nTower B: ";
            foreach (var disk in tower_B)
            {
                data += disk + ", ";
            }
            data += "\nTower C: ";
            foreach (var disk in tower_C)
            {
                data += disk + ", ";
            }

            return data;
        }

        public Tower(int size, Queue<Disk> tower_A, Queue<Disk> tower_B, Queue<Disk> tower_C) : this(size)
        {
            this.tower_A = tower_A;
            this.tower_B = tower_B;
            this.tower_C = tower_C;
        }
    }
}
