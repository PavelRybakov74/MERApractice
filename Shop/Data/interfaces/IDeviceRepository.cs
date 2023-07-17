using MongoDB.Driver;
using Shop.Data.Models;

namespace Shop.Data.interfaces
{
    public interface IDeviceRepository {
        Task<List<Device>> GetAllDevices();
        Task<List<Device>> GetDevicesByCategory(string category);
        Task<Device> GetDevice(string name);
        Task AddDevice(Device item);
        Task<DeleteResult> RemoveDevice(string id);
        // обновление содержания (body) записи
        //Task<UpdateResult> UpdateDevice(string id, string body);
    }
}
