using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;

namespace Turism {
    namespace Distances {
        public class Cross : Distance , ICross{
            private readonly IDictionary<Guid, StageTimeLimitsForCross> limitsForStages;
            public TimeSpan OptimalTime { get; private set; }
            public Cross(String name, Guid ID, Int32 length, Int32 height, IDictionary<Stage, StageTimeLimitsForCross> stagesAndLimits, 
                TimeSpan limitTime, TimeSpan optimalTime) :
                base(name, ID, DistType.GetCross(), length, height, stagesAndLimits.Keys, limitTime) {
                this.limitsForStages = new Dictionary<Guid, StageTimeLimitsForCross>();
                foreach(var pair in stagesAndLimits) {
                    this.limitsForStages.Add(pair.Key.ID, pair.Value);
                }
                this.OptimalTime = optimalTime;
            }
            public Cross(String name, Int32 length, Int32 height, IDictionary<Stage, StageTimeLimitsForCross> stagesAndLimits, TimeSpan limitTime) : 
                this(name, Guid.NewGuid(), length, height, stagesAndLimits, limitTime) { }
            public Cross(String name, Guid ID, Int32 length, Int32 height, IDictionary<Stage, StageTimeLimitsForCross> stagesAndLimits, 
                TimeSpan limitTime) : this(name, ID, length, height, stagesAndLimits, limitTime, limitTime) { }
            public Cross(String name, Int32 length, Int32 height, IDictionary<Stage, StageTimeLimitsForCross> stagesAndLimits,
                TimeSpan limitTime, TimeSpan optimalTime) : 
                this(name, Guid.NewGuid(), length, height, stagesAndLimits, limitTime, optimalTime) { }
            public StageTimeLimitsForCross GetLimitForStage(Stage stage) {
                if (!this.limitsForStages.ContainsKey(stage.ID)) {
                    throw new ArgumentException("Distance not contains this stage");
                }
                return this.limitsForStages[stage.ID];
            }
        }
    }
}