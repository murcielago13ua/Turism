using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public abstract class Timber : StageWithLength {
            public Timber(String name, Byte length, FirstWalking firstWalking) :
                this(name, Guid.NewGuid(), length, firstWalking) { }
            public Timber(String name, Guid ID, Byte length, FirstWalking firstWalking) :
                base(name, ID, length, firstWalking) { }
        }
    }
}
