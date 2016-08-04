using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class TraverseWithAlpenstock : StageWithLength, ITraverse {
            public enum TraverseDifficult : Byte {
                Simple,
                Normal,
                Hard,
            }
            public TraverseDifficult Diff { get; private set; }
            private List<TraverseNode> nodes;
            public TraverseNode[] Nodes {
                get {
                    return nodes.ToArray();
                }
            }
            private TraverseWithAlpenstock(Guid ID, TraverseDifficult diff, IEnumerable<TraverseNode> nodes) :
                base("Траверс схилу з альпенштоком", ID, 1, FirstWalking.AsAllTeam) {
                if (!nodes.All(node => node.length > 0) || nodes.Count() == 0) {
                    throw new TypeInitializationException(this.GetType().FullName, null);
                }
                this.nodes = new List<TraverseNode>(nodes);
                this.Length = Convert.ToByte(this.nodes.Sum(node => node.length));
                this.Diff = diff;
            }
            public override StageRank Rank {
                get {
                    if (this.Diff == TraverseDifficult.Simple)
                        return StageRank._1A;
                    else if (this.Diff == TraverseDifficult.Normal)
                        return StageRank._1B;
                    return StageRank._2A;
                }

                protected set {
                    base.Rank = value;
                }
            }
        }
    }
}
