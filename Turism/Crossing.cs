using System;

namespace Turism {
    namespace Stages {
        public abstract class Crossing : StageWithLength {
            public Crossing(String name, Guid ID, Byte length, FirstWalking firstWalking) :
                base(name, ID, length, firstWalking) { }
            public override StageRank Rank {
                get {
                    if (this.HasVictim)
                        return StageRank._3A;
                    return base.Rank;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public override Double Points {
                get {
                    var points = base.Points;
                    if (this.Length < 20)
                        points *= 0.8;
                    else if (this.Length > 30 && this.Length < 40)
                        points *= 1.2;
                    else if (this.Length >= 40)
                        points *= 1.3;
                    if (this.HasVictim)
                        points /= 1.2;
                    return points;
                }

                protected set {
                    base.Points = value;
                }
            }
        }
    }
}
