using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Xml.Linq;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using ViewResult = Microsoft.AspNetCore.Mvc.ViewResult;

namespace Shop.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DevicesController : Controller
    {

        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository DeviceRepository)
        {
            _deviceRepository = DeviceRepository;
        }

        [HttpGet("{category}/{name}")]
        public async Task<ViewResult> GetItem(string name)
        {
            ViewBag.Title = name;
            DeviceViewModel model = new DeviceViewModel();
            if (!string.IsNullOrWhiteSpace(name))
            {
                model.device = await _deviceRepository.GetDevice(name);
            }
            return View("Item", model);
        }

        [HttpGet]
        [HttpGet("{category}")]
        public async Task<ViewResult> List(string category)
        {
            ViewBag.Title = "Измерительные приборы";

            DevicesListViewModel model = new DevicesListViewModel();

            if (string.Equals("pxi", category, StringComparison.OrdinalIgnoreCase)) {
                model.allDevices = await _deviceRepository.GetDevicesByCategory(category);
            }
            else if (string.Equals("rxi", category, StringComparison.OrdinalIgnoreCase)) {
                model.allDevices = await _deviceRepository.GetDevicesByCategory(category);
            }
            else if (string.Equals("ms", category, StringComparison.OrdinalIgnoreCase))
            {
                model.allDevices = await _deviceRepository.GetDevicesByCategory(category);
            }
            else if (string.Equals("mc", category, StringComparison.OrdinalIgnoreCase))
            {
                model.allDevices = await _deviceRepository.GetDevicesByCategory(category);
            }
            else if (string.IsNullOrWhiteSpace(category)) { 
                model.allDevices = await _deviceRepository.GetAllDevices(); 
            }

            return View(model);
        }


        // GET api/Devices/5
        [HttpGet("{id}")]
        public Task<Device> Get(string id)
        {
            return GetDeviceByIdInternal(id);
        }

        private async Task<Device> GetDeviceByIdInternal(string id)
        {
            return await _deviceRepository.GetDevice(id) ?? new Device();
        }

        // POST api/Devices
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //    _deviceRepository.AddDevice(new Device() { Body = value, CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
        //}

        // PUT api/Devices/5
        //[HttpPut("{id}")]
        //public void Put(string id, [FromBody] string value)
        //{
        //    _deviceRepository.UpdateDeviceDocument(id, value);
        //}

        // DELETE api/Devices/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _deviceRepository.RemoveDevice(id);
        }
    }
}