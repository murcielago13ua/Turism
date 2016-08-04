using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public sealed class TuristoSkillStage : SpecialStage {
            private TuristoSkillStage(String name, Guid ID) : base(name, ID) { }
            public override StageRank Rank {
                get {
                    return StageRank.NK;
                }

                protected set {
                    base.Rank = value;
                }
            }
            public override Double Points {
                get {
                    return 2;
                }

                protected set {
                    base.Points = value;
                }
            }
            public static TuristoSkillStage GetTent(Guid ID) {
                return new TuristoSkillStage("Встановлення намету", ID);
            }
            public static TuristoSkillStage GetTent() {
                return new TuristoSkillStage("Встановлення намету", Guid.NewGuid());
            }
            public static TuristoSkillStage GetBag(Guid ID) {
                return new TuristoSkillStage("Укладка рюкзака", ID);
            }
            public static TuristoSkillStage GetBag() {
                return new TuristoSkillStage("Укладка рюкзака", Guid.NewGuid());
            }
            public static TuristoSkillStage GetFire(Guid ID) {
                return new TuristoSkillStage("Розпалювання багаття", ID);
            }
            public static TuristoSkillStage GetFire() {
                return new TuristoSkillStage("Розпалювання багаття", Guid.NewGuid());
            }
        }
    }
}
