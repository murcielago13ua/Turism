using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;

namespace Turism {
    namespace Competitions {
        public sealed class StageResultOnObstacleCourse : StageResult {
            public StageResultOnObstacleCourse(Stage stage, Guid ID, Int32 penalties, String comment) :
                base(stage, ID, penalties, comment) { }
            public StageResultOnObstacleCourse(Stage stage, Guid ID) : base(stage, ID) { }
            public StageResultOnObstacleCourse(Stage stage, Int32 penalties, String comment) : 
                this(stage, Guid.NewGuid(), penalties, comment) { }
            public StageResultOnObstacleCourse(Stage stage) : this(stage, Guid.NewGuid()) { }
        }
    }
}
