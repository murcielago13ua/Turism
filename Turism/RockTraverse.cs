using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class RockTraverse : RockMovement, ITraverse {
            private readonly List<TraverseNode> nodes;
            public TraverseNode[] Nodes {
                get {
                    return this.nodes.ToArray();
                }
            }
            public RockTraverse(Guid ID, RockDifficult diff, IEnumerable<TraverseNode> nodes, FirstWalking firstWalking) :
                base("Траверс скельної ділянки", ID, 1, diff, firstWalking) {
                if (!nodes.All(node => node.length > 0) || nodes.Count() == 0) {
                    throw new TypeInitializationException(this.GetType().FullName, null);
                }
                this.nodes = new List<TraverseNode>(nodes);
                this.Length = Convert.ToByte(this.nodes.Sum(node => node.length));
            }

            public RockTraverse(RockDifficult diff, IEnumerable<TraverseNode> nodes, FirstWalking firstWalking):
                this(Guid.NewGuid(), diff, nodes, firstWalking) { }

            private String Scheme {
                get {
                    StringBuilder builder = new StringBuilder(nodes[0].ToString());
                    for (Int32 i = 1; i < nodes.Count; i++) {
                        builder.AppendFormat("-{0}", nodes[i].ToString());
                    }
                    return builder.ToString();
                }
            }
            public override String Info {
                get {
                    return String.Format("{1}{0}\t{2}",
                        Environment.NewLine,
                        base.Info,
                        this.Scheme);
                }
            }
        }
    }
}