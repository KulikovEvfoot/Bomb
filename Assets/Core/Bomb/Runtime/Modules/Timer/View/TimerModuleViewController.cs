using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Bomb.Runtime.Modules.Timer.View
{
    public class TimerModuleViewController
    {
        private readonly TimerModuleView m_View;
        private readonly TimerModuleSetting m_Setting;

        public TimerModuleViewController(TimerModuleSetting setting, RectTransform parent)
        {
            m_Setting = setting;
            m_View = Object.Instantiate(setting.View, parent);
        }
        
        public void SetTimeToDetonateText(string text)
        {
            m_View.SetTimeToDetonateText(text);
        }

        public void SetDefaultState()
        {
            m_View.SetTimeToDetonateTextColor(m_Setting.DefaultStateSetting.TimerTextColor);
        }

        public void SetWarningState()
        {
            m_View.SetTimeToDetonateTextColor(m_Setting.WarningStateSetting.TimerTextColor);
        }
    }
}