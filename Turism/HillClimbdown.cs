using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class HillClimbdown : HillMovement {
            private HillClimbdown(Guid ID, Byte length, Boolean hardHill) :
                base("Спуск по схилу", ID, length, hardHill, FirstWalking.AsAllTeam) { }
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
            public static HillClimbdown GetSimpleHillClimbdown(Guid ID, Byte length) {
                return new HillClimbdown(ID, length, false);
            }
            public static HillClimbdown GetSimpleHillClimbdown(Byte length) {
                return new HillClimbdown(Guid.NewGuid(), length, false);
            }
            public static HillClimbdown GetHardHillClimbdown(Guid ID, Byte length) {
                return new HillClimbdown(ID, length, true);
            }
            public static HillClimbdown GetHardHillClimbing(Byte length) {
                return new HillClimbdown(Guid.NewGuid(), length, true);
            }
        }
    }
}
