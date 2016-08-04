using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public enum StageRank : Byte {
            NK,
            _1A,
            _1B,
            _2A,
            _2B,
            _3A,
        };
        public static class StageRankExtention {
            public static String ToUkrString(this StageRank rank) {
                String result = "н/к";
                switch (rank) {
                    case StageRank._1A:
                        result = "1А";
                        break;
                    case StageRank._1B:
                        result = "1Б";
                        break;
                    case StageRank._2A:
                        result = "2А";
                        break;
                    case StageRank._2B:
                        result = "2Б";
                        break;
                    case StageRank._3A:
                        result = "3А";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }
        public static class StageRankParser {
            public static StageRank Parse(String value) {
                switch (value) {
                    case "1А":
                        return StageRank._1A;
                    case "1Б":
                        return StageRank._1B;
                    case "2А":
                        return StageRank._2A;
                    case "2Б":
                        return StageRank._2B;
                    case "3А":
                        return StageRank._3A;
                    default:
                        return StageRank.NK;
                }
            }
        }
    }
}