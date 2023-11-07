using UnityEngine;
using UnityEngine.UI;

namespace Plugins.MailMessages.Scripts
{
    public class SendMessageView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _informationText;
        [SerializeField] private string _messageSubject;
        [SerializeField] private string _messageBody;

        private void Awake()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnClick()
        {
            if (MailMessagesManager.Instance == null)
            {
                return;
            }

            _button.interactable = false; 
            MailMessagesManager.Instance.SendEmailAsync(_messageSubject, _messageBody, OnMessageSent);
        }

        private void OnMessageSent(SubmissionStatus status)
        {
            switch (status)
            {
                case SubmissionStatus.Sent:
                    _informationText.text = "Message sent";
                    break;
                case SubmissionStatus.Error:
                    _informationText.text = "An error occurred while sending";
                    break;
            }
            
            _button.interactable = true;
        }
    }
}