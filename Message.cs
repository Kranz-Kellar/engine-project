using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject
{

    public class Message
    {
        public EngineSystem owner;
        public MessageType type;
        public object data;

        public Message(MessageType type, EngineSystem owner, object data = null)
        {
            this.type = type;
            this.owner = owner;
            this.data = data;
        }

    }

    public enum MessageType
    {
        VOID,
        GLOBAL_MESSAGE,
        
    }
}
