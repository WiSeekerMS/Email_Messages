using System;
using Plugins.MailMessages.Scripts.Data;
using Plugins.MailMessages.Scripts.Enums;
using Plugins.MailMessages.Scripts.Interfaces;
using UnityEngine;

namespace Plugins.MailMessages.Scripts.Example
{
    public class MailMessagesManager : MonoBehaviour
    {
        [SerializeField] private MailMessagesConfig _config;
        private MailMessages _mailMessages;
        private IMailMessagesData _data;
        
        public static MailMessagesManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            _data = new MailMessagesData(_config.Login, _config.Password, _config.Host, _config.Port, _config.Timeout, 
                _config.EnableSSL, _config.FromMailAddress, _config.ToMailAddresses);

            _mailMessages = new MailMessages();
        }

        public async void SendEmailAsync(string subject, string body, Action<SubmissionStatus> statusAction)
        {
            await _mailMessages.SendEmailAsync(_data, subject, body, statusAction);
        }
    }
}