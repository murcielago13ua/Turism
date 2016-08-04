using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Distances {
        public class RescueBuildingException : DistanceBuildingException {
            public RescueBuildingException(Boolean shortRescue, String howToFix) :
                base(shortRescue ? Distances.DistType.GetShortRescue() : Distances.DistType.GetLongRescue(), howToFix) { }
        }
    }
}
