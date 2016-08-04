using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Distances;
using Turism.Stages;

namespace Turism {
    namespace Competitions {
        public class ShortDistanceResult : DistanceResult {
            protected override void CreateEmptyResults() {
                foreach (var stage in this.Distance.Stages) {
                    this.results.Add(new StageResultOnObstacleCourse(stage));
                }
            }
            private ShortDistanceResult(Distance distance, Guid ID, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                base(distance, ID, penaltiesOfDistance, runningTime) {
            }
            private ShortDistanceResult(Distance distance, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                this(distance, Guid.NewGuid(), penaltiesOfDistance, runningTime) { }
            public ShortDistanceResult(ObstacleCource obstacleCource, Guid ID, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                this(obstacleCource as Distance, ID, penaltiesOfDistance, runningTime) { }
            public ShortDistanceResult(ObstacleCource obstacleCource, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                this(obstacleCource as Distance, penaltiesOfDistance, runningTime) { }
            public ShortDistanceResult(ShortRescue shortRescue, Guid ID, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                this(shortRescue as Distance, ID, penaltiesOfDistance, runningTime) { }
            public ShortDistanceResult(ShortRescue shortRescue, Int32 penaltiesOfDistance, TimeSpan runningTime) :
                this(shortRescue as Distance, penaltiesOfDistance, runningTime) { }
            public void SetResultForStage(Stage stage, Int32 penalties, String comment) {
                var stageResult = base.GetResultByStage(stage) as StageResultOnObstacleCourse;
                stageResult.Penalties = penalties;
                stageResult.Comment = comment;
            }
            public TimeSpan GetFullTime(Int32 penaltyPrice) {
                return this.RuningTime +
                    TimeSpan.FromSeconds(penaltyPrice *
                        (this.StageResults.Sum(stageResult => stageResult.Penalties) + this.PenaltiesOfDistance));
            }
        }
    }
}
