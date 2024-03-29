﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineProject.Util;

namespace EngineProject.ECS
{
    public sealed class EntityManager : EngineSystem
    {
        private List<Entity> globalEnts = new List<Entity>();

        public EntityManager()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            this.SubscribeOnMessageType(MessageType.GLOBAL_MESSAGE);
        }

        public UniqueId CreateEntity()
        {
            Entity newEnt = new Entity();
            globalEnts.Add(newEnt);
            //Send message here
            return newEnt.Id;
        }

        private Entity GetEntById(UniqueId id)
        {
            return globalEnts.Find(x => x.Id == id);
        }

        public void DestroyEnt(UniqueId id)
        {
            var ent = GetEntById(id);
            if(ent != null)
            {
                globalEnts.Remove(ent);
                return;
            }

            //Log about EntNotFound
            Logger.Log($"Entity with id {id} wasn't found", LogStatus.ERROR);
        }

        //Убрать прямую передачу ссылки на компонент
        //Заменить передачей типа и создавать компонент внутри,
        //запрашивая фабрику компонентов
        public Component AddComponent(UniqueId id, Component component)
        {
            //Generate message here
            if (HasComponent(id, component.GetComponentType()))
                return null;

            var ent = GetEntById(id);
            ent.components.Add(component);
            ent.componentMask[(int)component.GetComponentType()] = true;

            return component;
        }

        public void RemoveComponent(UniqueId id, ComponentType type)
        {
            //Message here
            if (!HasComponent(id, type))
                return;

            var ent = GetEntById(id);
            ent.components.Remove(ent.components.Find(x => x.GetComponentType() == type));
            ent.componentMask[(int)type] = false;
        }

        public bool HasComponent(UniqueId id, ComponentType type) 
        {
            //Generate message here
            if (id == null)
                return false;

            if (GetEntById(id).componentMask[(int)type] == true)
                return true;

            return false;
        }

        public bool IsEnabled(UniqueId id)
        {
            return GetEntById(id).Enabled;
        }

        public void Enable(UniqueId id)
        {
            GetEntById(id).Enabled = true;
        }

        public void Disabled(UniqueId id)
        {
            GetEntById(id).Enabled = false;
        }

        //Постараться убрать switch
        //
        public override void ReceiveMessage(Message msg)
        {
            switch(msg.type)
            {
                case MessageType.GLOBAL_MESSAGE:
                    Logger.Log("SOMETHING HAPPEND??>", LogStatus.DEBUG);
                    break;
            }
        }
    }
}
