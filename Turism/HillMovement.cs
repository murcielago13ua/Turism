using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public abstract class HillMovement : StageWithLength {
            public Boolean HardHill { get; protected set; }
            public HillMovement(String name, Guid ID, Byte length, Boolean hardHill, FirstWalking firstWalking) :
                base(name, ID, length, firstWalking) {
                this.HardHill = hardHill;
            }
            public override StageRank Rank {
                get {
                    if (this.HardHill)
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
