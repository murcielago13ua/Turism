using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class VerticalClimbing : StageWithLength {
            public VerticalClimbing(Guid ID, Byte length, FirstWalking firstWalking) :
                base("Підйом по вертикальних перилах", ID, length, firstWalking) { }
            public VerticalClimbing(Byte length, FirstWalking firstWalking) :
                this(Guid.NewGuid(), length, firstWalking) { }
            public override StageRank Rank {
                get {
                    if (this.Length <= 10)
                        return StageRank._2B;
                    else if (this.Length > 10 && this.Length <= 30)
                        return StageRank._3A;
                    return StageRank.NK;
                }

                protected set {
                    base.Rank = value;
                }
            }
        }
    }
}