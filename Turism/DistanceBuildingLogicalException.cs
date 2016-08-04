using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Distances {
        public class DistanceBuildingLogicalException : DistanceBuildingException {
            public DistanceBuildingLogicalException(Distances.DistType distType, String howToFix) :
                base(distType, howToFix) { }
        }
    }
}
