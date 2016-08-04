using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public partial class VictimTransporting {
            private sealed class ClimbdownWithVictim : VictimTransporting {
                public ClimbdownWithVictim(Guid ID, Byte length) :
                    base("Спуск потерпілого із супроводжуючим", ID, length, FirstWalking.AsAllTeam) { }
                public override StageRank Rank {
                    get {
                        return StageRank._2B;
                    }

                    protected set {
                        base.Rank = value;
                    }
                }
            }
            public static VictimTransporting GetClimbdownWithVictim(Guid ID, Byte length) {
                return new ClimbdownWithVictim(ID, length);
            }
            public static VictimTransporting GetClimbdownWithVictim(Byte length) {
                return new ClimbdownWithVictim(Guid.NewGuid(), length);
            }
        }
    }
}
