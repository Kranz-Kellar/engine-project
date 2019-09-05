using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineProject.Components;

namespace EngineProject.ECS
{
    public class Entity : IEntity
    {
        private Util.UniqueId Id;
        private string Name;
        private bool Enabled;

        private List<Component> components;
        private BitArray componentMask;

        public Entity(string name)
        {
            this.Id = new Util.UniqueId();
            this.Name = name;
            this.components = new List<Component>();
            //Magic number
            this.componentMask = new BitArray(32);
        }

        public Util.UniqueId GetId()
        {
            return this.Id;
        }

        public void Init()
        {
            this.Enabled = true;
        }

        public bool IsEnabled()
        {
            return Enabled;
        }

        public void Enable()
        {
            this.Enabled = true;
        }

        public void Disable()
        {
            this.Enabled = false;
        }

        public void ChangeName(string newName)
        {
            this.Name = newName;
        }

        public Component AddComponent(Component component)
        {
            //VERY CLEVER, lol
            //Later this will return something more informative
            if (HasComponent(component.GetComponentType()))
            {
                Util.Logger.Log($"Component of type {component.GetComponentType()} is already exists in entity {this.Id}", Util.LogStatus.ERROR);
                return null;
            }

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
                return true;

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
