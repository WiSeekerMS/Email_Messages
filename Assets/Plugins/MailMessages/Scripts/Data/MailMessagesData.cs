using Plugins.MailMessages.Scripts.Interfaces;

namespace Plugins.MailMessages.Scripts.Data
{
    public sealed class MailMessagesData : IMailMessagesData
    {
        public string Login { get; }
        public string Password { get; }
        public string Host { get; }
        public int Port { get; }
        public int Timeout { get; }
        public bool EnableSSL { get; }
        public string FromMailAddress { get; }
        public string[] ToMailAddresses { get; }

        public MailMessagesData(string login, string password, string host, int port, 
            int timeout, bool enableSSL, string fromMailAddress, string[] toMailAddresses)
        {
            Login = login;
            Password = password;
            Host = host;
            Port = port;
            Timeout = timeout;
            EnableSSL = enableSSL;
            FromMailAddress = fromMailAddress;
            ToMailAddresses = toMailAddresses;
        }
    }
}