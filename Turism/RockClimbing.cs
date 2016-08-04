using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class RockClimbing : RockMovement {
            public RockClimbing(Guid ID, Byte length, RockDifficult diff, FirstWalking firstWalking) :
                base("Підйом по скельній ділянці", ID, length, diff, firstWalking) { }
            public RockClimbing(Byte length, RockDifficult diff, FirstWalking firstWalking):
                this(Guid.NewGuid(), length, diff, firstWalking) { }
        }
    }
}
