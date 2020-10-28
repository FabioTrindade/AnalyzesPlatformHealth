namespace MonitoringHealth.Models
{
    public class Contato
    {
        public Contato(string nomeContato, string emailContato, string mensagemContato)
        {
            this.NomeContato = nomeContato;
            this.EmailContato = emailContato;
            this.MensagemContato = mensagemContato;

        }
        public string NomeContato { get; set; }

        public string EmailContato { get; set; }

        public string MensagemContato { get; set; }
    }
}