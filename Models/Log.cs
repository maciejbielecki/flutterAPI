using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace api.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public string Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Device Device { get; set; }
    }
}