using System.Collections.Generic;
using UnityEngine;

namespace Core.Bomb.Runtime.Modules.Mistakes.View
{
    public class MistakeModuleView : MonoBehaviour
    {
        [SerializeField] private RectTransform m_MistakeParent;
        [SerializeField] private MistakeView m_MistakeViewTemplate;

        private List<MistakeView> m_MistakeViews = new List<MistakeView>();
        private int m_CurrentMistakeIndex;
        
        public void Init(int maxCount)
        {
            for (int i = 0; i < maxCount; i++)
            {
                var mistake = Instantiate(m_MistakeViewTemplate, m_MistakeParent);
                mistake.gameObject.SetActive(true);
                m_MistakeViews.Add(mistake);
            }
        }
        
        public void AddMistake()
        {
            m_MistakeViews[m_CurrentMistakeIndex].SetMistakeEnable(true);
            m_CurrentMistakeIndex++;
        }
    }
}