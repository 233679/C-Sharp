using Linked_List;

internal class Program
{
    private static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();
        
        linkedList.AddAtLast("A");
        linkedList.AddAtLast("B");
        linkedList.AddAtLast("C");

        Console.WriteLine(linkedList.ToString());

        linkedList.AddAtLast("Z");
        linkedList.RemoveFromStart();

        Console.WriteLine(linkedList.ToString());

        linkedList.AddAtStart("E");

        Console.WriteLine(linkedList.ToString());

        linkedList.RemoveFromEnd();
        linkedList.RemoveFromEnd();
        linkedList.RemoveFromEnd();

        Console.WriteLine(linkedList.ToString());
    }
}