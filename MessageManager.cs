using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject
{
    //
    public class MessageManager
    {
        private static List<EngineSystem> globalEngineSystems = new List<EngineSystem>();

        public static void AddSystem(EngineSystem system)
        {
            globalEngineSystems.Add(system);
        }

        public static void RemoveSystem(EngineSystem system)
        {
            globalEngineSystems.Remove(system);
        }

        public static void SendMessageBroadcast(Message msg)
        {
            foreach(var system in globalEngineSystems)
            {
                if (system == msg.owner)
                    continue;

                if (system.IsSubscribedOnMessageType(msg.type))
                {
                    system.ReceiveMessage(msg);
                }
            }
        }
    }
}
