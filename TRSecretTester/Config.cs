using System.Collections.Generic;
using TRRandomizerCore.Helpers;

namespace TRSecretTester
{
    public class Config
    {
        public Dictionary<string, Location> TR1LaraPositions { get; set; }
        public Dictionary<string, Location> TR2LaraPositions { get; set; }
        public Dictionary<string, Location> TR3LaraPositions { get; set; }
        public List<short> TR1EntityRemovals { get; set; }
        public List<short> TR2EntityRemovals { get; set; }
        public List<short> TR3EntityRemovals { get; set; }
    }
}