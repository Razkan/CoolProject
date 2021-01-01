namespace Interfaces.Model
{
    public interface ITrackedObject<out T>
    {
        string __Type__ { get; }
        T __Object__ { get; }
    }
}