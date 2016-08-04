using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class ComboStage : Stage {
            private readonly IList<Stage> stages;
            public Stage[] Stages { get { return stages.ToArray(); } }
            public ComboStage(Guid ID, IEnumerable<Stage> stages) : base("Спарений етап", ID) {
                this.stages = new List<Stage>(stages);
                this.Rank = StageRank.NK;
            }
            public ComboStage(IEnumerable<Stage> stages) : this(Guid.NewGuid(), stages) { }
            public ComboStage(Guid ID) : base("Спарений етап", ID) {
                this.stages = new List<Stage>();
                this.Rank = StageRank.NK;
            }
            public ComboStage() : this(Guid.NewGuid()) { }
            public override Double Points {
                get {
                    return this.stages.Sum(stage => stage.Points);
                }

                protected set {
                    base.Points = value;
                }
            }
            public override String Info {
                get {
                    var builder = new StringBuilder(this.ToString());
                    builder.Append(Environment.NewLine + "{{");
                    foreach (var stage in this.stages) {
                        builder.Append("{")
                            .AppendFormat("{0}{1}{0}", Environment.NewLine, stage.Info)
                            .Append("}" + Environment.NewLine);
                    }
                    return builder.Append("}}").ToString();
                }
            }
            public ComboStage Add(Stage stage) {
                if (stage is ComboStage) {
                    throw new ArgumentException("Can not add combostage to combostage");
                }
                this.stages.Add(stage);
                return this;
            }
        }
    }
}
