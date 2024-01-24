using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RubiksCore;

namespace RubiksCubeShared.Interfaces
{
    public interface IRubiksCubePrinter
    {
        public void PrintCube(IEnumerable<Cubie> cubies);
    }
}
