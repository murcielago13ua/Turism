using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class MovementOnBoats : Stage {
            public MovementOnBoats(Guid ID) : base("Переправа на плавзасобах", ID) { }
            public MovementOnBoats() : this(Guid.NewGuid()) { }
            public override StageRank Rank {
                get {
                    return StageRank._1A;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public override Double Points {
                get {
                    return 4;
                }

                protected set {
                    base.Points = value;
                }
            }
        }
    }
}
