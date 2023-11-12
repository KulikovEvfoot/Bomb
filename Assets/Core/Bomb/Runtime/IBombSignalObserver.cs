namespace Core.Bomb.Runtime.Bomb
{
    public interface IBombSignalObserver
    {
        void OnSignalReceived(int id, string signalKey);
    }
}