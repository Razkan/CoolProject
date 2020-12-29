namespace Interfaces.Model
{
    public interface ITrackedResult<out T>
    {
        string __Type__ { get; }
        T __Object__ { get; }
    }
}