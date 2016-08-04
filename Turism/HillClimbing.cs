using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class HillClimbing : HillMovement {
            private HillClimbing(Guid ID, Byte length, Boolean hardHill, FirstWalking firstWalking) :
                base("Підйом по схилу", ID, length, hardHill, firstWalking) { }
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
            public static HillClimbing GetSimpleHillClimbing(Guid ID, Byte length, FirstWalking firstWalking) {
                return new HillClimbing(ID, length, false, firstWalking);
            }
            public static HillClimbing GetSimpleHillClimbing(Byte length, FirstWalking firstWalking) {
                return new HillClimbing(Guid.NewGuid(), length, false, firstWalking);
            }
            public static HillClimbing GetHardHillClimbing(Guid ID, Byte length, FirstWalking firstWalking) {
                return new HillClimbing(ID, length, true, firstWalking);
            }
            public static HillClimbing GetHardHillClimbing(Byte length, FirstWalking firstWalking) {
                return new HillClimbing(Guid.NewGuid(), length, true, firstWalking);
            }
        }
    }
}
