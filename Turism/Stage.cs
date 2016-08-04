using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public abstract class Stage : TurismBase {
            public StagePreparingOption PreparingOption { get; private set; }
            protected StageRank rank;
            public virtual StageRank Rank { get { return this.rank; } protected set { this.rank = value; } }
            public virtual String FullName { get; protected set; }
            protected Double points;
            public virtual Double Points {
                get {
                    var rank = this.Rank;
                    switch (rank) {
                        case StageRank._1A:
                            return 4;
                        case StageRank._1B:
                            return 6;
                        case StageRank._2A:
                            return 8;
                        case StageRank._2B:
                            return 10;
                        case StageRank._3A:
                            return 12;
                        default:
                            return this.points;
                    }
                }
                protected set { this.points = value; }
            }
            public Boolean HasVictim { get; private set; }
            public Boolean HardConditions { get; private set; }
            public Stage(String name, Guid ID) : base(name, ID) {
                this.HasVictim = false;
                this.HardConditions = false;
                this.Rank = StageRank.NK;
                this.PreparingOption = StagePreparingOption.NoPreparing;
                this.Points = 0;
            }
            public override String ToString() {
                return String.Format("{0}{1} {2} ({3} б.)",
                    Name, this.HasVictim ? " з потерпілим" : String.Empty
                    , Rank.ToUkrString(), Points);
            }
            public virtual String Info {
                get {
                    return String.Format("{1},{0}\tпараметри наведення: {2}{3} ",
                        Environment.NewLine,
                        this.ToString(),
                        this.PreparingOption.ToUkrString(),
                        this.HardConditions ? "\n\tз ускладненими умовами роботи" : String.Empty);
                }
            }
            public Stage SetVictim(Boolean value) {
                if (this is VictimTransporting) {
                    throw new StageBuildingLogicalException(this.GetType());
                }
                this.HasVictim = value;
                return this;
            }
            public Stage SetHardConditions(Boolean value) {
                this.HardConditions = value;
                return this;
            }
            public Stage SetPreparingOption(StagePreparingOption prepOp) {
                if (this is TimberWithInserting || this is Ticker) {
                    throw new StageBuildingLogicalException(this.GetType());
                }
                this.PreparingOption = prepOp;
                return this;
            }
        }
    }
}
