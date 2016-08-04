using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public class StageBuildingLogicalException : Exception {
            public StageBuildingLogicalException(Type stageType) :
                base(String.Format("Logical exception while building a stage '{0}'",
                    stageType.FullName)) { }
        }
    }
}
