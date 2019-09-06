using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject
{
    //Класс для группировки всех систем
    //Нужен для MessageManager
    public abstract class EngineSystem
    {
        public List<MessageType> subscribedMessageType;
        public virtual void Init()
        {
            subscribedMessageType = new List<MessageType>();
        }

        public void SubscribeOnMessageType(MessageType type)
        {
            this.subscribedMessageType.Add(type);
        }

        public void SendMessage(Message msg)
        {
            if (msg == null)
                return;

            MessageManager.SendMessageBroadcast(msg);
        }

        public bool SubscribedOnMessageType(MessageType type)
        {
            if (subscribedMessageType.Contains(type))
                return true;

            return false;
        }

        public abstract void ReceiveMessage(Message msg);
    }
}
