namespace Library.Service.Repository.Db.Setting
{
    public class DatabaseSetting : IDatabaseSettings
    {
        public string Directory { get; set; }
        public string Name { get; set; }
        public string Args { get; set; }
        public bool Recreate { get; set; }

        public string File => Directory + "/" + Name;
    }
}