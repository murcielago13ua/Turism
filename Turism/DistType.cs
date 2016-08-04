using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Distances {
        public class DistType {
            public Boolean IsShort { get; private set; }
            public String Name { get; private set; }
            private DistType(String name, Boolean isShort) {
                this.Name = name;
                this.IsShort = isShort;
            }
            private static DistType cross;
            private static DistType obstacleCourse;
            private static DistType shortRescue;
            private static DistType longRescue;
            public override String ToString() {
                return String.Format("{0} дист. \"{1}\"",
                    this.IsShort ? "Кор." : "Довга",
                    this.Name);
            }
            static DistType() {
                cross = new DistType("Крос-похід", false);
                obstacleCourse = new DistType("Cмуга перешкод", true);
                shortRescue = new DistType("Рятувальні роботи", false);
                longRescue = new DistType("Рятувальні роботи", true);
            }
            public static DistType GetCross() {
                return cross;
            }
            public static DistType GetObstacleCourse() {
                return obstacleCourse;
            }
            public static DistType GetShortRescue() {
                return shortRescue;
            }
            public static DistType GetLongRescue() {
                return longRescue;
            }
            public static DistType Parse(String value) {
                if (value.Contains("Крос-похід")) {
                    return GetCross();
                }
                if (value.Contains("Cмуга перешкод")) {
                    return GetObstacleCourse();
                }
                if (value.Contains("Рятувальні роботи")) {
                    if (value.StartsWith("Кор.")) {
                        return GetShortRescue();
                    }
                    return GetLongRescue();
                }
                throw new FormatException();
            }
        }
    }
}