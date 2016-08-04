using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class Barlings : Stage {
            public Byte BarlingsCount { get; private set; }
            public Byte FootingsCount { get; private set; }
            public Barlings(Guid ID, Byte barlingsCount, Byte footingsCount) : base("Рух по жердинах", ID) {
                if (footingsCount <= 1 || barlingsCount <= 0) {
                    throw new TypeInitializationException(typeof(Barlings).FullName, null);
                }
                this.BarlingsCount = barlingsCount;
                this.FootingsCount = footingsCount;
                this.SetPreparingOption(StagePreparingOption.TeamPreparing);
            }
            public Barlings(Byte barlingsCount, Byte footingsCount) : this(Guid.NewGuid(), barlingsCount, footingsCount) { }
            public override StageRank Rank {
                get {
                    return StageRank._1B;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public override Double Points {
                get {
                    Double points = (this.FootingsCount - 1 <= 10 ? this.FootingsCount - 1 : 10);
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
            public override String Info {
                get {
                    return String.Format("{1}{0}\tкількість опор: {2}{0}\tкількість жердин: {3}",
                        Environment.NewLine,
                        this.ToString(),
                        this.FootingsCount,
                        this.BarlingsCount);
                }
            }
        }
    }
}
