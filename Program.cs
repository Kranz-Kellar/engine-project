using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineProject.ECS;
using EngineProject.Components;

namespace EngineProject
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            IEntity ent = new Entity("test");

            ent.AddComponent(new HealthComponent(500));
            var hc = (HealthComponent)ent.GetComponent(ComponentType.HEALTH);
            hc.SetCurrentHealth(250);
            Console.WriteLine($"Max health {hc.GetMaxHealth()} \n Current Health {hc.GetCurrentHealth()}");
            hc.SetCurrentHealth(750);
            Console.WriteLine($"Max health {hc.GetMaxHealth()} \n Current Health {hc.GetCurrentHealth()}");

            Console.ReadKey();


            var newEnt = EntityManager.CreateEntity("testing");
           
        }
    }
}
