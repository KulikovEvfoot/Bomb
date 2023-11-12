using UnityEngine;
using UnityEngine.UI;

namespace Core.Bomb.Runtime.Modules.Timer.View
{
    public class TimerModuleView : MonoBehaviour
    {
        [SerializeField] private Text m_TimeToDetonate;

        public void SetTimeToDetonateTextColor(Color32 color)
        {
            m_TimeToDetonate.color = color;
        }
        
        public void SetTimeToDetonateText(string text)
        {
            m_TimeToDetonate.text = text;
        }
    }
}