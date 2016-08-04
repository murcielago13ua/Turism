using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Distances {
        public class DistanceBuildingException : Exception {
            public String HowToFix { get; private set; }
            public DistanceBuildingException(DistType distType, String howToFix) :
                base(String.Format("Помилка при створенні дистанції {0}!", distType.ToString())) {
                this.HowToFix = howToFix;
            }
            public DistanceBuildingException(DistType distType) : this(distType, String.Empty) { }
        }
    }
}
