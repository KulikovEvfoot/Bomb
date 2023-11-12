using Core.Bomb.Runtime.Bomb;

namespace Core.Bomb.Runtime.Modules.Timer
{
    public class TimerModuleFactory : IBombModuleFactory
    {
        private TimerModuleSetting m_Setting;

        public void Configure(IBombModuleSetting args)
        {
            if (args is TimerModuleSetting setting)
            {
                m_Setting = setting;
            }
        }

        public IBombModule Create(int id, BombSignalProducer bombSignalProducer)
        {
            return new TimerModule(id, m_Setting, bombSignalProducer);
        }
        
        public IBombModuleFactory Clone()
        {
            return new TimerModuleFactory();
        }
    }
}