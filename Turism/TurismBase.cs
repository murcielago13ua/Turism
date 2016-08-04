using System;

namespace Turism {
    public abstract class TurismBase {
        public Guid ID { get; private set; }
        public String Name { get; protected set; }
        public TurismBase() : this("", Guid.NewGuid()) { }
        public TurismBase(String name) : this(name, Guid.NewGuid()) { }
        public TurismBase(String name, Guid ID) {
            this.Name = name;
            this.ID = ID;
        }
        public override Boolean Equals(Object obj) {
            if (ReferenceEquals(this, obj))
                return true;
            TurismBase b = obj as TurismBase;
            if (obj == null)
                return false;
            return this.ID.Equals(b.ID);
        }
        public override Int32 GetHashCode() {
            return base.GetHashCode();
        }
    }
}
