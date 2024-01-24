using Microsoft.Extensions.DependencyInjection;
using System;
using RubiksCubeShared.Interfaces;
using RubiksCubeShared;

class Program
{
    static void Main()
    {
        var services = new ServiceCollection()
        .AddTransient<RubiksCore.RubiksCube>()
        .AddTransient<IRubiksCubePrinter, RubiksCubePrinter>()
        .AddTransient<IRubiksCubeInputs, RubiksCubeInputs>()
                .BuildServiceProvider();
        var cube = services.GetRequiredService<RubiksCore.RubiksCube>();
        var printer = services.GetRequiredService<IRubiksCubePrinter>();
        var baseCube = cube.Copy();
        /*Console.WriteLine("Initial Cube State:");
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

        printer.PrintCube(cube.Cubies);
        bool runRubiks = true;

        while (runRubiks)
        {
            Console.WriteLine("If you wish to exit the rubiks cube from here simply hit the escape key");
            Console.WriteLine("This is an emulated Rubiks cube would you like to see the demo turns affect the cube?");
            Console.WriteLine("'Y' (Yes, show result after demo turns of Front clockwise, right counter clockwise, Up clockwise, Back counter clockwise, left and finall down counter clockwise");
            Console.WriteLine("'N' (No, I want to input my own)");
            ConsoleKeyInfo info = Console.ReadKey(true);
            if(info.Key == ConsoleKey.Escape)
            {
                runRubiks = false;
                return;
            }
            var isYes = info.KeyChar == 'y';
            var isNo = info.KeyChar == 'n';

            if (!isYes && !isNo)
                continue;

            //Console.WriteLine(cube.ToString());
            if (isYes)
            {
                cube.TurnFront();
                cube.TurnRight(RubiksCore.TurningDirection.NineoClock);
                cube.TurnUp();
                cube.TurnBack(RubiksCore.TurningDirection.NineoClock);
                cube.TurnLeft();
                cube.TurnDown(RubiksCore.TurningDirection.NineoClock);

                printer.PrintCube(cube.Cubies);

                //reset cube
                cube = baseCube.Copy();
                continue;
            }
            var controls = services.GetRequiredService<IRubiksCubeInputs>();
            bool customInstructions = true;
            Console.WriteLine("What would you like it to do? (use the instructions in the readme file)");
            Console.WriteLine("If you wish to leave the custom input then use the 'c' key to cancel");
            while (customInstructions)
            {
                var input = Console.ReadLine();
                if(input?.Trim().ToLowerInvariant() == "c")
                {
                    customInstructions = false;
                    continue;
                }
                controls.TurnCube(input, cube);
                printer.PrintCube(cube.Cubies);
            }


        }



        //Console.WriteLine(cube.ToString());

        /*foreach (var cubie in cube.Cubies)
        {
            Console.WriteLine(cubie.Position.ToString());
        }*/
    }
}


