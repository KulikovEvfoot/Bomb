using System;

namespace Core.Timer.Runtime
{
    public interface ITimerObserver : ITimerTickObserver, ITimerCompleteObserver
    {
    }

    public interface ITimerTickObserver
    {
        void NotifyOnTimerTick(TimeSpan timeSpan);
    }

    public interface ITimerCompleteObserver
    {
        void NotifyOnTimerComplete();
    }
}