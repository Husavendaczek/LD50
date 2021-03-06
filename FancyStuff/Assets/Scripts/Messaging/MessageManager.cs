using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Messaging
{
    public class MessageManager : MonoBehaviour
    {
        public GameObject messageGameObject;
        public GameObject simpleMessageGameObject;

        private GameObject simpleMessage;
        private bool _isShowingSimpleMessage = false;

        private void Update()
        {
            if(simpleMessage == null) return;
            
            if (!_isShowingSimpleMessage) return;
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                simpleMessage.gameObject.SetActive(false);
            }
        }

        public void ShowMessage(Message message)
        {
            var messageMono = messageGameObject.GetComponent<MessageMono>();
            messageMono.messageText.GetComponent<TextMeshProUGUI>().text = message.MessageText;
            
            var answerA = messageMono.answerA.GetComponent<MessageOption>();
            answerA.messageText.GetComponent<TextMeshProUGUI>().text = message.AnswerA;
            answerA.gameObject.GetComponent<Button>().onClick = message.OptionA;
            
            var answerB = messageMono.answerB.GetComponent<MessageOption>();
            answerB.messageText.GetComponent<TextMeshProUGUI>().text = message.AnswerB;
            answerB.gameObject.GetComponent<Button>().onClick = message.OptionB;
            
            var answerC = messageMono.answerC.GetComponent<MessageOption>();
            answerC.messageText.GetComponent<TextMeshProUGUI>().text = message.AnswerC;
            answerC.gameObject.GetComponent<Button>().onClick = message.OptionC;
            
            var answerAbort = messageMono.answerAbort.GetComponent<MessageOption>();
            answerAbort.messageText.GetComponent<TextMeshProUGUI>().text = message.AnswerAbort;
            answerAbort.gameObject.GetComponent<Button>().onClick = message.Abort;
            
            messageGameObject.SetActive(true);
            _isShowingSimpleMessage = false;
        }

        public void ShowSimpleMessage(SimpleMessage message)
        {
            if (simpleMessage == null)
            {
                simpleMessage = Instantiate(simpleMessageGameObject, transform, true);
                simpleMessage.name = "Messsage";
                simpleMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-125, 75, 0);
                
            }
            
            simpleMessage.GetComponent<SimpleMessageMono>().textElement.GetComponent<TextMeshProUGUI>().text = message.MessageText;
            simpleMessage.gameObject.SetActive(true);

            _isShowingSimpleMessage = true;
        }

        public void HideMessage()
        {
            simpleMessage.gameObject.SetActive(false);
            // messageGameObject.SetActive(false);
            
            _isShowingSimpleMessage = false;
        }
    }
}