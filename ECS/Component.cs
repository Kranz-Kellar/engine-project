using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject.ECS
{
    public abstract class Component
    {
        protected int id;
        protected ComponentType type;

        public Component()
        {
            //Setting unque id here
            this.id = 0;           
        }

        public int GetId() => this.id;
        public ComponentType GetComponentType() => this.type;
    }

    public enum ComponentType
    {
        VOID,
        HEALTH
    }
}
