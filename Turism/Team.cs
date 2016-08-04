using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace People {
        public class Team : TurismBase {
            private readonly IList<Sportsman> sportsmans;
            public Sportsman[] Sportsmans { get { return this.sportsmans.ToArray(); } }
            public Coach Coach { get; private set; }
            public Team(String name, Guid ID, Person coach, IEnumerable<Sportsman> sportrmans) : 
                base(name, ID) {
                this.Coach = People.Coach.FromPerson(coach);
                this.sportsmans = new List<Sportsman>(sportsmans);
            }
            public Team(String name, Person coach, IEnumerable<Sportsman> sportrmans) : 
                this(name, Guid.NewGuid(), coach, sportrmans) { }
            public Boolean Contains(Sportsman sportsman) => this.sportsmans.Contains(sportsman);
            public override Boolean Equals(Object obj) {
                if (base.Equals(obj)) {
                    return true;
                }
                Team other = obj as Team;
                if (other == null)
                    return false;
                return
                    this.Name.Equals(other.Name) && this.Coach.Equals(other.Coach) &&
                    this.sportsmans.SequenceEqual(other.sportsmans);
            }
            public override Int32 GetHashCode() {
                return base.GetHashCode();
            }
        }
    }
}
