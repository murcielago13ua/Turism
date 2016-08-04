using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class Hillock : StageWithLength {
            public Hillock(Guid ID, Byte length) : base("Рух по купинах", ID,length, FirstWalking.AsAllTeam) { }
            public override StageRank Rank {
                get {
                    return StageRank.NK;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public override Double Points {
                get {
                    return 2;
                }

                protected set {
                    base.Points = value;
                }
            }
        }
    }
}
