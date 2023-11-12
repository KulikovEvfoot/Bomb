using Core.Bomb.Runtime.Bomb;
using Core.Bomb.Runtime.Modules.Mistakes.View;

namespace Core.Bomb.Runtime.Modules.Mistakes
{
    public class MistakeModule : IMistakeModule
    {
        private readonly MistakeModuleSetting m_Setting;
        private readonly BombSignalProducer m_BombSignalProducer;
        private readonly MistakesCounter m_MistakesCounter;
        private MistakeModuleViewController m_ViewController;

        public string ModuleType => BombEnvironment.ModuleType.MistakeCounter;
        public int Id { get; }
        
        private int m_MistakeCount;

        public MistakeModule(int id, MistakeModuleSetting setting, BombSignalProducer bombSignalProducer)
        {
            Id = id;
            m_Setting = setting;
            m_BombSignalProducer = bombSignalProducer;
            m_MistakesCounter = setting.MistakesCounter;
            m_MistakesCounter.OnValueChanged += OnMistakesAdded;
        }
        
        public void Start()
        {
            m_ViewController = new MistakeModuleViewController(m_Setting.View, m_Setting.ViewParent, m_Setting.MaxAllowableMistakesCount);
        }

        public void Stop()
        {
            m_MistakesCounter.OnValueChanged -= OnMistakesAdded;
        }

        private void OnMistakesAdded(int mistakeCount)
        {
            if (mistakeCount > m_Setting.MaxAllowableMistakesCount)
            {
                m_BombSignalProducer.ProduceSignal(Id,BombEnvironment.MistakesEvents.FatalMistake);   
                return;
            }
                
            m_ViewController.AddMistake();
        }

        public void Dispose()
        {
        }
    }
}