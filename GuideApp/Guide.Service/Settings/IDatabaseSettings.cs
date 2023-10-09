namespace Guide.Service.Settings
{
    public interface IDatabaseSettings
    {
        public string UserProfileCollectionName { get; set; }
        public string UserContactCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
