using MonitoringHealth.Console.Interfaces;
using MonitoringHealth.Console.Interfaces.Repository;
using System.Linq;

namespace MonitoringHealth.Console.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public void Process()
        {
            System.Console.WriteLine("Obtendo a lista:");
            var list = _configurationRepository.GetAll();
            System.Console.WriteLine("Objetos obtidos:" + list.Count());

            foreach (var item in list)
            {
                System.Console.WriteLine("Nome serviço:" + item.Description + " Url:" + item.Url);
            }
            System.Console.WriteLine("Pressione uma tecla para finalizar!");
            System.Console.ReadKey();
        }

        public void Teste()
        {
            throw new System.NotImplementedException();
        }
    }
}
