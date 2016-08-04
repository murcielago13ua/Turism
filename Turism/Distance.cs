using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turism.Stages;

namespace Turism {
    namespace Distances {
        public enum DistanceClass : Byte {
            Null,
            I,
            II,
            III,
            IV,
            V,
        }
        public abstract class Distance : TurismBase {
            public virtual Double Points {
                get { return this.stages.Sum(stage => stage.Points); }
            }
            private readonly IList<Stage> stages;
            public Stage[] Stages {
                get { return this.stages.ToArray(); }
            }
            public DistType Type { get; protected set; }
            public Int32 Length { get; protected set; }
            public Int32 Height { get; protected set; }
            public TimeSpan LimitTime { get; private set; }
            public Distance(String name, Guid ID, DistType type, Int32 length, Int32 height, IEnumerable<Stage> stages, TimeSpan limitTime) : 
                base(name, ID) {
                if (length < 0 || height < 0) {
                    throw new ArgumentException("Invalid length or height of distance");
                }
                this.Type = type;
                this.stages = new List<Stage>(stages);
                this.Length = length;
                this.Height = height;
                this.LimitTime = limitTime;
            }            
            public Distance AddStage(Stage stage) {
                this.stages.Add(stage);
                return this;
            }
            public override String ToString() {
                return this.Type.ToString();
            }
            public virtual String Info {
                get { return this.ToString(); }
            }
            private Boolean CheckClass (IDictionary<StageRank, Int32> stagesInfo, Int32 teamPrep, DistanceClass Class) {
                Int32 _3A = stagesInfo[StageRank._3A], _2B = stagesInfo[StageRank._2B], _2A = stagesInfo[StageRank._2A], 
                    _1B = stagesInfo[StageRank._1B], _1A = stagesInfo[StageRank._1A];
                switch (Class) {
                    case DistanceClass.V:
                        if (_3A + _2B >= 4 && _3A >= 2 && teamPrep >= 5)
                            return true;
                        return false;
                    case DistanceClass.IV:
                        if (_3A + _2B >= 3 && _3A >= 1 && teamPrep >= 4)
                            return true;
                        return false;
                    case DistanceClass.III:
                        if (_3A + _2B + _2A >= 3 && _3A + _2B >= 2 && teamPrep >= 3)
                            return true;
                        return false;
                    case DistanceClass.II:
                        if (_3A + _2B + _2A + _1B >= 3 && _3A + _2B + _2A >= 2 && teamPrep >= 2)
                            return true;
                        return false;
                    default:
                        return true;
                }
            }
            private DistanceClass GetClassByPoints() {
                Double points = this.Points;
                if (points >= 20 && points < 35)
                    return DistanceClass.I;
                else if (points >= 35 && points < 50)
                    return DistanceClass.II;
                else if (points >= 50 && points < 70)
                    return DistanceClass.III;
                else if (points >= 70 && points < 100)
                    return DistanceClass.IV;
                else if (points >= 100)
                    return DistanceClass.V;
                return DistanceClass.Null;
            }
            private Int32 GetStagesWithTeamPreparingCount() {
                var isWithTeamPrep = new Func<Stage, Int32>((Stage stage) => {
                    if (stage is ComboStage) {
                        var sum = 0;
                        foreach(var st in (stage as ComboStage).Stages) {
                            sum += st.PreparingOption == StagePreparingOption.TeamPreparing ? 1 : 0;
                            }
                        return sum;
                    }
                    return stage.PreparingOption == StagePreparingOption.TeamPreparing ? 1 : 0;
                });
                return this.stages.Sum(stage => isWithTeamPrep(stage));
            }
            private Dictionary<StageRank, Int32> GetStagesInfo() {
                var stagesInfo = new Dictionary<StageRank, Int32>() {
                    [StageRank.NK] = 0, [StageRank._1A] = 0,
                    [StageRank._1B] = 0, [StageRank._2A] = 0,
                    [StageRank._2B] = 0, [StageRank._3A] = 0,
                };
                foreach (var stage in this.Stages) {
                    ComboStage comboStage = stage as ComboStage;
                    if (comboStage != null) {
                        foreach (var nestedStage in comboStage.Stages)
                            stagesInfo[nestedStage.Rank] += 1;
                    }
                    else
                        stagesInfo[stage.Rank] += 1;
                }
                return stagesInfo;
            }
            private DistanceClass GetClass() {                
                Int32 teamPrep = GetStagesWithTeamPreparingCount();
                var stagesInfo = GetStagesInfo();
                DistanceClass _class = this.GetClassByPoints();
                while (_class > DistanceClass.Null) {
                    if (CheckClass(stagesInfo, teamPrep, _class)) {
                        break;
                    }
                    _class--;
                }
                return _class;
            }
            public virtual DistanceClass Class { get { return this.GetClass(); } }
            public Boolean IsShort {
                get {
                    return this.Type == DistType.GetObstacleCourse() || this.Type == DistType.GetShortRescue();
                }
            }
        }
    }
}
