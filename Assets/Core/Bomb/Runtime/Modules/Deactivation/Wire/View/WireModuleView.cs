using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Bomb.Runtime.Deactivation.Wire.View
{
    public class WireModuleView : MonoBehaviour
    {
        [SerializeField] private RectTransform m_WireParent;
        [SerializeField] private WireView m_WireViewTemplate;
        [SerializeField] private CanvasGroup m_CanvasGroup;

        private readonly List<WireView> m_Wires = new List<WireView>();
        
        public void AddWire(int id, Color32 color, Action<int> onWireCut)
        {
            var wire = Instantiate(m_WireViewTemplate, m_WireParent);
            wire.Init(id, color, onWireCut);
            wire.gameObject.SetActive(true);
            m_Wires.Add(wire);
        }

        public void CutWire(int id)
        {
            m_Wires[id].SetWireEnable(false);
        }

        public void SetInteractableEnabled(bool state)
        {
            m_CanvasGroup.interactable = state;
        }
    }
}