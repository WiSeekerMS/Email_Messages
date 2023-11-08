using Plugins.MailMessages.Scripts.Interfaces;
using UnityEngine;

namespace Plugins.MailMessages.Scripts.Example
{
    [CreateAssetMenu(menuName = "Configs/MailMessagesConfig", fileName = "MailMessagesConfig")]
    public class MailMessagesConfig : ScriptableObject, IMailMessagesData
    {
        [Header("Authorization")] 
        [SerializeField] private string _login;
        [SerializeField] private string _password;

        [Header("Credential")] 
        [SerializeField] private string _host;
        [SerializeField] private int _port;
        [SerializeField] private int _timeout;
        [SerializeField] private bool _enableSSL;

        [Header("Addresses")]
        [SerializeField] private string _fromMailAddress;
        [SerializeField] private string[] _toMailAddresses;

        public string Login => _login;
        public string Password => _password;
        public string Host => _host;
        public int Port => _port;
        public int Timeout => _timeout;
        public bool EnableSSL => _enableSSL;
        public string FromMailAddress => _fromMailAddress;
        public string[] ToMailAddresses => _toMailAddresses;
    }
}