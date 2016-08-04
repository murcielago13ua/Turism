using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class Orienteering : SpecialStage {
            public String SpecialInfo { get; private set; }
            public Orienteering(Guid ID, String info) : base("Орієнтування", ID) { this.SpecialInfo = info; }
            public Orienteering(String info) : this(Guid.NewGuid(), info) { }
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
                    return String.Format("{1}{0}\t{2}",
                        Environment.NewLine,
                        base.Info,
                        this.SpecialInfo);
                }
            }
        }
    }
}
