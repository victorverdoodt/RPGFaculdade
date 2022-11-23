using System;

namespace RPGFaculdade.Events
{
    public class MessageEvent : EventArgs
    {
        public string Message { get; private set; }
        public MessageEvent(string message)
        {
            Message = message;
        }
    }
}
