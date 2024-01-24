using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeShared.Interfaces
{
    public interface IRubiksCubeInputs
    {
        public void TurnCube(string input, RubiksCore.RubiksCube cube);
    }
}
