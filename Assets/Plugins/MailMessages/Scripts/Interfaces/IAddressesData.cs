namespace Plugins.MailMessages.Scripts.Interfaces
{
    public interface IAddressesData
    {
        public string FromMailAddress { get; }
        public string[] ToMailAddresses { get; }
    }
}