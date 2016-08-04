using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turism {
    namespace People {
        public class Sportsman : Person {
            public Qualification Qualification { get; private set; }
            public Sportsman(String name, String surname, String secondName, DateTime birthday, Qualification qualification, Guid ID) :
                base(name, surname, secondName, birthday, ID) {
                this.Qualification = qualification;
            }
            public Sportsman(String name, String surname, String secondName, DateTime birthday, Qualification qualification) :
                this(name, surname, secondName, birthday, qualification, Guid.NewGuid()) { }
            public Byte Age {
                get { return Convert.ToByte(DateTime.Now.Year - this.Birthday.Year); }
            }
            public void Raise() {
                if (this.Qualification != Qualification.MSU) {
                    this.Qualification++;
                }
            }
        }
    }
}
