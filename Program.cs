using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineProject.ECS;
using EngineProject.Components;
using EngineProject.Util;
using System.Diagnostics;

namespace EngineProject
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            
            
            EntityManager entityManager = new EntityManager();
            MessageManager.AddSystem(entityManager);

            EngineSystem es = new EngineSystem();
            es.Init();
            es.SendMessage(new Message(MessageType.GLOBAL_MESSAGE, es));

            MessageManager.SendMessageBroadcast(new Message(MessageType.GLOBAL_MESSAGE, null));
           

            s.Stop();
            Logger.Log($"Passed time {s.Elapsed}", LogStatus.DEBUG);
            
        }
    }
}