using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Turism {
    namespace Stages {
        public sealed class Ticker : StageWithLength {
            public Byte Height { get; private set; }
            private Ticker(Guid ID, Byte length, Byte height, FirstWalking firstWalking) :
                base("Подолання перешкоди з використанням підвішеної мотузки (маятником)",
                    ID, length, firstWalking) {
                this.Height = height;
                if (this.FirstWalking == FirstWalking.AsAllTeam) {
                    this.SetPreparingOption(StagePreparingOption.JudjeRopes);
                }
                else {
                    this.SetPreparingOption(StagePreparingOption.TeamPreparing);
                }
            }
            public override StageRank Rank {
                get {
                    return this.PreparingOption == StagePreparingOption.TeamPreparing ?
                        StageRank._1B : StageRank._1A;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public static Ticker GetJudjeTicker(Guid ID, Byte length, Byte heigth) {
                return new Ticker(ID, length, heigth, FirstWalking.AsAllTeam);
            }
            public static Ticker GetJudjeTicker(Byte length, Byte heigth) {
                return new Ticker(Guid.NewGuid(), length, heigth, FirstWalking.AsAllTeam);
            }
            public static Ticker GetTicker(Guid ID, Byte length, Byte heigth, FirstWalking firstWalking) {
                return new Ticker(ID, length, heigth, firstWalking);
            }
            public static Ticker GetTicker(Byte length, Byte heigth, FirstWalking firstWalking) {
                return new Ticker(Guid.NewGuid(), length, heigth, firstWalking);
            }
        }
    }
}
