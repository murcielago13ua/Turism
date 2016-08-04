using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class VerticalClimbdown : StageWithLength {
            public VerticalClimbdown(Guid ID, Byte length) :
                base("Спуск по вертикальних перилах", ID, length, FirstWalking.AsAllTeam) { }
            public VerticalClimbdown(Byte length) : this(Guid.NewGuid(), length) { }
            public override StageRank Rank {
                get {
                    if (this.Length <= 25)
                        return StageRank._2A;
                    else if (this.Length > 25 && this.Length <= 40)
                        return StageRank._2B;
                    return StageRank.NK;
                }

                protected set {
                    base.Rank = value;
                }
            }
        }
    }
}