using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeShared.Interfaces
{
    public interface IRubiksCube
    {
        public void RotateFrontClockwise();
        public void RotateFrontCounterClockwise();

        public void RotateRightClockwise();
        public void RotateRightCounterClockwise();

        public void RotateUpClockwise();
        public void RotateUpCounterClockwise();

        public void RotateBackClockwise();
        public void RotateBackCounterClockwise();

        public void RotateLeftClockwise();

        public void RotateLeftCounterClockwise();
        public void RotateDownClockwise();

        public void RotateDownCounterClockwise();

        public void PrintCube();
    }
}
