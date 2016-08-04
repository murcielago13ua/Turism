using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public abstract class RockMovement : StageWithLength {
            public enum RockDifficult : Byte {
                Simple,
                Normal,
                Hard,
            }
            public RockDifficult Diff { get; protected set; }
            protected RockMovement(String name, Guid ID, Byte length, RockDifficult diff, FirstWalking firstWalking) :
                base(name, ID, length, firstWalking) {
                this.Diff = diff;
            }
            public override StageRank Rank {
                get {
                    if (this.Diff == RockDifficult.Simple)
                        return StageRank._2A;
                    else if (this.Diff == RockDifficult.Normal)
                        return StageRank._2B;
                    return StageRank._3A;
                }

                protected set {
                    base.Rank = value;
                }
            }
        }
    }
}
