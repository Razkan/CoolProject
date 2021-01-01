namespace Library.Service.Repository.Db.Setting
{
    public interface IDatabaseSettings
    {
        string Directory { get; }
        string Name { get; }
        string File { get; }
        string Args { get; }
        bool Recreate { get; }
    }
}