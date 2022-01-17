using System.Collections.Generic;
using TRRandomizerCore.Helpers;

namespace TRSecretTester
{
    public class Config
    {
        public Dictionary<string, Location> TR2LaraPositions { get; set; }
        public Dictionary<string, Location> TR3LaraPositions { get; set; }
        public List<short> TR2EntityRemovals { get; set; }
        public List<short> TR3EntityRemovals { get; set; }

        public bool IsTR2Level(string lvl) => TR2LaraPositions.ContainsKey(lvl);
        public bool IsTR3Level(string lvl) => TR3LaraPositions.ContainsKey(lvl);
    }
}