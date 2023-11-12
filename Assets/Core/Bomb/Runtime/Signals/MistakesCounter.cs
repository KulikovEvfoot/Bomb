using System;

namespace Core.Bomb.Runtime.Bomb
{
    public class MistakesCounter : IBombSignalObserver
    {
        public event Action<int> OnValueChanged;
        public int MistakesCount { get; private set; }

        public void AddMistake()
        {
            MistakesCount++;
            OnValueChanged?.Invoke(MistakesCount);
        }

        public void OnSignalReceived(int id, string signalKey)
        {
            if (signalKey != BombEnvironment.DeactivationEvents.DeactivationMistake)
            {
                return;
            }
            
            AddMistake();
        }
    }
}