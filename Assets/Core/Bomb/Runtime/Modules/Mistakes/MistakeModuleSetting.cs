using Core.Bomb.Runtime.Bomb;
using Core.Bomb.Runtime.Modules.Mistakes.View;
using UnityEngine;

namespace Core.Bomb.Runtime.Modules.Mistakes
{
    public class MistakeModuleSetting : IBombModuleSetting
    {
        public int MaxAllowableMistakesCount;
        public RectTransform ViewParent;
        public MistakeModuleView View;
        public MistakesCounter MistakesCounter;
    }
}