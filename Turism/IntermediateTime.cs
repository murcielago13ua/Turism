using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public class IntermediateTime : Stage {
            public TimeSpan Time { get; private set; }
            public IntermediateTime(String name, Guid ID, TimeSpan time) : base(name, ID) {
                this.Time = time;
            }
            public IntermediateTime(String name, TimeSpan time) : this(name, Guid.NewGuid(), time) { }
        }
    }
}
