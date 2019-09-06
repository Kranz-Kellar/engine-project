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

#if DEBUG
        public int GetValue() => this.id;
#endif

        public override string ToString()
        {
            return this.id.ToString();
        }


        #region Overrided functions and operators
        public static bool operator == (UniqueId id1, UniqueId id2)
        {
            if (id1 == null || id2 == null)
                return false;
            if (id1.id == id2.id)
                return true;
            return false;
        }

        public static bool operator != (UniqueId id1, UniqueId id2)
        {
            if (id1 == null || id2 == null)
                return false;
            if (id1.id != id2.id)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            var id = obj as UniqueId;
            return id != null &&
                   this.id == id.id;
        }

        public override int GetHashCode()
        {
            return 1877310944 + id.GetHashCode();
        }
        #endregion
    }
}
