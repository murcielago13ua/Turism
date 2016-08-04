﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;

namespace Turism {
    namespace Distances {
        public class ObstacleCource : Distance, IObstacleCource {
            private IList<IntermediateTime> intermediateTimes;
            public IntermediateTime[] IntermediateTimes {
                get {
                    if (this.intermediateTimes == null) {
                        this.intermediateTimes = new List<IntermediateTime>(
                            from stage in this.Stages
                            let intermediateTime = stage as IntermediateTime
                            where intermediateTime != null
                            select intermediateTime);
                    }
                    return this.intermediateTimes.ToArray();
                }
            }
            public ObstacleCource(String name, Guid ID, Int32 length, Int32 height, IEnumerable<Stage> stages, TimeSpan limitTime) :
                base(name, ID, DistType.GetObstacleCourse(), length, height, stages, limitTime) { }
            public ObstacleCource(String name, Int32 length, Int32 height, IEnumerable<Stage> stages, TimeSpan limitTime) :
                this(name, Guid.NewGuid(), length, height, stages, limitTime) { }
        }
    }
}
