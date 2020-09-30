using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace api.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual List<Device> Devices { get; set; }
    }
}