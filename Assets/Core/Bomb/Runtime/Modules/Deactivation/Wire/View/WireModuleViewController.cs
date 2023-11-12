using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Bomb.Runtime.Deactivation.Wire.View
{
    public class WireModuleViewController
    {
        private readonly WireModuleView m_View;
        private readonly Action<bool> m_OnWireCut;
        private readonly Dictionary<int, bool> m_Wires;

        public WireModuleViewController(WireModuleView viewPrefab, Transform parent, List<WireSetting> wireSettings, Action<bool> onWireCut)
        {
            m_Wires = new Dictionary<int, bool>();
            m_OnWireCut = onWireCut;
            m_View = Object.Instantiate(viewPrefab, parent);
            
            for (int i = 0; i < wireSettings.Count; i++)
            {
                AddWire(i, wireSettings[i]);
            }
        }

        public void SetInteractableEnabled(bool state)
        {
            m_View.SetInteractableEnabled(state);
        }

        private void AddWire(int id, WireSetting setting)
        {
            m_View.AddWire(id, setting.Color, CutWire);
            m_Wires.Add(id, setting.IsCorrect);
        }
        
        private void CutWire(int id)
        {
            m_View.CutWire(id);
            var isCorrect = m_Wires[id];
            m_OnWireCut?.Invoke(isCorrect);
        }
    }
}