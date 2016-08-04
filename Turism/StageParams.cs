using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public enum FirstWalking {
            AsAllTeam,
            WithoutInsuraneOrWithJudjeRope,
            SelfInsuranceOrImitation,
            TeamInsurance,
        }
        public enum StagePreparingOption {
            TeamPreparing,
            JudjeInsuranseOrAccompany,
            JudjeRopes,
            NoPreparing,
        }
        public static class StageParamsExtention {
            public static String ToUkrString(this FirstWalking firstWalkig) {
                switch (firstWalkig) {
                    default:
                        return String.Empty;
                    case FirstWalking.SelfInsuranceOrImitation:
                        return "самостраховка або імітація перешкоди";
                    case FirstWalking.TeamInsurance:
                        return "командна страховка";
                    case FirstWalking.WithoutInsuraneOrWithJudjeRope:
                        return "без страховки або по суддівській мотузці";
                }
            }
            public static String ToUkrString(this StagePreparingOption prepOp) {
                switch (prepOp) {
                    case StagePreparingOption.JudjeRopes:
                        return "етап долається по наведених суддівських перилах";
                    case StagePreparingOption.JudjeInsuranseOrAccompany:
                        return "етап долається із суддівською страховкою або супроводом";
                    case StagePreparingOption.NoPreparing:
                        return "етап долається без наведення";
                    default:
                        return "етап долається із самонаведенням";
                }
            }
        }
    }
}
