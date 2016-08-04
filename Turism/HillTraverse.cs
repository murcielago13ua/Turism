using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class HillTraverse : HillMovement, ITraverse {
            private List<TraverseNode> nodes;
            public TraverseNode[] Nodes {
                get {
                    return nodes.ToArray();
                }
            }
            private HillTraverse(Guid ID, Boolean hardHill, IEnumerable<TraverseNode> nodes, FirstWalking firstWalking) :
                base("Траверс схилу", ID, 1, hardHill, firstWalking) {
                if (!nodes.All(node => node.length > 0) || nodes.Count() == 0) {
                    throw new TypeInitializationException(this.GetType().FullName, null);
                }
                this.nodes = new List<TraverseNode>(nodes);
                this.Length = Convert.ToByte(this.nodes.Sum(node => node.length));
            }
            public static HillTraverse GetSimpleHillTraverse(Guid ID, IEnumerable<TraverseNode> nodes, FirstWalking firstWalking) {
                return new HillTraverse(ID, false, nodes, firstWalking);
            }
            public static HillTraverse GetSimpleHillTraverse(IEnumerable<TraverseNode> nodes, FirstWalking firstWalking) {
                return new HillTraverse(Guid.NewGuid(), false, nodes, firstWalking);
            }
            public static HillTraverse GetHardHillTraverse(Guid ID, IEnumerable<TraverseNode> nodes, FirstWalking firstWalking) {
                return new HillTraverse(ID, true, nodes, firstWalking);
            }
            public static HillTraverse GetHardHillTraverse(IEnumerable<TraverseNode> nodes, FirstWalking firstWalking) {
                return new HillTraverse(Guid.NewGuid(), true, nodes, firstWalking);
            }
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
