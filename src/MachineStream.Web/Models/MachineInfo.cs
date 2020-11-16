using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MachineStream.Web.Models
{
    public class MachineInfo
    {
        [Key]
        public int MachineInfoId { get; set; }

        [JsonPropertyName("machine_id")]
        public Guid MachineId { get; set; }

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime TimeStamp { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
