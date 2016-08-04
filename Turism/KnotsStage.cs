using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class KnotsStage : SpecialStage {
            private readonly List<Knot> knots;
            public Knot[] Knots { get { return knots.ToArray(); } }
            public KnotsStage(Guid ID, IEnumerable<Knot> knots) : base("В'язання вузлів", ID) {
                if (knots.Count() == 0) {
                    throw new TypeInitializationException(typeof(KnotsStage).FullName, null);
                }
                this.knots = new List<Knot>(knots);
            }
            public override StageRank Rank {
                get {
                    return StageRank.NK;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public override Double Points {
                get {
                    return 2;
                }

                protected set {
                    base.Points = value;
                }
            }
            public override String Info {
                get {
                    StringBuilder builder = new StringBuilder(knots[0].ToString());
                    if (knots.Count == 20) {
                        builder.Clear().Append("всі вузли з настанов");
                    }
                    else {
                        for (Int32 i = 1; i < knots.Count; i++) {
                            builder.AppendFormat(",{0}", knots[i].ToString());
                        }
                    }
                    return String.Format("{1}{0}\tСписок вузлів: {2}",
                        Environment.NewLine,
                        this.ToString(),
                        builder.ToString());
                }
            }
        }
    }
}
