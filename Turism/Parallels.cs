using System;
using System.Collections.Generic;
namespace Turism {
    namespace Stages {
        public sealed class Parallels : Crossing {
            public Parallels(Guid ID, Byte length, FirstWalking firstWalking) :
                base("Переправа по вірьовці з перилами", ID, length, firstWalking) { }
            public Parallels(Byte length, FirstWalking firstWalking) :
                this(Guid.NewGuid(), length, firstWalking) { }
            public override StageRank Rank {
                get {
                    if (this.PreparingOption == StagePreparingOption.NoPreparing ||
                        this.PreparingOption == StagePreparingOption.JudjeRopes) {
                        if (this.Length <= 25)
                            return StageRank._1A;
                        else if (this.Length > 25)
                            return StageRank._1B;
                    }
                    else {
                        if (this.Length > 35 && this.Length <= 50)
                            return StageRank._3A;
                        else if (this.Length <= 25)
                            return StageRank._2A;
                        else if (this.Length > 25 && this.Length <= 35)
                            return StageRank._2B;
                    }
                    return StageRank.NK;
                }

                protected set {
                    base.Rank = value;
                }
            }
        }
    }
}