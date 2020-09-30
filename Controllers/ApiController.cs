using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {

        private AppDbContext _context;
        public ApiController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("[action]")]
        public List<Room> GetAll()
        {
            return _context.Rooms
            .Include(r => r.Devices)
            .ThenInclude(d => d.Logs)
            .ToList();
        }

        [HttpGet("[action]")]
        public Room GetRoom(int id)
        {
            return _context.Rooms
                        .Include(r => r.Devices)
                        .ThenInclude(d => d.Logs)
                        .FirstOrDefault(r => r.Id == id);
        }

        [HttpGet("[action]")]
        public Device GetDevice(int id)
        {
            return _context.Devices
                .Include(d => d.Logs)
                .FirstOrDefault(d => d.Id == id);
        }

        [HttpGet("[action]")]
        public Log GetLog(int id)
        {
            return _context.Logs.FirstOrDefault(l => l.Id == id);
        }

        [HttpPost("[action]")]
        public Log AddLog(Log log)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }
            log.CreatedAt = DateTime.Now;
            _context.Logs.Add(log);
            _context.SaveChanges();
            return log;
        }

        [HttpPost("[action]")]
        public Device AddDevice(Device device)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }
            device.CreatedAt = DateTime.Now;
            _context.Devices.Add(device);
            _context.SaveChanges();
            return device;
        }

        [HttpPost("[action]")]
        public Room AddRoom(Room room)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }
            room.CreatedAt = DateTime.Now;
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return room;
        }

        [HttpPut("[action]")]
        public Device UpdateDevice(Device device)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }
            var oldDevice = _context.Devices.FirstOrDefault(d => d.Id == device.Id);
            oldDevice.Name = device.Name;
            oldDevice.RoomId = device.RoomId;

            _context.Devices.Update(oldDevice);
            _context.SaveChanges();
            return oldDevice;
        }

        [HttpPut("[action]")]
        public Room UpdateRoom(Room room)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }
            var oldRoom = _context.Rooms.FirstOrDefault(r => r.Id == room.Id);
            oldRoom.Name = room.Name;

            _context.Rooms.Update(oldRoom);
            _context.SaveChanges();
            return oldRoom;
        }

        [HttpDelete("[action]")]
        public Room DeleteRoom(Room room)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }
            var oldRoom = _context.Rooms.FirstOrDefault(r => r.Id == room.Id);

            _context.Rooms.Remove(oldRoom);
            _context.SaveChanges();
            return room;
        }

        [HttpDelete("[action]")]
        public Device DeleteDevice(Device device)
        {
            if(!ModelState.IsValid)
            {
                return null;
            }
            var oldDevice = _context.Devices.FirstOrDefault(d => d.Id == device.Id);

            _context.Devices.Remove(oldDevice);
            _context.SaveChanges();
            return device;
        }
    }
}
