using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public enum TransportingOption {
            SedanChair,
            Cocoon,
            SedanChairWithSpider,
            Other,
            None,
        }
        public partial class VictimTransporting : StageWithLength {

            public TransportingOption TransOp { get; private set; }
            public Boolean FirstHelp { get; private set; }
            public Boolean TeamTransporting { get; private set; }
            private VictimTransporting(String name, Guid ID, Byte length, FirstWalking firstWalking) :
                base(name, ID, length, firstWalking) {
                this.TransOp = TransportingOption.None;
                this.FirstHelp = false;
                this.TeamTransporting = false;
                this.SetVictim(true);
            }
            public override StageRank Rank {
                get {
                    if (this.TransOp == TransportingOption.None)
                        return StageRank.NK;
                    return StageRank._1A;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public override Double Points {
                get {
                    Double points = (Byte)this.Length / 50;
                    if (this.TransOp != TransportingOption.None)
                        points += 2;
                    if (this.HardConditions)
                        points *= 1.2;
                    return points;
                }

                protected set {
                    base.Points = value;
                }
            }
            public VictimTransporting SetFirstHelp(Boolean firstHelp) {
                this.FirstHelp = firstHelp;
                return this;
            }
            public VictimTransporting SetTeamTransporting(Boolean teamTransporting) {
                if (this is VictimsLifting || this is ClimbdownWithVictim) {
                    throw new StageBuildingLogicalException(this.GetType());
                }
                this.TeamTransporting = teamTransporting;
                return this;
            }
            public VictimTransporting SetTransportingOption(TransportingOption transOp) {
                if (this is VictimsLifting || this is ClimbdownWithVictim) {
                    throw new StageBuildingLogicalException(this.GetType());
                }
                this.TransOp = transOp;
                return this;
            }
            public static VictimTransporting GetTransporting(Guid ID, Byte length) {
                return new VictimTransporting("Транспортування потерпілого", ID, length, FirstWalking.AsAllTeam);
            }
            public static VictimTransporting GetTransporting(Byte length) {
                return new VictimTransporting("Транспортування потерпілого", Guid.NewGuid(), length, FirstWalking.AsAllTeam);
            }
        }
    }
}