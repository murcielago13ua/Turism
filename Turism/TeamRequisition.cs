using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.People;

namespace Turism {
    namespace Competitions {
        public sealed class TeamRequisition : TurismBase {
            private IList<Sportsman> squade;
            public Team Team { get; private set; }
            public Sportsman[] Squade { get { return this.squade.ToArray(); } }
            public TeamRequisition(String name, Team team, Guid ID, IEnumerable<Sportsman> sportsmans) : 
                base(name, ID) {
                this.Team = team;         
                this.squade = new List<Sportsman>(sportsmans);
            }
            public TeamRequisition(String name, Team team, IEnumerable<Sportsman> sportsmans) :
                this(name, team, Guid.NewGuid(), sportsmans) { }
        }
    }
}
