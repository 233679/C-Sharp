using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        // Prompt user for input.
        Console.Write("Enter input string\n: ");
        string? input = Console.ReadLine();

        // Exit early if null.
        if (input == null)
        {
            return;
        }

        // Change type from nullable string to non-null string.
        string text = input;
        string output = "";

        while (text.Length > 0)
        {
            // Get the letter and the amount of times it repeats from the start of the string.
            char start_letter = text.ElementAt(0);
            int repeating = text.TakeWhile(letter => letter == start_letter).ToArray().Length;
            
            // Combine that with the output buffer
            output += repeating.ToString() + start_letter.ToString();

            // Removed parsed chars from start of text.
            text = text.Remove(0, repeating);
        }

        // Output the buffer
        Console.WriteLine(output);
    }
}