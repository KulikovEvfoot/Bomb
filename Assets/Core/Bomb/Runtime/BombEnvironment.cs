namespace Core.Bomb.Runtime
{
    public sealed class BombEnvironment
    {
        public sealed class ModuleType
        {
            public const string Timer = "timer";
            public const string Deactivation = "deactivation";
            public const string MistakeCounter = "mistake_counter";
        }

        public sealed class TimerEvents
        {
            public const string Complete = "complete";
        }

        public sealed class DeactivationEvents
        {
            public const string Deactivate = "deactivate";
            public const string DeactivationMistake = "deactivation_mistake";
        }
        
        public sealed class MistakesEvents
        {
            public const string FatalMistake = "fatal_mistake";
        }
    }
}