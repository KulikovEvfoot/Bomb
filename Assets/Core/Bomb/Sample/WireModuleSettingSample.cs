using System.Collections.Generic;
using Core.Bomb.Runtime;
using Core.Bomb.Runtime.Deactivation.Wire;
using Core.Bomb.Runtime.Deactivation.Wire.View;
using UnityEngine;

namespace Core.Bomb.Sample
{
    [CreateAssetMenu(fileName = "WireModuleSettingSample", menuName = "ScriptableObjects/WireModuleSettingSample")]
    public class WireModuleSettingSample : ScriptableObject
    {
        public string ModuleType => BombEnvironment.ModuleType.Timer;
        
        public WireModuleView View;
        public List<WireSetting> Wires;
    }
}