namespace Catalog.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        private string? _host;

        public string? Host
        {
            get => _host;
            set => _host = value ?? throw new ArgumentNullException(Constants.ErrorNullValue);
        }
        public int Port{ get; set; }

        public string ConnectionString
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }

    }
}