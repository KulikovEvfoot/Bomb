using System;
using Core.Bomb.Runtime.Modules.Timer.View;
using Core.CoroutineRunner.Runtime;
using UnityEngine;

namespace Core.Bomb.Runtime.Modules.Timer
{
    public class TimerModuleSetting : IBombModuleSetting
    {
        public float TimeToDetonate;
        public TimerStateSetting DefaultStateSetting;
        public TimerStateSetting WarningStateSetting;
        public ICoroutineRunner CoroutineRunner;
        public RectTransform ViewParent;
        public TimerModuleView View;
    }

    [Serializable]
    public class TimerStateSetting
    {
        public float TimeToDetonate;
        public Color32 TimerTextColor;
    }
}