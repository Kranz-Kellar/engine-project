using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject.ECS
{
    public sealed class EntityManager 
    {
        private static List<IEntity> globalEnts = new List<IEntity>();
        

        public static IEntity CreateEntity(string name)
        {
            IEntity newEnt = new Entity(name);
            globalEnts.Add(newEnt);

            return newEnt;
        }

        public static IEntity GetEntById(Util.UniqueId id)
        {
            return globalEnts.Find(x => x.GetId() == id);
        }

        public static void DisableEntById(Util.UniqueId id)
        {
            GetEntById(id).Disable();
        }

        public static void EnableEntById(Util.UniqueId id)
        {
            GetEntById(id).Enable();
        }

        public static void DestroyEntById(Util.UniqueId id)
        {
            if(GetEntById(id) != null)
            {
                globalEnts.Remove(GetEntById(id));
                return;
            }

            //Log about EntNotFound
            Util.Logger.Log($"Entity with id {id} wasn't found", Util.LogStatus.ERROR);
        }

        public static void EntsMakeStep()
        {
            foreach(var ent in globalEnts)
            {
                
            }
        }
    }
}
