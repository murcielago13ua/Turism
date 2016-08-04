using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace People {
        public enum Qualification : Byte {
            br,
            III_jun,
            II_jun,
            I_jun,
            III,
            II,
            I,
            KMSU,
            MSU,
        };
        public static class QualificationExtention {
            public static String ToUkrString(this Qualification qual) {
                switch (qual) {
                    default:
                        return qual.ToString();
                    case Qualification.br:
                        return "б/р";
                    case Qualification.III_jun:
                        return "ІІІ-юнацький";
                    case Qualification.II_jun:
                        return "ІІ-юнацький";
                    case Qualification.I_jun:
                        return "І-юнацький";
                    case Qualification.KMSU:
                        return "КМСУ";
                    case Qualification.MSU:
                        return "МСУ";
                }
            }
        }
    }
}