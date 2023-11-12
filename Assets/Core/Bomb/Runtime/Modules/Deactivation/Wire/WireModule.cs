using System.Linq;
using Core.Bomb.Runtime.Bomb;
using Core.Bomb.Runtime.Deactivation.Wire.View;

namespace Core.Bomb.Runtime.Deactivation.Wire
{
    public class WireModule : IDeactivationModule
    {
        private readonly WireModuleSetting m_Setting;
        private readonly BombSignalProducer m_BombSignalProducer;
        private readonly int m_RequiredCountOfCutWires;
        
        private WireModuleViewController m_ViewController;
        private int m_CorrectlyCutWires;

        public string ModuleType => BombEnvironment.ModuleType.Deactivation;
        public int Id { get; }
        public bool IsDeactivated => m_CorrectlyCutWires >= m_RequiredCountOfCutWires;
        
        public WireModule(int id, WireModuleSetting setting, BombSignalProducer bombSignalProducer)
        {
            Id = id;
            m_Setting = setting;
            m_BombSignalProducer = bombSignalProducer;

            m_RequiredCountOfCutWires = m_Setting.Wires.Count(s => s.IsCorrect);
        }
        
        public void Start()
        {
            m_ViewController =
                new WireModuleViewController(m_Setting.View, m_Setting.ViewParent, m_Setting.Wires, Deactivate);
        }

        public void Stop()
        {
            m_ViewController.SetInteractableEnabled(false);
        }

        private void Deactivate(bool isCorrect)
        {
            if (isCorrect)
            {
                m_CorrectlyCutWires++;
                if (m_CorrectlyCutWires >= m_RequiredCountOfCutWires)
                { 
                    m_BombSignalProducer.ProduceSignal(Id, BombEnvironment.DeactivationEvents.Deactivate);
                    m_ViewController.SetInteractableEnabled(false);
                }
                
                return;
            }

            m_BombSignalProducer.ProduceSignal(Id, BombEnvironment.DeactivationEvents.DeactivationMistake);
        }

        public void Dispose()
        {
            
        }
    }
}