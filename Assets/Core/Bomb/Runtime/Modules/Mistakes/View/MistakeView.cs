using UnityEngine;
using UnityEngine.UI;

namespace Core.Bomb.Runtime.Modules.Mistakes.View
{
    public class MistakeView : MonoBehaviour
    {
        [SerializeField] private Image m_Image;
        
        public void SetMistakeEnable(bool state)
        {
            m_Image.enabled = state;
        }
    }
}