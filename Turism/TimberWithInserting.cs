using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class TimberWithInserting : Timber {
            private TimberWithInserting(Guid ID, Byte length, Boolean waterStage) :
                base("", ID, length, FirstWalking.TeamInsurance) {
                this.Name = waterStage ? "Переправа по колоді через річку із вкладанням" :
                    "Переправа по колоді через яр із вкладанням";
                this.SetPreparingOption(StagePreparingOption.TeamPreparing);
            }
            public override StageRank Rank {
                get {
                    return StageRank._3A;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public override Double Points {
                get {
                    Double points = 12;
                    if (this.HasVictim)
                        points *= 1.2;
                    if (this.HardConditions)
                        points *= 1.2;
                    return points;
                }

                protected set {
                    base.Points = value;
                }
            }
            public static TimberWithInserting GetTimberThroughWater(Guid ID, Byte length) {
                return new TimberWithInserting(ID, length, true);
            }
            public static TimberWithInserting GetTimberThroughWater(Byte length) {
                return new TimberWithInserting(Guid.NewGuid(), length, true);
            }
            public static TimberWithInserting GetTimber(Guid ID, Byte length) {
                return new TimberWithInserting(ID, length, false);
            }
            public static TimberWithInserting GetTimber(Byte length) {
                return new TimberWithInserting(Guid.NewGuid(), length, false);
            }
        }
    }
}