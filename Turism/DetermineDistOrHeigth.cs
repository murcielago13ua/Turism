using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class DetermineDistOrHeigth : SpecialStage {
            public DetermineDistOrHeigth(Guid ID) : base("Визначення висоти або відстані", ID) { }
            public DetermineDistOrHeigth() : this(Guid.NewGuid()) { }
        }
    }
}
