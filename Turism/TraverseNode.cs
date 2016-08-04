using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public enum MovingDirection {
            Up,
            Down,
            Horizontal,
        }
        public static class MovingDirectionExtention {
            public static String ToUkrString(this MovingDirection md) {
                if (md == MovingDirection.Up)
                    return "догори";
                if (md == MovingDirection.Down)
                    return "вниз";
                return "горизонтально";
            }
        }
        public struct TraverseNode {
            public MovingDirection direction;
            public Byte length;
            public override String ToString() {
                return String.Format("<{0}, {1} м>", this.direction.ToUkrString(), this.length);
            }
        }
    }
}
