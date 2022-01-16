namespace Interfaces.Model.Shared
{
    public interface ITrackedObject<out T>
    {
        string __Type__ { get; }
        T __Object__ { get; }
    }
}