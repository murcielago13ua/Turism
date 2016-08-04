using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class FirstHelpStage : SpecialStage {
            public Boolean Theory { get; private set; }
            public FirstHelpStage(Guid ID, Boolean theory) : base("Надання долікарняної допомоги", ID) {
                this.Theory = theory;
            }
            public FirstHelpStage(Boolean theory) : this(Guid.NewGuid(), theory) { }
            public override StageRank Rank {
                get {
                    return this.Theory ? StageRank.NK : StageRank._1A;
                }

                protected set {
                    base.Rank = value;
                }
            }
        }
    }
}
