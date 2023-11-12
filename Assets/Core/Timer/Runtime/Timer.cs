using System;
using System.Collections;
using System.Collections.Generic;
using Core.CoroutineRunner.Runtime;
using UnityEngine;

namespace Core.Timer.Runtime
{
    public class Timer : ITimer, IDisposable
    {
        private const float m_DefaultUpdateRate = 1;
        
        private readonly float m_UpdateRate;
        private readonly float m_StartTime;
        private readonly ICoroutineRunner m_CoroutineRunner;
        private readonly List<ITimerTickObserver> m_TimerTickObservers;
        private readonly List<ITimerCompleteObserver> m_TimerCompleteObservers;
        
        private float m_Duration;
        private Coroutine m_Coroutine;

        public Timer(TimerArgs args)
        {
            m_CoroutineRunner = args.CoroutineRunner;
            m_StartTime = Time.realtimeSinceStartup;
            m_UpdateRate = GetUpdateRate(args.UpdateRate);

            m_TimerTickObservers = new List<ITimerTickObserver>();
            m_TimerCompleteObservers = new List<ITimerCompleteObserver>();
        }
        
        public void Start(TimeSpan duration)
        {
            m_Duration = (float) duration.TotalSeconds;
            m_Coroutine = m_CoroutineRunner.StartCoroutine(TimerProcess());
        }

        public void Stop()
        {
            if (m_Coroutine != null)
            {
                m_CoroutineRunner.StopCoroutine(m_Coroutine);
            }
        }

        public void Attach(ITimerObserver observer)
        {
            m_TimerTickObservers.Add(observer);
            m_TimerCompleteObservers.Add(observer);
        }

        public void Detach(ITimerObserver observer)
        {
            m_TimerTickObservers.Remove(observer);
            m_TimerCompleteObservers.Remove(observer);
        }

        public void Dispose()
        {
            Stop();
            m_TimerTickObservers.Clear();
            m_TimerCompleteObservers.Clear();
        }
        
        private IEnumerator TimerProcess()
        {
            while (Tick())
            {
                yield return new WaitForSeconds(m_UpdateRate);
            }
            
            NotifyOnComplete();
        }

        private bool Tick()
        {
            var pastTime = m_StartTime - Time.realtimeSinceStartup;
            var timeLeft = pastTime + m_Duration;
            if (timeLeft <= float.Epsilon)
            {
                NotifyOnTick(TimeSpan.Zero);
                return false;
            }

            NotifyOnTick(TimeSpan.FromSeconds(timeLeft));
            return true;   
        }
        
        private void NotifyOnTick(TimeSpan timeLeft)
        {
            foreach (var timerTickObserver in m_TimerTickObservers)
            {
                timerTickObserver.NotifyOnTimerTick(timeLeft);
            }
        }

        private void NotifyOnComplete()
        {
            foreach (var timerTickObserver in m_TimerCompleteObservers)
            {
                timerTickObserver.NotifyOnTimerComplete();
            }
        }
        
        private float GetUpdateRate(float? updateRate)
        {
            if (!updateRate.HasValue)
            {
                return m_DefaultUpdateRate;
            }

            if (updateRate.Value > float.Epsilon)
            {
                return updateRate.Value;
            }
            
            Debug.LogError($"Incorrect update rate format. Start with default value = {m_DefaultUpdateRate}");
            return m_DefaultUpdateRate;
        }
    }
}