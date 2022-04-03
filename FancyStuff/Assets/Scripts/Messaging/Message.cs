using System;

namespace Messaging
{
    public class Message
    {
        public string MessageText;
        public string AnswerA;
        public string AnswerB;
        public string AnswerC;
        public string AnswerAbort;
        public Action OptionA;
        public Action OptionB;
        public Action OptionC;
        public Action Abort;
    }
}