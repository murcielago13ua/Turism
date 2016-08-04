using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Distances {
        public interface ICross {
            StageTimeLimitsForCross GetLimitForStage(Stages.Stage stage);
            TimeSpan OptimalTime { get; }
        }
    }
}
