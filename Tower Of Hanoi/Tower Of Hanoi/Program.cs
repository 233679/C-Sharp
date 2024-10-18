using System.Security.Cryptography.X509Certificates;
using Tower_Of_Hanoi;

internal class Program
{
    private static void Main(string[] args)
    {
        Tower tower = new Tower(3);
        //tower.my_solve();
        Tower.solve(3, "a", "c", "b");
    }
}