using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject.ECS
{
    public class Entity : IEntity
    {
        private int Id;
        private string Name;
        private bool enabled;

        private List<Component> components;
        private BitArray componentMask;

        public Entity(string name)
        {
            this.Name = name;
            this.components = new List<Component>();
            //Magic number
            this.componentMask = new BitArray(32);

            //Generate unique id
            this.Id = 0;
        }

        public int getId()
        {
            return this.Id;
        }

        public Component addComponent(Component component)
        {
            components.Add(component);

            return component;
        }

        public Component getComponent(ComponentType type)
        {
            return components.Find(x => x.GetComponentType() == type);
        }

        public void Init()
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled()
        {
            return enabled;
        }

        public void Enable()
        {
            this.enabled = true;
        }

        public void Disable()
        {
            this.enabled = false;
        }

        public Component AddComponent(Component component)
        {
            //VERY CLEVER, lol
            if (HasComponent(component.GetComponentType()))
                return null;

            this.components.Add(component);
            this.componentMask[(int)component.GetComponentType()] = true;

            return component;
        }

        public Component GetComponent(ComponentType type)
        {
            if (!HasComponent(type))
                return null;

            return components.Find(x => x.GetComponentType() == type);
        }

        public bool HasComponent(ComponentType type)
        {
            if (componentMask[(int)type] != false)
            {
                return true;
            }

            return false;
        }

        public void RemoveComponent(ComponentType type)
        {
            if (!HasComponent(type))
                return;

            var component = this.components.Find(x => x.GetComponentType() == type);
            this.components.Remove(component);
            this.componentMask[(int)type] = false;
        }
    }
}
