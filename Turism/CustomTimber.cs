using System;

namespace Turism {
    namespace Stages {
        public sealed class CustomTimber : Timber {
            public Boolean HardToWalk { get; private set; }
            private void Initialize(Boolean waterStage, Boolean hardToWalk, FirstWalking firstWalking) {
                this.Name = waterStage ? "Переправа по колоді через річку" : "Переправа по колоді через яр";
                this.HardToWalk = hardToWalk;
            }

            private CustomTimber(Guid ID, Byte length, Boolean hardToWalk, Boolean waterStage, FirstWalking firstWalking) :
                base("", ID, length, firstWalking) {
                Initialize(waterStage, hardToWalk, firstWalking);
            }

            public override StageRank Rank {
                get {
                    if (this.PreparingOption == StagePreparingOption.NoPreparing && this.HardToWalk)
                        return StageRank._1B;
                    else if (this.PreparingOption == StagePreparingOption.TeamPreparing) {
                        if (!this.HardToWalk)
                            return StageRank._2A;
                        else
                            return StageRank._2B;
                    }
                    return StageRank._1A;
                }
                protected set {
                    base.Rank = value;
                }
            }
            public static CustomTimber GetSimpleTimberThroughWater(Guid ID, Byte length, FirstWalking firstWalking) {
                return new CustomTimber(ID, length, false, true, firstWalking);
            }
            public static CustomTimber GetSimpleTimberThroughWater(Byte length, FirstWalking firstWalking) {
                return new CustomTimber(Guid.NewGuid(), length, false, true, firstWalking);
            }
            public static CustomTimber GetSimpleTimber(Guid ID, Byte length, FirstWalking firstWalking) {
                return new CustomTimber(ID, length, false, false, firstWalking);
            }
            public static CustomTimber GetSimpleTimber(Byte length, FirstWalking firstWalking) {
                return new CustomTimber(Guid.NewGuid(), length, false, false, firstWalking);
            }
            public static CustomTimber GetHardTimber(Guid ID, Byte length, FirstWalking firstWalking) {
                return new CustomTimber(ID, length, true, false, firstWalking);
            }
            public static CustomTimber GetHardTimber(Byte length, FirstWalking firstWalking) {
                return new CustomTimber(Guid.NewGuid(), length, true, false, firstWalking);
            }
            public static CustomTimber GetHardTimberThroughWater(Guid ID, Byte length, FirstWalking firstWalking) {
                return new CustomTimber(ID, length, true, true, firstWalking);
            }
            public static CustomTimber GetHardTimberThroughWater(Byte length, FirstWalking firstWalking) {
                return new CustomTimber(Guid.NewGuid(), length, true, true, firstWalking);
            }
        }
    }
}