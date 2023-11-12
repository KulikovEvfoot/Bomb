using System;

namespace Core.Bomb.Runtime.Bomb
{
    public class BombModuleDetonator : IBombSignalObserver
    {
        private readonly Action m_OnFatalMistake;

        public BombModuleDetonator(Action onFatalMistake)
        {
            m_OnFatalMistake = onFatalMistake;
        }

        public void OnSignalReceived(int id, string signalKey)
        {
            if (signalKey != BombEnvironment.MistakesEvents.FatalMistake)
            {
                return;
            }
            
            m_OnFatalMistake?.Invoke();
        }
    }
}