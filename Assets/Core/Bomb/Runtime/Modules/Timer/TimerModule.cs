using System;
using Core.Bomb.Runtime.Bomb;
using Core.Bomb.Runtime.Modules.Timer;
using Core.Bomb.Runtime.Modules.Timer.View;
using Core.Timer.Runtime;

namespace Core.Bomb.Runtime
{
    public class TimerModule : ITimerModule, ITimerObserver
    {
        private readonly TimerModuleSetting m_Setting;
        private readonly BombSignalProducer m_BombSignalProducer;
        private readonly Timer.Runtime.Timer m_Timer;
        
        private TimerModuleViewController m_ViewController;

        public string ModuleType => BombEnvironment.ModuleType.Timer;
        public int Id { get; }

        public TimerModule(int id, TimerModuleSetting setting, BombSignalProducer bombSignalProducer)
        {
            Id = id;
            m_Setting = setting;
            m_BombSignalProducer = bombSignalProducer;
            
            m_Timer = new Timer.Runtime.Timer(new TimerArgs
            {
                UpdateRate = 0.1f,
                CoroutineRunner = setting.CoroutineRunner
            });
            
            m_Timer.Attach(this);
        }
        
        public void Start()
        {
            m_ViewController = new TimerModuleViewController(m_Setting, m_Setting.ViewParent);
            m_ViewController.SetDefaultState();
            m_Timer.Start(TimeSpan.FromSeconds(m_Setting.TimeToDetonate));
        }

        public void Stop()
        {
            m_Timer.Stop();
        }

        public void NotifyOnTimerTick(TimeSpan timeSpan)
        {
            if (timeSpan.TotalSeconds < m_Setting.WarningStateSetting.TimeToDetonate)
            {
                m_ViewController.SetWarningState();
            }
            
            m_ViewController.SetTimeToDetonateText(timeSpan.ToString(@"mm\:ss\.fff"));
        }

        public void NotifyOnTimerComplete()
        {
            m_BombSignalProducer.ProduceSignal(Id, BombEnvironment.TimerEvents.Complete);
        }

        public void Dispose()
        {
            m_Timer.Detach(this);
            m_Timer?.Dispose();
        }
    }
}