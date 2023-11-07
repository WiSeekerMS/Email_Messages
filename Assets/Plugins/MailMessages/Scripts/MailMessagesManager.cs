using UnityEngine;

namespace Plugins.MailMessages.Scripts
{
    public class MailMessagesManager : BaseMailMessages
    {
        [SerializeField] private MailMessagesConfig _mailMessagesConfig;
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
            _config = _mailMessagesConfig;
        }
    }
}