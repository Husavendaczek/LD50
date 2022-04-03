using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Messaging
{
    public class MessageManager : MonoBehaviour
    {
        public GameObject messageGameObject;
        public GameObject simpleMessageGameObject;

        private bool _isShowingSimpleMessage = false;

        private void Update()
        {
            if (!_isShowingSimpleMessage) return;
            
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
            {
                simpleMessageGameObject.SetActive(false);
            }
        }

        public void ShowMessage(Message message)
        {
            var messageMono = messageGameObject.GetComponent<MessageMono>();
            messageMono.messageText.GetComponent<TextMeshPro>().text = message.MessageText;
            
            var answerA = messageMono.answerA.GetComponent<MessageOption>();
            answerA.messageText.GetComponent<TextMeshPro>().text = message.AnswerA;
            answerA.gameObject.GetComponent<Button>().onClick = message.OptionA;
            
            var answerB = messageMono.answerB.GetComponent<MessageOption>();
            answerB.messageText.GetComponent<TextMeshPro>().text = message.AnswerB;
            answerB.gameObject.GetComponent<Button>().onClick = message.OptionB;
            
            var answerC = messageMono.answerC.GetComponent<MessageOption>();
            answerC.messageText.GetComponent<TextMeshPro>().text = message.AnswerC;
            answerC.gameObject.GetComponent<Button>().onClick = message.OptionC;
            
            var answerAbort = messageMono.answerAbort.GetComponent<MessageOption>();
            answerAbort.messageText.GetComponent<TextMeshPro>().text = message.AnswerAbort;
            answerAbort.gameObject.GetComponent<Button>().onClick = message.Abort;
            
            messageGameObject.SetActive(true);
            _isShowingSimpleMessage = false;
        }

        public void ShowSimpleMessage(SimpleMessage message)
        {
            simpleMessageGameObject.GetComponent<TextMeshPro>().text = message.MessageText;
            simpleMessageGameObject.SetActive(true);

            _isShowingSimpleMessage = true;
        }

        public void HideMessage()
        {
            messageGameObject.SetActive(false);
            simpleMessageGameObject.SetActive(false);
            _isShowingSimpleMessage = false;
        }
    }
}