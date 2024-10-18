using OOP_Practical;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    private static void Main(string[] args)
    {
        Alien_ship[] ships = new Alien_ship[10];//array of 10 ships

        StreamReader file = new StreamReader("./resources/ships.txt");//open streamreader
        {
            for (int i = 0; i < ships.Length; i++) //loop through the file storing groups to temp
            {
                string tempName = file.ReadLine();
                int tempHP = Convert.ToInt32(file.ReadLine());
                int tempSpeed = Convert.ToInt32(file.ReadLine());
                int tempDamage = Convert.ToInt32(file.ReadLine());
                bool tempFriendly = Convert.ToBoolean(file.ReadLine());
                ships[i] = new Alien_ship(tempName, tempHP, tempSpeed, tempDamage, tempFriendly);//instantiate new alienship from temp
            }
        }
        file.Close();//close the file

        find_ships(ships, 20, 10, false);
    }

    private static void find_ships(Alien_ship[] ships, int speed, int damage, bool friendly)
    {
        bool one_match = false;

        foreach (var ship in ships)
        {
            bool matching = ship.get_speed() >= speed && ship.get_damage() >= damage && ship.get_friendly() == friendly;
            if (!matching)
            {
                continue;
            }

            System.Console.WriteLine("Matching ship: " + ship.get_name() + ", " + ship.get_hit_points() + ", " + ship.get_speed() + ", " + ship.get_damage() + ", " + ship.get_friendly());
            one_match = true;
        }

        if (!one_match) {
            System.Console.WriteLine("No ships found");
                }
    }
}