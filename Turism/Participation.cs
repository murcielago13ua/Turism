using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.People;
using Turism.Stages;

namespace Turism {
    namespace Competitions {
        public sealed class Participation : TurismBase {
            private TeamRequisition teamRequisition;
            private DistanceResult resultOnDistance;
            public Participation(Guid ID, TeamRequisition requisition, DistanceResult resultOnDistance) :
                base("", ID) {
                this.teamRequisition = requisition;
                this.resultOnDistance = resultOnDistance;
            }
            public Participation(TeamRequisition requisition, DistanceResult resultOnDistance) : base() {
                this.teamRequisition = requisition;
                this.resultOnDistance = resultOnDistance;
            }
            public Sportsman[] Squade { get { return teamRequisition.Squade; } }
            public StageResult GetResultOnStage(Stage stage) {
                return this.resultOnDistance.GetResultByStage(stage);
            }
            public Guid GetDistanceResultID() { return this.resultOnDistance.ID; }
            public Guid GetTeamRequisitionID() { return this.teamRequisition.ID; }
            public Team GetTeam() {
                return this.teamRequisition.Team;
            }
        }
    }
}
