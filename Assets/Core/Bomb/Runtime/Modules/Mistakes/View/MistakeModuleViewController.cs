using UnityEngine;

namespace Core.Bomb.Runtime.Modules.Mistakes.View
{
    public class MistakeModuleViewController
    {
        private MistakeModuleView m_View;

        public MistakeModuleViewController(MistakeModuleView viewPrefab, Transform parent, int maxMistakesCount)
        {
            m_View = Object.Instantiate(viewPrefab, parent);
            m_View.Init(maxMistakesCount);
        }

        public void AddMistake()
        {
            m_View.AddMistake();
        }
    }
}