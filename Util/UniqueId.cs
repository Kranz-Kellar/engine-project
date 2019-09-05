using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineProject.Util
{
    public sealed class UniqueId
    {
        private int id;
        private static int globalNextId = 0;

        public UniqueId()
        {
            this.id = GetNextGlobalId();
        }

        private static int GetNextGlobalId()
        {
            return globalNextId++;
        }

        public int GetValue() => this.id;
    }
}
