using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;

namespace Turism {
    namespace Competitions {
        public abstract class StageResult : TurismBase {
            protected Stage stage;
            public Stage Stage { get { return this.stage; } }
            private Int32 penalties;
            public Int32 Penalties {
                get { return this.penalties; }
                set {
                    if (value < 0) {
                        throw new ArgumentException("Penaltie can't be negative");
                    }
                    this.penalties = value;
                }
            }
            protected String comment;
            public String Comment {
                get { return comment; }
                set {
                    if (value == null) {
                        throw new ArgumentException("Comment == null");
                    }
                    this.comment = value;
                }
            }
            protected StageResult(Stage stage, Guid ID, Int32 penalties, String comment) : base("", ID) {
                this.stage = stage;
                this.penalties = penalties;
                this.comment = comment;
            }
            protected StageResult(Stage stage, Guid ID) : this(stage, ID, 0, String.Empty) { }
            public virtual String Info {
                get {
                    return new StringBuilder(String.Format("Резутат на етапі {0}:", stage.FullName))
                        .AppendFormat("\tК-сть штрафних балів = {0}", this.Penalties)
                        .AppendFormat("\tКоментар:'''{0}'''", this.Comment)
                        .ToString();
                }
            }
        }
    }
}
