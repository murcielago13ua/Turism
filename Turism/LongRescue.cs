using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;

namespace Turism {
    namespace Distances {
        public class LongRescue : Rescue, ICross{
            private readonly IDictionary<Guid, StageTimeLimitsForCross> limitsForStages;
            public TimeSpan OptimalTime { get; private set; }
            public LongRescue(String name, Guid ID, Int32 length, Int32 height, IDictionary<Stage, StageTimeLimitsForCross> stagesAndLimits, 
                TimeSpan limitTime) : this(name, ID, length, height, stagesAndLimits, limitTime, limitTime) { }
            public LongRescue(String name, Guid ID, Int32 length, Int32 height, IDictionary<Stage, StageTimeLimitsForCross> stagesAndLimits,
                TimeSpan limitTime, TimeSpan optimalTime) : base(name, ID, DistType.GetLongRescue(), length, height, 
                    stagesAndLimits.Keys, limitTime) {
                this.limitsForStages = new Dictionary<Guid, StageTimeLimitsForCross>();
                foreach (var pair in stagesAndLimits) {
                    this.limitsForStages.Add(pair.Key.ID, pair.Value);
                }
                this.OptimalTime = optimalTime;
            }
            public LongRescue(String name, Int32 length, Int32 height, IDictionary<Stage, StageTimeLimitsForCross> stagesAndLimits,
                TimeSpan limitTime, TimeSpan optimalTime) :
                 this(name, Guid.NewGuid(), length, height, stagesAndLimits, limitTime, optimalTime) { }
            public LongRescue(String name, Int32 length, Int32 height, IDictionary<Stage, StageTimeLimitsForCross> stagesAndLimits,
                TimeSpan limitTime) : this(name, length, height, stagesAndLimits, limitTime, limitTime) { }
            public StageTimeLimitsForCross GetLimitForStage(Stage stage) {
                if (!this.limitsForStages.ContainsKey(stage.ID)) {
                    throw new ArgumentException("Distance not contains this stage");
                }
                return this.limitsForStages[stage.ID];
            }
        }
    }
}
