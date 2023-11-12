using Core.Bomb.Runtime;
using Core.Bomb.Runtime.Modules.Mistakes.View;
using UnityEngine;

namespace Core.Bomb.Sample
{
    [CreateAssetMenu(fileName = "MistakeModuleSettingSample", menuName = "ScriptableObjects/MistakeModuleSettingSample")]
    public class MistakeModuleSettingSample : ScriptableObject
    {
        public string ModuleType => BombEnvironment.ModuleType.MistakeCounter;

        public int MaxAllowableMistakesCount;
        public MistakeModuleView View;
    }
}