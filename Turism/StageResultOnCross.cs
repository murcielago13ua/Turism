using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;

namespace Turism {
    namespace Competitions {
        public sealed class StageResultOnCross : StageResult {
            public TimeSpan Time { get; set; }
            public StageResultOnCross(Stage stage, Guid ID, Int32 penalties, TimeSpan time, String comment) :
                base(stage, ID, penalties, comment) {
                this.Time = time;
            }
            public StageResultOnCross(Stage stage, Int32 penalties, TimeSpan time, String comment) : 
                this(stage, Guid.NewGuid(), penalties, time, comment) { }
            public StageResultOnCross(Stage stage, Guid ID, TimeSpan time) : 
                base(stage, ID) {
                this.Time = time;
            }
            public StageResultOnCross(Stage stage, TimeSpan time) : this(stage, Guid.NewGuid(), time) { }
            public override String Info {
                get {
                    return new StringBuilder(String.Format("Резутат на етапі {0}:", stage.FullName))
                        .AppendFormat("\tЧас проходження {0}",this.Time.ToString())
                        .AppendFormat("\tК-сть штрафних балів = {0}", this.Penalties)
                        .AppendFormat("\tКоментар:'''{0}'''", this.Comment)
                        .ToString();
                }
            }
        }
    }
}
