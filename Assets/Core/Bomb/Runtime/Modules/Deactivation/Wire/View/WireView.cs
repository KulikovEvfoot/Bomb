using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Bomb.Runtime.Deactivation.Wire.View
{
    public class WireView : MonoBehaviour
    {
        [SerializeField] private Image m_WireImgae;
        [SerializeField] private Button m_WireButton;
        
        private int m_Id;
        private Action<int> m_OnWireCut;

        public void Init(int id, Color32 color, Action<int> onWireCut)
        {
            m_Id = id;
            m_OnWireCut = onWireCut;
            m_WireImgae.color = color;
            m_WireButton.onClick.AddListener(Cut);
        }

        public void SetWireEnable(bool state)
        {
            m_WireImgae.enabled = state;
        }

        private void Cut()
        {
            m_OnWireCut?.Invoke(m_Id);
            m_WireImgae.enabled = false;
        }

        private void OnDestroy()
        {
            m_WireButton.onClick.RemoveListener(Cut);
        }
    }
}