using Hash_Table;

internal class Program
{
    private static void Main(string[] args)
    {
        HashMap map = new HashMap(11);
        map.Add("Mia", 123);
        map.Add("Tim", 456);
        map.Add("Bea", 645);
        map.Add("Zoe", 089);
        map.Add("Sue", 189);
        map.Add("Len", 289);
        map.Add("Moe", 489);
        map.Add("Lou", 389);
        map.Add("Rae", 589);
        map.Add("Max", 689);
        map.Add("Tod", 889);

        while (true)
        {
            Console.WriteLine("Enter a name to search for it. Blank to quit");
            string? name = Console.ReadLine();

            if (name == null || name == "") { break;}

            int name_index = map.Find(name);

            if (name_index == -1)
            {
                Console.WriteLine($"{name} is not in the map");
            }
            else
            {
                Console.WriteLine($"{name} is located at {name_index} within the map");
            }
        }

    }
}