using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject.ECS
{
    public class Entity
    {
        private int id;
        private string name;

        private List<Component> components;

        public Entity(string name)
        {
            this.name = name;
            this.components = new List<Component>();

            //Generate unique id
            this.id = 0;
        }

        public int getId()
        {
            return this.id;
        }

        public Component addComponent(Component component)
        {
            components.Add(component);

            return component;
        }

        public Component getComponent()
        {

        }
    }
}
