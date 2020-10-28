using System;

namespace MonitoringHealth.Entities
{
    public class Configuration : Entity
    {
        public int? ConfigurationMonitorId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool? Active { get; set; }
        public int? Time { get; set; }
        public int? Sleep { get; set; }
        public int? AlertAmount { get; set; }
        public bool? SendSMS { get; set; }
        public bool? SendEmail { get; set; }
        public DateTime? LastRunDate { get; set; }
    }
}
