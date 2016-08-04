using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;

namespace Turism {
    public struct StageTimeLimitsForCross {
        public TimeSpan LimitTime { get; private set; }
        public TimeSpan OptimalTime { get; private set; }
    }
}
