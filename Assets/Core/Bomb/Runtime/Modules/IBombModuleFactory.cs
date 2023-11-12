using Core.Bomb.Runtime.Bomb;

namespace Core.Bomb.Runtime.Modules
{
    public interface IBombModuleFactory
    {
        void Configure(IBombModuleSetting args);
        IBombModule Create(int id, BombSignalProducer bombSignalProducer);
        IBombModuleFactory Clone();
    }
}