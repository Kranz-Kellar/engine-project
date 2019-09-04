using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject.ECS
{
    public interface IEntity
    {
        void Init();
        void IsEnabled();
        void Enable();
        void Disable();

        void AddComponent();
        void GetComponent();
        void HasComponent();

    }
}
