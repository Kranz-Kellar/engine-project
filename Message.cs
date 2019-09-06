using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject
{

    public class Message
    {
        public MessageType type;
        public object data;

        public Message(MessageType type, object data = null)
        {
            this.type = type;
            this.data = data;
        }

    }

    public enum MessageType
    {
        VOID,
        GLOBAL_MESSAGE,
        
    }
}
