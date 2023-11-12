using System.Collections.Generic;
using Core.Bomb.Runtime.Bomb;
using Core.Bomb.Runtime.Modules;

namespace Core.Bomb.Runtime
{
    public class BombSetting
    {
        public IList<IBombModuleFactory> BombModuleFactories;
        public MistakesCounter MistakesCounter;
    }
}