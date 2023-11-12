using Core.Bomb.Runtime.Bomb;
using Core.Bomb.Runtime.Modules;

namespace Core.Bomb.Runtime.Deactivation.Wire
{
    public class WireModuleFactory : IBombModuleFactory
    {
        private WireModuleSetting m_Setting;
        
        public void Configure(IBombModuleSetting args)
        {
            if (args is WireModuleSetting setting)
            {
                m_Setting = setting;
            }
        }

        public IBombModule Create(int id, BombSignalProducer bombSignalProducer)
        {
            return new WireModule(id, m_Setting, bombSignalProducer);
        }

        public IBombModuleFactory Clone()
        {
            return new WireModuleFactory();
        }
    }
}