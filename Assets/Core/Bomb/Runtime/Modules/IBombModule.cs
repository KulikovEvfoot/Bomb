using System;

namespace Core.Bomb.Runtime
{
    public interface IBombModule : IDisposable
    {
        string ModuleType { get; }
        int Id { get; }
        void Start();
        void Stop();
    }
}