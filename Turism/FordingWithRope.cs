using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class FordingWithRope : StageWithLength {
            public enum FordingOption {
                A,
                B,
                C,
                D,
            }
            public FordingOption FordOp { get; private set; }
            public FordingWithRope(Guid ID, Byte length, FordingOption fordOp, FirstWalking firstWalking) :
                base("Переправа через річку вбрід з використанням перил",
                ID, length, firstWalking) { this.FordOp = fordOp; }
            public FordingWithRope(Byte length, FordingOption fordOp, FirstWalking firstWalking):
                this(Guid.NewGuid(), length, fordOp, firstWalking) { }
            public override StageRank Rank {
                get {
                    if (this.FordOp == FordingOption.A)
                        return StageRank._1A;
                    else if (this.FordOp == FordingOption.B)
                        return StageRank._1B;
                    else if (this.FordOp == FordingOption.C)
                        return StageRank._2A;
                    return StageRank._2B;
                }

                protected set {
                    base.Rank = value;
                }
            }
        }
    }
}
