using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Competitions {
        public sealed class Competition : TurismBase {
            public DateTime Date { get; set; }
            public Competition(String name, Guid ID, DateTime date) : base(name, ID) {
                this.Date = date;
            }
            public Competition(String name, DateTime date) : base(name) {
                this.Date = date;
            }
        }
    }
}
