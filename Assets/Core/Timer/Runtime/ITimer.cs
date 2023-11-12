using System;

namespace Core.Timer.Runtime
{
    public interface ITimer
    {
        void Start(TimeSpan duration);
        void Stop();
        void Attach(ITimerObserver observer);
        void Detach(ITimerObserver observer);
    }
}