using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineProject.Components;
using EngineProject.Util;

namespace EngineProject.ECS
{
    public class Entity
    {
        public UniqueId Id;
        public bool Enabled;

        public List<Component> components;
        public BitArray componentMask;

        public Entity()
        {
            this.Id = new UniqueId();
            this.components = new List<Component>();
            //Filthy, but dynamical
            this.componentMask = new BitArray(32);
        }
    }
}
