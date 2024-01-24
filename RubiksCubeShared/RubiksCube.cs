using RubiksCubeShared.Interfaces;

namespace RubiksCubeShared
{
    public class RubiksCube: IRubiksCube
    {
        // Represent the cube using a 3D array
        private char[,,] cube;

        public RubiksCube()
        {
            // Initialize the cube with the solved state
            cube = new char[3, 3, 6];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Set the initial colors based on the specified setup
                    cube[i, j, 0] = 'G'; // Green face || adjacent faces 1,4,3,5 || opposite face is 2
                    cube[i, j, 1] = 'W'; // White face || adjacent faces 0,4,2,
                    cube[i, j, 2] = 'B'; // Blue face
                    cube[i, j, 3] = 'O'; // Orange face
                    cube[i, j, 4] = 'R'; // Red face || adjacent faces 0,1,5,2 || opposite face is 3
                    cube[i, j, 5] = 'Y'; // Yellow face
                }
            }
        }

        public char[,,] Cube
        {
            get { return cube; }
        }

        public void RotateFrontClockwise()
        {
            RotateFaceClockwise(0);
            Console.WriteLine("Rotating Front Face Clockwise 90 degrees.");
        }

        public void RotateRightCounterClockwise()
        {
            RotateFaceCounterClockwise(4);
            Console.WriteLine("Rotating Right Face Counter-Clockwise 90 degrees.");
        }

        public void RotateUpClockwise()
        {
            RotateFaceClockwise(1);
            Console.WriteLine("Rotating Up Face Clockwise 90 degrees.");
        }

        public void RotateBackCounterClockwise()
        {
            RotateFaceCounterClockwise(3);
            Console.WriteLine("Rotating Back Face Counter-Clockwise 90 degrees.");
        }

        public void RotateLeftClockwise()
        {
            RotateFaceClockwise(4);
            Console.WriteLine("Rotating Left Face Clockwise 90 degrees.");
        }

        public void RotateDownCounterClockwise()
        {
            RotateFaceCounterClockwise(5);
            Console.WriteLine("Rotating Down Face Counter-Clockwise 90 degrees.");
        }

        private void RotateFaceClockwise(int faceIndex)
        {
            char[,] originalFace = new char[3, 3];
            char[,] rotatedFace = new char[3, 3];

            // Copy the original face
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    originalFace[i, j] = cube[i, j, faceIndex];
                }
            }

            // Rotate the face clockwise
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rotatedFace[j, 2 - i] = originalFace[i, j];
                }
            }

            // Copy the rotated face back to the cube
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cube[i, j, faceIndex] = rotatedFace[i, j];
                }
            }
        }

        private void RotateFaceCounterClockwise(int faceIndex)
        {
            char[,] originalFace = new char[3, 3];
            char[,] rotatedFace = new char[3, 3];

            // Copy the original face
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    originalFace[i, j] = cube[i, j, faceIndex];
                }
            }

            // Rotate the face counter-clockwise
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rotatedFace[i, j] = originalFace[j, 2 - i];
                }
            }

            // Copy the rotated face back to the cube
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cube[i, j, faceIndex] = rotatedFace[i, j];
                }
            }
        }

        public void PrintCube()
        {
            // Print the colors on each face in an exploded view
            for (int k = 0; k < 6; k++)
            {
                Console.WriteLine("Face " + k);
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(cube[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public void RotateFrontCounterClockwise()
        {
            throw new NotImplementedException();
        }

        public void RotateRightClockwise()
        {
            throw new NotImplementedException();
        }

        public void RotateUpCounterClockwise()
        {
            throw new NotImplementedException();
        }

        public void RotateBackClockwise()
        {
            throw new NotImplementedException();
        }

        public void RotateLeftCounterClockwise()
        {
            throw new NotImplementedException();
        }

        public void RotateDownClockwise()
        {
            throw new NotImplementedException();
        }
    }

}
