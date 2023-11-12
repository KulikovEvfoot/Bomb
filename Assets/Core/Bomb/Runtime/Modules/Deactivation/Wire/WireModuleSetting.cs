using System.Collections.Generic;
using Core.Bomb.Runtime.Deactivation.Wire.View;
using Core.Bomb.Runtime.Modules;
using UnityEngine;

namespace Core.Bomb.Runtime.Deactivation.Wire
{
    public class WireModuleSetting : IBombModuleSetting
    {
        public RectTransform ViewParent;
        public WireModuleView View;
        public List<WireSetting> Wires;
    }
}