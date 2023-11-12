using System;
using System.Collections.Generic;
using Core.Bomb.Runtime.Deactivation.Wire;
using Core.Bomb.Runtime.Modules;
using Core.Bomb.Runtime.Modules.Mistakes;
using Core.Bomb.Runtime.Modules.Timer;

namespace Core.Bomb.Runtime.Deactivation
{
    public class BombModuleFactoryConfigurator
    {
        private readonly Dictionary<Type, IBombModuleFactory> m_Map;

        public BombModuleFactoryConfigurator()
        {
            m_Map = ConfigureFactoryMap();
        }

        public IBombModuleFactory GetConfiguredFactory(IBombModuleSetting moduleSetting)
        {
            if (m_Map.TryGetValue(moduleSetting.GetType(), out var moduleFactory))
            {
                var clone = moduleFactory.Clone();
                clone.Configure(moduleSetting);
                return clone;
            }
            
            //error
            return null;
        }
        
        private Dictionary<Type, IBombModuleFactory> ConfigureFactoryMap()
        {
            var map = new Dictionary<Type, IBombModuleFactory>();
            map.Add(typeof(TimerModuleSetting), new TimerModuleFactory());
            map.Add(typeof(WireModuleSetting), new WireModuleFactory());
            map.Add(typeof(MistakeModuleSetting), new MistakeModuleFactory());
            return map;
        }
    }
}