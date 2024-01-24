using Microsoft.Extensions.DependencyInjection;
/*using RubiksCubeShared;
using RubiksCubeShared.Interfaces;*/
using System;
using RubiksCore;

class Program
{
    static void Main()
    {
       /* var services = new ServiceCollection()
        .AddTransient<IRubiksCube, RubiksCube>()
                .BuildServiceProvider();
        var cube = services.GetRequiredService<IRubiksCube>();

        Console.WriteLine("Initial Cube State:");
        cube.PrintCube();

        // Apply face rotations
        cube.RotateFrontClockwise();
        cube.PrintCube();
        //cube.RotateRightCounterClockwise();
        //cube.PrintCube();
        //cube.RotateUpClockwise();
        //cube.PrintCube();
        //cube.RotateBackCounterClockwise();
        //cube.PrintCube();
        //cube.RotateLeftClockwise();
        //cube.PrintCube();
        //cube.RotateDownCounterClockwise();
        //cube.PrintCube();

        Console.WriteLine("\nCube State After Rotations:");
        cube.PrintCube();*/

        RubiksCube cube = new RubiksCube();


        PrintCube(cube.Cubies);

        //Console.WriteLine(cube.ToString());

        cube.TurnFront();
        cube.TurnRight(TurningDirection.NineoClock);
        cube.TurnUp();
        cube.TurnBack(TurningDirection.NineoClock);
        cube.TurnLeft();
        cube.TurnDown(TurningDirection.NineoClock);

        PrintCube(cube.Cubies);

        //Console.WriteLine(cube.ToString());

        /*foreach (var cubie in cube.Cubies)
        {
            Console.WriteLine(cubie.Position.ToString());
        }*/
    }

    public static void PrintCube(IEnumerable<Cubie> cubies)
    {
        // Define an array of characters to represent the colors
        char[] symbols = new char[] { 'W', 'R', 'G', 'O', 'B', 'Y' };
        // Define an array of console colors to match the symbols
        ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.DarkYellow, ConsoleColor.Blue, ConsoleColor.Yellow };
        // Define an array of faces to print in the net of a cube
        RubiksDirection[] faces = new RubiksDirection[] { RubiksDirection.Left, RubiksDirection.Up,  RubiksDirection.Front,  RubiksDirection.Back, RubiksDirection.Down, RubiksDirection.Right };
        // Define an array of offsets to print the faces in the correct position
        int[,] offsets = new int[,] { { 0, 3 }, { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 4 }, { 1, 1 } };
        // Loop over the faces
        for (int f = 0; f < 6; f++)
        {
            // Get the current face
            RubiksDirection face = faces[f];

            // Use a foreach loop to iterate over the IEnumerable of Cubies
            foreach (Cubie cubie in cubies)
            {
                // Get the color of the current cubie
                RubiksColor? color = cubie.GetColor(face);
                // If the color is not null, print the corresponding symbol and color
                if (color != null)
                {
                    // Get the index of the color in the enum
                    int index = (int)color;
                    // Set the foreground color of the console
                    Console.ForegroundColor = colors[index];
                    // Write the symbol of the color
                    Console.Write(symbols[index]);
                }

            }
            // Write a new line after each row
            Console.WriteLine();

        }
        // Reset the foreground color of the console
        Console.ResetColor();
    }
}


