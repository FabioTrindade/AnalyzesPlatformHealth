using System;

namespace MonitoringHealth.Entities
{
    public class LogError : Entity
    {
        public string Error { get; set; }
        public string CompleteError { get; set; }
        public string Query { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
