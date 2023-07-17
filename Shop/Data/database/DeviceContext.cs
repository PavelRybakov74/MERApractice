using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shop.Data.Models;

namespace Shop
{
    public class DeviceContext {
        private readonly IMongoDatabase _database;
        private IOptions<Settings> settings;

        public DeviceContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
            this.settings = settings;
        }

        public IMongoCollection<Device> Devices => _database.GetCollection<Device>("devices");
    }
}
