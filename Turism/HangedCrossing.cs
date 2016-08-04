using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class HangedCrossing : Crossing {
            private HangedCrossing(Guid ID, Byte length, Boolean waterStage, FirstWalking firstWalking) :
                base("", ID, length, firstWalking) {
                this.Name = waterStage ? "Навісна переправа через річку" : "Навісна переправа через яр";
            }
            public override StageRank Rank {
                get {
                    if (this.Length >= 10 && this.Length <= 20)
                        return StageRank._2A;
                    else if (this.Length > 20 && this.Length <= 30)
                        return StageRank._2B;
                    else if (this.Length > 30 && this.Length <= 50)
                        return StageRank._3A;
                    return StageRank.NK;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public static HangedCrossing GetHangedCrossing(Guid ID, Byte length, FirstWalking firstWalking) {
                return new HangedCrossing(ID, length, false, firstWalking);
            }
            public static HangedCrossing GetHangedCrossing(Byte length, FirstWalking firstWalking) {
                return new HangedCrossing(Guid.NewGuid(), length, false, firstWalking);
            }
            public static HangedCrossing GetHangedCrossingThroughWater(Guid ID, Byte length, FirstWalking firstWalking) {
                return new HangedCrossing(ID, length, true, firstWalking);
            }
            public static HangedCrossing GetHangedCrossingThroughWater(Byte length, FirstWalking firstWalking) {
                return new HangedCrossing(Guid.NewGuid(), length, true, firstWalking);
            }
        }
    }
}
