using DocumentManager.API.Models;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace DocumentManager.API.Data
{
    public class MongoContext
    {
        public IMongoDatabase Database { get; }
        private readonly ConventionPack camelConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
        private readonly ConventionPack ignoreExtraElementsPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
        private readonly ConventionPack ignoreNullsPack = new ConventionPack { new IgnoreIfNullConvention(true) };
        private readonly MongoClient client;

        public MongoContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DocumentsDB");

            ConventionPack pack = new ConventionPack
            {
                new IgnoreIfNullConvention(true),
                new IgnoreExtraElementsConvention(true),
                new CamelCaseElementNameConvention()
            };
            ConventionRegistry.Register("defaults", pack, t => true);
            client = new MongoClient(connectionString);
            Database = client.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
        }

        public MongoContext(string connectionString)
        {
            ConventionRegistry.Register("CamelCaseConvensions", camelConventionPack, t => true);
            ConventionRegistry.Register("IgnoreExtraElements", ignoreExtraElementsPack, t => true);
            ConventionRegistry.Register("Ignore null values", ignoreNullsPack, t => true);
            client = new MongoClient(connectionString);
            Database = client.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
        }


        public IMongoCollection<Document> Documents => Database.GetCollection<Document>("Documents");

        public IMongoCollection<UploadResult> Uploads => Database.GetCollection<UploadResult>("Documents");
    }
}
