using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Distances;
using Turism.Stages;

namespace Turism {
    namespace Competitions {
        public class LongDistanceResult : DistanceResult {
            protected override void CreateEmptyResults() {
                foreach (var stage in this.Distance.Stages) {
                    this.results.Add(new StageResultOnCross(stage, new TimeSpan()));
                }
            }
            public LongDistanceResult(Cross cross, Guid ID, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                base(cross, ID, penaltiesOfDistance, runningTime) { }
            public LongDistanceResult(Cross cross, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                base(cross, Guid.NewGuid(), penaltiesOfDistance, runningTime) { }
            public LongDistanceResult(Cross cross, Guid ID, Int32 penaltiesOfDistance, TimeSpan runningTime, IEnumerable<StageResultOnCross> results) :
                base(cross, ID, penaltiesOfDistance, runningTime, results) { }
            public LongDistanceResult(LongRescue longRescue, Guid ID, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                base(longRescue, ID, penaltiesOfDistance, runningTime) { }
            public LongDistanceResult(LongRescue longRescue, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                base(longRescue, Guid.NewGuid(), penaltiesOfDistance, runningTime) { }
            public LongDistanceResult(LongRescue longRescue, Guid ID, Int32 penaltiesOfDistance, TimeSpan runningTime, IEnumerable<StageResultOnCross> results) :
                base(longRescue, ID, penaltiesOfDistance, runningTime, results) { }
            public void SetResultForStage(Stage stage, TimeSpan runningTime, Int32 penalties, String comment) {
                var stageResult = base.GetResultByStage(stage) as StageResultOnCross;
                stageResult.Time = runningTime;
                stageResult.Penalties = penalties;
                stageResult.Comment = comment;
            }
        }
    }
}
