using MonitoringHealth.Entities;
using System;
using System.Collections.Generic;

namespace MonitoringHealth.Console.Interfaces.Repository
{
    public interface IConfigurationRepository
    {
        public Configuration Create(Configuration entity);
        public Configuration Update(Configuration entity);
        public bool Delete(Guid id);
        public IEnumerable<Configuration> GetAll();
        public Configuration GetById(Guid id);
    }
}
