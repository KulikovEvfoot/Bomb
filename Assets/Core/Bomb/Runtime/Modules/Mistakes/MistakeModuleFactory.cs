using Core.Bomb.Runtime.Bomb;

namespace Core.Bomb.Runtime.Modules.Mistakes
{
    public class MistakeModuleFactory : IBombModuleFactory
    {
        private MistakeModuleSetting m_Setting;

        public void Configure(IBombModuleSetting args)
        {
            if (args is MistakeModuleSetting setting)
            {
                m_Setting = setting;
            }
        }

        public IBombModule Create(int id, BombSignalProducer bombSignalProducer)
        {
            return new MistakeModule(id, m_Setting, bombSignalProducer);
        }

        public IBombModuleFactory Clone()
        {
            return new MistakeModuleFactory();
        }
    }
}