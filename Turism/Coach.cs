using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace People {
        public class Coach : Person {
            private Coach(String name, String surname, String secondName, DateTime birthday, Guid ID) :
                base(name, surname, secondName, birthday, ID) { }
            public static Coach FromPerson(Person person) {
                return new Coach(person.Name, person.Surname, person.SecondName, person.Birthday, person.ID);
            }
        }
    }
}
