using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using api.Models.Enums;

namespace api.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DeviceType Type { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Room Room { get; set; }
        public virtual List<Log> Logs { get; set; }
    }
}