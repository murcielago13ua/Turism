using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class SlopingCrossing : Crossing {
            private SlopingCrossing(Guid ID, Byte length, Boolean upward, FirstWalking firstWalking) :
                base("", ID, length, firstWalking) {
                this.Name = upward ? "Крутопохила переправа вгору" : "Крутопохила переправа вниз";
            }
            public override StageRank Rank {
                get {
                    if (this.Length <= 50)
                        return StageRank._3A;
                    return StageRank.NK;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public static SlopingCrossing GetSlopingCrossing(Guid ID, Byte length, FirstWalking firstWalking) {
                return new SlopingCrossing(ID, length, false, firstWalking);
            }
            public static SlopingCrossing GetSlopingCrossing(Byte length, FirstWalking firstWalking) {
                return new SlopingCrossing(Guid.NewGuid(), length, false, firstWalking);
            }
            public static SlopingCrossing GetSlopingCrossingUpward(Guid ID, Byte length, FirstWalking firstWalking) {
                return new SlopingCrossing(ID, length, true, firstWalking);
            }
            public static SlopingCrossing GetSlopingCrossingUpward(Byte length, FirstWalking firstWalking) {
                return new SlopingCrossing(Guid.NewGuid(), length, true, firstWalking);
            }
        }
    }
}