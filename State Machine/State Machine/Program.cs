internal partial class Program
{
    // Mermaid graph:
    //
    //stateDiagram-v2
    //Y3 --> O4: b
    //O4 --> R8: a
    //R8 --> Y3: c
    //Y3 --> B2: a
    //B2 --> G6: b
    //G6 --> Y7: a
    //Y7 --> B2: c
    //B2 --> R1: a
    //R1 --> Y3: a
    //R1 --> P5: b
    //P5 --> B0: a
    //B0 --> R1: c

    private static void Main(string[] args)
    {
        // 0 - Y3
        // 1 - O4
        // 2 - R8
        // 3 - B2
        // 4 - G6
        // 5 - Y7
        // 6 - R1
        // 7 - P5
        // 8 - B0

        // Move matrix
        Path[,] matrix = {
            //      | Y3     | O4    | R8    | B2    | G6    | Y7    | R1    | P5    | B0
            /**Y3*/ { Path.N, Path.B, Path.N, Path.A, Path.N, Path.N, Path.N, Path.N, Path.N, },
            /**O4*/ { Path.N, Path.N, Path.A, Path.N, Path.N, Path.N, Path.N, Path.N, Path.N, },
            /**R8*/ { Path.C, Path.N, Path.N, Path.N, Path.N, Path.N, Path.N, Path.N, Path.N, },
            /**B2*/ { Path.N, Path.N, Path.N, Path.N, Path.B, Path.N, Path.A, Path.N, Path.N, },
            /**G6*/ { Path.N, Path.N, Path.N, Path.N, Path.N, Path.A, Path.N, Path.N, Path.N, },
            /**Y7*/ { Path.N, Path.N, Path.N, Path.C, Path.N, Path.N, Path.N, Path.N, Path.N, },
            /**R1*/ { Path.A, Path.N, Path.N, Path.N, Path.N, Path.N, Path.N, Path.B, Path.N, },
            /**P5*/ { Path.N, Path.N, Path.N, Path.N, Path.N, Path.N, Path.N, Path.N, Path.A, },
            /**B0*/ { Path.N, Path.N, Path.N, Path.N, Path.N, Path.N, Path.C, Path.N, Path.N, },
        };

        // Start at Y3
        int pos = 0;

        // Whatever key, it will get overriden
        ConsoleKey key = ConsoleKey.T;

        // Quit on Q
        while (key != ConsoleKey.Q)
        {
            // Find valid moves
            int a = -1;
            int b = -1;
            int c = -1;

            for (int i = 0; i < 9; i++)
            {
                Path path = (Path)matrix.GetValue(pos, i);

                switch (path)
                {
                    case Path.A:
                        a = i;
                        break;
                    case Path.B:
                        b = i;
                        break;
                    case Path.C:
                        c = i;
                        break;
                    case Path.N:
                        break;
                }

            }

            // Decode position
            String place;
            if (pos == 0) { place = "Y3"; }
            else if (pos == 1) { place = "O4"; }
            else if (pos == 2) { place = "R8"; }
            else if (pos == 3) { place = "B2"; }
            else if (pos == 4) { place = "G6"; }
            else if (pos == 5) { place = "Y7"; }
            else if (pos == 6) { place = "R1"; }
            else if (pos == 7) { place = "P5"; }
            else if (pos == 8) { place = "B0"; }
            else { throw new Exception(); }

            // Inform user
            Console.WriteLine($"You are at: {place}");

            Console.Write("Valid moves: ");
            if (a != -1) { Console.Write("A, "); }
            if (b != -1) { Console.Write("B, "); }
            if (c != -1) { Console.Write("C, "); }
            Console.Write("Q (quit)\n");

            Console.Write("Your move: ");

            // Get move
            key = Console.ReadKey().Key;

            // Add some nice space
            Console.WriteLine("\n");

            // Act upon moves

            if (key == ConsoleKey.A)
            {
                if (a == -1)
                {
                    Console.WriteLine("Invalid move");
                }
                else
                {
                    {
                        pos = a; continue;
                    }
                }
            }

            if (key == ConsoleKey.B)
            {
                if (b == -1)
                {
                    Console.WriteLine("Invalid move");
                }
                else
                {
                    { pos = b; continue; }
                }
            }

            if (key == ConsoleKey.C)
            {
                if (c == -1)
                {
                    Console.WriteLine("Invalid move");
                }
                else
                {
                    { pos = c; continue; }
                }
            }

        }

    }
}