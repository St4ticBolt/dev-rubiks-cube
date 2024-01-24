using RubiksCore;
using RubiksCubeShared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeShared
{
    public class RubiksCubePrinter : IRubiksCubePrinter
    {
        public void PrintCube(IEnumerable<Cubie> cubies)
        {
            // Define an array of characters to represent the colors
            char[] symbols = new char[] { 'B', 'G', 'O', 'R', 'W', 'Y' };
            // Define an array of console colors to match the symbols
            ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.DarkYellow, ConsoleColor.Red, ConsoleColor.White, ConsoleColor.Yellow };
            // Define an array of faces to print in the net of a cube
            RubiksDirection[] faces = new RubiksDirection[] { RubiksDirection.Left, RubiksDirection.Up, RubiksDirection.Front, RubiksDirection.Back, RubiksDirection.Down, RubiksDirection.Right };
            // Define an array of offsets to print the faces in the correct position
            //int[,] offsets = new int[,] { { 0, 3 }, { 0, 0 }, { 0, 1 }, { 0, 2 }, { 0, 4 }, { 1, 1 } };
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
                    //}
                }

                Console.WriteLine();

            }
            // Reset the foreground color of the console
            Console.ResetColor();
        }
    }
}
