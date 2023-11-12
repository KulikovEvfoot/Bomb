using Core.Bomb.Runtime;
using Core.Bomb.Runtime.Modules.Timer;
using Core.Bomb.Runtime.Modules.Timer.View;
using UnityEngine;

namespace Core.Bomb.Sample
{
    [CreateAssetMenu(fileName = "TimerModuleSettingSample", menuName = "ScriptableObjects/TimerModuleSettingSample")]
    public class TimerModuleSettingSample : ScriptableObject
    {
        public string ModuleType => BombEnvironment.ModuleType.Deactivation;

        public float TimeToDetonate;
        public TimerStateSetting DefaultStateSetting;
        public TimerStateSetting WarningStateSetting;
        public TimerModuleView View;
    }
}