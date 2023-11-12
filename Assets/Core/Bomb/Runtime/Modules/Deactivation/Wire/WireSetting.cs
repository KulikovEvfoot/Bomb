using System;
using UnityEngine;

namespace Core.Bomb.Runtime.Deactivation.Wire
{
    [Serializable]
    public class WireSetting
    {
        [SerializeField] private Color32 m_Color;
        [SerializeField] private bool m_IsCorrect;

        public Color32 Color => m_Color;
        public bool IsCorrect => m_IsCorrect;
    }
}