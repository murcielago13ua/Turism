using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace People {
        public abstract class Person : TurismBase {
            public String Surname { get; private set; }
            public String SecondName { get; private set; }
            public DateTime Birthday { get; private set; }
            public Person(String name, String surname, String secondName, DateTime birthday, Guid ID) :
                base(name, ID) {
                this.Surname = surname;
                this.SecondName = secondName;
                this.Birthday = birthday;
            }
        }
    }
}
