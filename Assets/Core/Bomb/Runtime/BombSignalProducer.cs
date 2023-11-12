using Core.EventProducer.Runtime;

namespace Core.Bomb.Runtime.Bomb
{
    public class BombSignalProducer
    {
        private readonly EventProducer<IBombSignalObserver> m_SignalsObservers 
            = new EventProducer<IBombSignalObserver>();
        
        public void ProduceSignal(int id, string signalKey)
        {
            m_SignalsObservers?.NotifyAll(
                o => o.OnSignalReceived(id, signalKey));
        }
        
        public void Attach(IBombSignalObserver observer)
        {
            m_SignalsObservers.Attach(observer);
        }
        
        public void Detach(IBombSignalObserver observer)
        {
            m_SignalsObservers.Detach(observer);
        }
    }
}