using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public abstract class StageWithLength : Stage {
            public virtual Byte Length { get; protected set; }
            private FirstWalking firstWalking;
            public FirstWalking FirstWalking { get { return this.firstWalking; } }
            public StageWithLength(String name, Guid ID, Byte length, FirstWalking firstWalking) :
                base(name, ID) {
                if (length <= 0) {
                    throw new TypeInitializationException(this.GetType().FullName, null);
                }
                this.Length = length;
                this.firstWalking = firstWalking;
            }
            public override Double Points {
                get {
                    if (this.points != 0)
                        return this.points;
                    var points = base.Points;
                    switch (this.firstWalking) {
                        case FirstWalking.SelfInsuranceOrImitation:
                            points += 1;
                            break;
                        case FirstWalking.TeamInsurance:
                            points += 2;
                            break;
                        default:
                            break;
                    }
                    switch (this.PreparingOption) {
                        case StagePreparingOption.NoPreparing:
                            points *= 0.3;
                            break;
                        case StagePreparingOption.JudjeRopes:
                            points *= 0.5;
                            break;
                        case StagePreparingOption.JudjeInsuranseOrAccompany:
                            points *= 0.8;
                            break;
                        default:
                            break;
                    }
                    if (this.HasVictim)
                        points *= 1.2;
                    if (this.HardConditions)
                        points *= 1.2;
                    this.points = points;
                    return this.points;
                }

                protected set {
                    base.Points = value;
                }
            }
            public override String ToString() {
                return String.Format("{0}, довжина ~{1} м",
                    base.ToString(),
                    this.Length);
            }
            public override String Info {
                get {
                    return String.Format("{1}{0}\tрух першого учасника : {2}",
                        Environment.NewLine,
                        base.Info,
                        this.FirstWalking.ToUkrString()
                        );
                }
            }
        }
    }
}
