using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Distances;
using Turism.People;

namespace Turism {
    namespace Competitions {
        public class DistanceOrganizing : TurismBase {
            public Distance Distance { get; private set; }
            public Competition Competition { get; private set; }
            public readonly Byte PARTICIPANTS_COUNT;
            public readonly Byte MAX_REQUISITIONS_FOR_TEAM;
            public readonly Byte PENALTY_PRICE;
            private readonly IList<Participation> participations;
            public DistanceOrganizing(Guid ID, Distance distance, Competition competition, Byte participantsCount, 
                Byte maxRequisitionsForTeam, Byte penaltyPrice) : base(String.Empty, ID) {
                if (participantsCount < 1 || maxRequisitionsForTeam < 1 || penaltyPrice < 1) {
                    throw new TypeInitializationException(nameof(DistanceOrganizing), null);
                }
                this.Distance = distance;
                this.Competition = competition;
                this.PARTICIPANTS_COUNT = participantsCount;
                this.MAX_REQUISITIONS_FOR_TEAM = maxRequisitionsForTeam;
                this.PENALTY_PRICE = penaltyPrice;
                this.participations = new List<Participation>();
            }
            public DistanceOrganizing(Guid ID, Distance distance, Competition competition, Byte participantsCount,
                Byte maxRequisitionsForTeam, Byte penaltyPrice, IEnumerable<Participation> participations) : 
                this(ID, distance, competition, participantsCount, maxRequisitionsForTeam, penaltyPrice) {
                foreach (var particip in participations) {
                    this.participations.Add(particip);
                }
            }
            public DistanceOrganizing(Distance distance, Competition competition, Byte participantsCount,
                Byte maxRequisitionsForTeam, Byte penaltyPrice) : 
                this(Guid.NewGuid(), distance, competition, participantsCount, maxRequisitionsForTeam, penaltyPrice) { }
            public void DeclareTeam(TeamRequisition teamRequisition, DistanceResult resultOnDistance) {
                if (teamRequisition.Squade.Length != this.PARTICIPANTS_COUNT) {
                    throw new ArgumentException("Too much or too little sportsmans in requisition of team");
                }
                this.participations.Add(new Participation(teamRequisition, resultOnDistance));
            }
            public Participation GetParticipationInfo(Team team) {
                return
                    (from particip in this.participations
                     where particip.GetTeam().Equals(team)
                     select particip).Single();
            }
        }
    }
}
