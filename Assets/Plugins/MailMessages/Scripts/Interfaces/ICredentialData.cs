namespace Plugins.MailMessages.Scripts.Interfaces
{
    public interface ICredentialData
    {
        public string Host { get; }
        public int Port { get; }
        public int Timeout { get; }
        public bool EnableSSL { get; }
    }
}