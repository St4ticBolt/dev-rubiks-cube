
using RubiksCubeShared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeShared
{
    public class RubiksCubeInputs : IRubiksCubeInputs
    {
        public string[] inputs = ["f", "fi", "r", "ri", "u", "ui", "b", "bi", "l", "li", "d", "di"];
        public void TurnCube(string input, RubiksCore.RubiksCube cube)
        {
            switch (input.ToLowerInvariant())
            {
                case "f":
                    cube.TurnFront();
                    break;
                case "fi":
                    cube.TurnFront(RubiksCore.TurningDirection.NineoClock);
                    break;
                case "r":
                    cube.TurnRight();
                    break;
                case "ri":
                    cube.TurnRight(RubiksCore.TurningDirection.NineoClock);
                    break;
                case "u":
                    cube.TurnUp();
                    break;
                case "ui":
                    cube.TurnUp(RubiksCore.TurningDirection.NineoClock);
                    break;
                case "b":
                    cube.TurnBack();
                    break;
                case "bi":
                    cube.TurnBack(RubiksCore.TurningDirection.NineoClock);
                    break;
                case "l":
                    cube.TurnLeft();
                    break;
                case "li":
                    cube.TurnLeft(RubiksCore.TurningDirection.NineoClock);
                    break;
                case "d":
                    cube.TurnDown();
                    break;
                case "di":
                    cube.TurnDown(RubiksCore.TurningDirection.NineoClock);
                    break;
                case "s":
                    string message = cube.IsSolved ? "Cube has been solved well done!" : "Cube is not yet solved, keep trying!";
                    Console.WriteLine(message);
                    break;

                default:
                    Console.WriteLine("Unfortunately that command doesn't match the inputs please try again.");
                    break;
            }
        }
    }
}
