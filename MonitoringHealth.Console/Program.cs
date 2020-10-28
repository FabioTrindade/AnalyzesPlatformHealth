using ConsoleEnviarEmail.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonitoringHealth.Console.Data;
using MonitoringHealth.Console.Interfaces;
using MonitoringHealth.Console.Interfaces.Repository;
using MonitoringHealth.Console.Models;
using MonitoringHealth.Console.Repository;
using MonitoringHealth.Console.Services;
using MonitoringHealth.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace MonitoringHealth.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Filho da puta funciona!");

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var eventService = serviceProvider.GetService<IConfigurationService>();

            System.Console.WriteLine("Iniciando a aplicação");
            eventService.Process();
            eventService.Teste();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            var mySettingsConfig = new ConnectionStrings();
            configuration.GetSection("ConnectionStrings").Bind(mySettingsConfig);

            System.Console.WriteLine("Connection string: " + configuration.GetConnectionString("AnalyzesPlatformHealthCn"));

            //Console.ReadKey();
            services.AddDbContext<MonitoringHealthDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("AnalyzesPlatformHealthCn"), opt =>
                        {
                            opt.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                            opt.MigrationsHistoryTable("MonitoringHealth_Migrations");
                        })
                );

            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        }

        private static SmtpConfig CarregarAppSettings()
        {
            SmtpConfig _smtpConfig = new SmtpConfig();
            IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", true, true)
                            .Build();
            var appSetting = configuration.GetSection(nameof(SmtpConfig));

            _smtpConfig.Smtp = appSetting["smtp"];
            _smtpConfig.Username = appSetting["username"];
            _smtpConfig.Password = appSetting["password"];
            _smtpConfig.Port = Convert.ToInt32(appSetting["port"]);
            return _smtpConfig;
        }

        private static void RealizarEnvioDeEmail(SmtpConfig smtpConfig)
        {
            var model = new Contato(
                nomeContato: "Teste",
                emailContato: "teste@teste.com.br",
                mensagemContato: "E-mail de Teste"
                );

            var email = new EnviarEmailServices(
                smtpConfig.Smtp,
                smtpConfig.Username,
                smtpConfig.Password,
                smtpConfig.Port);

            string tituloEmail = "E-mail de Contato";

            StringBuilder msg = new StringBuilder();
            msg.AppendLine($"Nome: {model.NomeContato}");
            msg.AppendLine($"E-mail: {model.EmailContato}");
            msg.AppendLine($"Mensagem: {model.MensagemContato}");

            email.Send(smtpConfig.Username, model.EmailContato, tituloEmail, msg.ToString());
        }
    }
}
