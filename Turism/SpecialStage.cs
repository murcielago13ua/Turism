using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public abstract class SpecialStage : Stage {
            public SpecialStage(String name, Guid ID) : base(name, ID) { }
        }
    }
}
