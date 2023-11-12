using Core.CoroutineRunner.Runtime;

namespace Core.Timer.Runtime
{
    public class TimerArgs
    {
        public float? UpdateRate;
        public ICoroutineRunner CoroutineRunner;
    }
}