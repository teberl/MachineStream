using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MachineStream.Web.Models
{
    public class MachineEvent
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("topic")]
        public string Topic { get; set; }

        [JsonPropertyName("ref")]
        public string Ref { get; set; }

        [JsonPropertyName("join_ref")]
        public string JoinRef { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("payload")]
        public MachineInfo MachineInfo { get; set; } = new MachineInfo();
    }
}