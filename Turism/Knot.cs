using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace Stages {
        public class Knot {
            private static readonly String[] knotNames = {
            "Прямий", "Ткацький",
            "Грепвайн", "Зустрічний",
            "Зустрічний вісімка", "Брамшкотовий",
            "Академічний", "Провідник вісімка",
            "Серединний провідник", "Подвійний провідник",
            "Провідник одним кінцем", "Булінь",
            "Стремено", "Удавка",
            "Штик", "Схоплюючий прусіка",
            "Австрійський схоплюючий", "Схоплюючий Бахмана",
            "УІАА", "Гарда",
        };
            public String Name { get; private set; }
            private Knot(String name) {
                this.Name = name;
            }
            public override String ToString() {
                return Name;
            }
            public static Knot GetKnot(Int32 index) {
                if (index < 0 || index >= 20) {
                    throw new TypeInitializationException(typeof(Knot).FullName, null);
                }
                return new Knot(knotNames[index]);
            }
            public static Knot GetKnot(String knotName) {
                if (!knotNames.Contains(knotName)) {
                    throw new TypeInitializationException(typeof(Knot).FullName, null);
                }
                return new Knot(knotName);
            }
            public static Knot[] GetAllKnots() {
                var list = new List<Knot>();
                for (Int32 i = 0; i < 20; i++) {
                    list.Add(new Knot(knotNames[i]));
                }
                return list.ToArray();
            }
        }
    }
}