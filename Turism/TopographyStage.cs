using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class TopographyStage : SpecialStage {
            private readonly List<String> questions;
            public String[] Questions { get { return this.questions.ToArray(); } }
            public TopographyStage(Guid ID, IEnumerable<String> questions) : base("Залік з топографії та геодезії", ID) {
                this.questions = new List<string>(questions);
            }
            public TopographyStage(IEnumerable<String> questions) : this(Guid.NewGuid(), questions) { }
            public override StageRank Rank {
                get {
                    return StageRank._1A;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public override String Info {
                get {
                    var builder = new StringBuilder();
                    for (var i = 0; i < questions.Count; i++) {
                        builder.AppendFormat("{0}: {1}{2}", (i + 1), questions[i], Environment.NewLine);
                    }
                    return String.Format("{1}{0}\t{2}",
                        Environment.NewLine,
                        base.Info,
                        builder.ToString());
                }
            }
        }
    }
}
