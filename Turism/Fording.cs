using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class Fording : StageWithLength {
            public Fording(Guid ID, Byte length, FirstWalking firstWalking) : base("Переправа через річку вбрід",
                ID, length, firstWalking) { }
            public Fording(Byte length, FirstWalking firstWalking) : this(Guid.NewGuid(), length, firstWalking) { }
            public override StageRank Rank {
                get {
                    if (this.FirstWalking == FirstWalking.TeamInsurance)
                        return StageRank._1B;
                    return StageRank._1A;
                }

                protected set {
                    base.Rank = value;
                }
            }
        }
    }
}
