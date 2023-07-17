using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop
{
    public class DeviceRepository: IDeviceRepository {
        private readonly DeviceContext _context = null;

        public DeviceRepository(IOptions<Settings> settings)
        {
            _context = new DeviceContext(settings);
        }

        public async Task<List<Device>> GetAllDevices()
        {
            return await _context.Devices.Find(_ => true).ToListAsync();
        }

        public async Task<List<Device>> GetDevicesByCategory(string category)
        {
            var filter = Builders<Device>.Filter.Eq("category", category);
            return await _context.Devices.Find(filter).ToListAsync();
        }

        public async Task<Device> GetDevice(string name)
        {
            var filter = Builders<Device>.Filter.Eq("name", name);
            return await _context.Devices
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }

        public async Task AddDevice(Device item)
        {
            await _context.Devices.InsertOneAsync(item);
        }

        public async Task<DeleteResult> RemoveDevice(string id)
        {
            return await _context.Devices.DeleteOneAsync(
                 Builders<Device>.Filter.Eq("Id", id));
        }

        /*public async Task<UpdateResult> UpdateDevice(string id, string body)
        {
            var filter = Builders<Device>.Filter.Eq(s => s.id, id);
            var update = Builders<Device>.Update
                            .Set(s => s.body, body)
                            .CurrentDate(s => s.UpdatedOn);

            return await _context.Devices.UpdateOneAsync(filter, update);
        }*/
    }
}

