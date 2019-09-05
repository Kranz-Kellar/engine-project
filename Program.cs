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
            var ent = EntityManager.CreateEntity("test");
            ent.AddComponent(new HealthComponent(500));


            for (int i = 0; i < 100; i++)
            {
                var ent2 = EntityManager.CreateEntity("test");
                Logger.Log($"{ent2.GetId().GetValue()}", LogStatus.INFO);
            }

            s.Stop();

            Logger.Log($"Passed time {s.Elapsed}", LogStatus.DEBUG);
            
        }
    }
}