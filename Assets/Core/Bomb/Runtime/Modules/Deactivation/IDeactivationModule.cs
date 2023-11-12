namespace Core.Bomb.Runtime.Deactivation
{
    public interface IDeactivationModule : IBombModule
    {
        bool IsDeactivated { get; }
    }
}