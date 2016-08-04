using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;

namespace Turism {
    namespace Distances {
        public abstract class Rescue : Distance {
            protected Rescue(String name, Guid ID, DistType distType, Int32 length, Int32 height, IEnumerable<Stage> stages, 
                TimeSpan limitTime) :
                base(name, ID, distType, length, height, stages, limitTime) {
                if (distType != DistType.GetLongRescue() && distType != DistType.GetShortRescue()) {
                    throw new TypeInitializationException(typeof(Rescue).FullName, null);
                }
                CheckRescue();
            }
            private Dictionary<DistanceClass, Int32> GetDemandsForRescue() {
                var demandsForRescue = new Dictionary<DistanceClass, Int32>() {
                    [DistanceClass.III] = 2,
                    [DistanceClass.IV] = 3,
                    [DistanceClass.V] = 4,
                };
                return demandsForRescue;
            }
            private void CheckRescue() {
                Int32 stagesWithVictim = this.Stages.Sum(stage => stage.HasVictim ? 1 : 0);
                var _class = this.Class;
                if (_class < DistanceClass.III) {
                    throw new RescueBuildingException(this.Type == DistType.GetShortRescue(), 
                        "Рятувальні роботи повинні мати клас не нижче ІІІ-го");
                }
                var demandsForRescue = GetDemandsForRescue();
                if (demandsForRescue[_class] > stagesWithVictim) {
                    throw new RescueBuildingException(this.Type == DistType.GetShortRescue(),
                        String.Format("Для проведення рятувальних робіт даного класу необхідно додати ще {0} етап(ів) з потерпілим.", 
                        (demandsForRescue[_class] - stagesWithVictim)));
                }
            }
        }
    }
}
