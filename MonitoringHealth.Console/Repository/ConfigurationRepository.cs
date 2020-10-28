using MonitoringHealth.Console.Data;
using MonitoringHealth.Console.Interfaces.Repository;
using MonitoringHealth.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonitoringHealth.Console.Repository
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly MonitoringHealthDbContext _context;

        public ConfigurationRepository(MonitoringHealthDbContext context)
        {
            _context = context;
        }

        public Configuration Create(Configuration entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(Guid id)
        {
            var entity = this.GetById(id);
            if (entity == null)
                return false;

            _context.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Configuration> GetAll()
        {
            return _context.Configurations.ToList();
        }

        public Configuration GetById(Guid id)
        {
            return _context.Configurations.Where(t => t.Id == id).FirstOrDefault();
        }

        public Configuration Update(Configuration entity)
        {
            var config = this.GetById(entity.Id);

            if (config == null)
                return entity;

            _context.Entry(config).CurrentValues.SetValues(entity);

            return entity;
        }
    }
}
