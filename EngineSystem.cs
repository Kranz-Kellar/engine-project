using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject
{
    //Класс для группировки всех систем
    //Нужен для MessageManager
    public class EngineSystem
    {
        public List<MessageType> subscribedMessageType;
        public virtual void Init()
        {
            subscribedMessageType = new List<MessageType>();
        }

        public void SubscribeOnMessageType(MessageType type)
        {
            if (!IsSubscribedOnMessageType(type))
            subscribedMessageType.Add(type);
        }

        public void SendMessage(Message msg)
        {
            if (msg == null)
                return;

            MessageManager.SendMessageBroadcast(msg);
        }

        public bool IsSubscribedOnMessageType(MessageType type)
        {
            if (subscribedMessageType.Contains(type))
                return true;

            return false;
        }

        public virtual void ReceiveMessage(Message msg) { }
    }
}
