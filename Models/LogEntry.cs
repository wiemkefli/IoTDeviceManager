using System;

namespace IoTDeviceManager.Models
{
    public class LogEntry
    {
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Action { get; set; } = "";
        public string Details { get; set; } = "";
        public override string ToString() => $"[{Timestamp:HH:mm:ss}] {Action} - {Details}";
    }
}
