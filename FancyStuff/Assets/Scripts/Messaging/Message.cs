using System;
using UnityEngine.UI;

namespace Messaging
{
    public class Message
    {
        public string MessageText;
        public string AnswerA;
        public string AnswerB;
        public string AnswerC;
        public string AnswerAbort;
        public Button.ButtonClickedEvent OptionA;
        public Button.ButtonClickedEvent OptionB;
        public Button.ButtonClickedEvent OptionC;
        public Button.ButtonClickedEvent Abort;
    }
}