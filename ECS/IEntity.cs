using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject.ECS
{
    public interface IEntity
    {
        Util.UniqueId GetId();
        void Init();
        bool IsEnabled();
        void Enable();
        void Disable();

        Component AddComponent(Component component);
        Component GetComponent(ComponentType type);
        void RemoveComponent(ComponentType type);
        bool HasComponent(ComponentType type);

    }
}
