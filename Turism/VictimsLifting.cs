using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public partial class VictimTransporting {
            private sealed class VictimsLifting : VictimTransporting {
                private readonly Boolean withBurton;
                public VictimsLifting(Guid ID, Byte length, Boolean withBurton, FirstWalking firstWalking) :
                    base("", ID, length, firstWalking) {
                    this.withBurton = withBurton;
                    if (this.withBurton) {
                        this.Name = "Підйом потерпілого із супроводжуючим з використанням поліспасту";
                    }
                    else {
                        this.Name = "Підйом потерпілого із супроводжуючим";
                    }
                }
                public override StageRank Rank {
                    get {
                        if (this.withBurton)
                            return StageRank._3A;
                        return StageRank._2B;
                    }

                    protected set {
                        base.Rank = value;
                    }
                }
                public override Double Points {
                    get {
                        Double points = this.withBurton ? 12 : 10;
                        if (this.FirstWalking == FirstWalking.TeamInsurance)
                            points += 2;
                        else if (this.FirstWalking == FirstWalking.SelfInsuranceOrImitation)
                            this.points += 1;
                        if (this.HardConditions)
                            points *= 1.2;
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
                        return points;
                    }

                    protected set {
                        base.Points = value;
                    }
                }
            }
            public static VictimTransporting GetVictimLiftingWithBurton(Guid ID, Byte length, FirstWalking firstWalking) {
                return new VictimsLifting(ID, length, true, firstWalking);
            }
            public static VictimTransporting GetVictimLiftingWithBurton(Byte length, FirstWalking firstWalking) {
                return new VictimsLifting(Guid.NewGuid(), length, true, firstWalking);
            }
            public static VictimTransporting GetVictimLifting(Guid ID, Byte length, FirstWalking firstWalking) {
                return new VictimsLifting(ID, length, false, firstWalking);
            }
            public static VictimTransporting GetVictimLifting(Byte length, FirstWalking firstWalking) {
                return new VictimsLifting(Guid.NewGuid(), length, false, firstWalking);
            }
        }
    }
}
