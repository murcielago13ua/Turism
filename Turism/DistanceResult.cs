using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;
using Turism.Distances;

namespace Turism {
    namespace Competitions {
        public abstract class DistanceResult : TurismBase {
            protected IList<StageResult> results;
            private Int32 penaltiesOfDistance;
            public Int32 PenaltiesOfDistance {
                get { return this.penaltiesOfDistance; }
                set {
                    if (value < 0) {
                        throw new ArgumentException("Penaltie can't be negative");
                    }
                    this.penaltiesOfDistance = value;
                }
            }
            public TimeSpan RuningTime { get; private set; }
            public StageResult[] StageResults { get { return results.ToArray(); } }
            public Distance Distance { get; protected set; }
            protected DistanceResult(Distance distance, Guid ID, Int32 penaltiesOfDistance, TimeSpan runningTime)
                : base(String.Empty, ID) {                
                this.Distance = distance;
                this.PenaltiesOfDistance = penaltiesOfDistance;
                this.RuningTime = runningTime;
                this.results = new List<StageResult>();
                CreateEmptyResults();
            }
            protected abstract void CreateEmptyResults();
            protected DistanceResult(Distance distance, Guid ID) : 
                this(distance, ID, 0, new TimeSpan()) { }
            protected DistanceResult(Distance distance, Guid ID, Int32 penaltiesOfDistance, TimeSpan runningTime, IEnumerable<StageResult> results) :
                base(String.Empty, ID){
                this.Distance = distance;
                this.penaltiesOfDistance = penaltiesOfDistance;
                this.RuningTime = runningTime;
                this.results = new List<StageResult>(results);
            }
            public StageResult GetResultByStage(Stage stage) {
                return
                    (from stageResult in this.results
                     where stageResult.Stage.Equals(stage)
                     select stageResult).First();
            }
        }
    }
}
