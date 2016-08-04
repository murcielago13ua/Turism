using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEnumerator = System.Collections.IEnumerator;
using IEnumerable = System.Collections.IEnumerable;

namespace Turism {
    public sealed class ObjectCollector<T> : IEnumerable<T> where T : Base {
        private static readonly IDictionary<Guid, T> Items = new Dictionary<Guid, T>();
        public static void Put(T obj) {
            Items.Add(obj.ID, obj);
        }
        public static Boolean Remove(T obj) {
            return Items.Remove(obj.ID);
        }
        public static T GetItem(Guid ID) {
            if (!Items.ContainsKey(ID)) {
                throw new ArgumentException("Object with this ID not found");
            }
            return Items[ID];
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return Items.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return Items.Values.GetEnumerator();
        }
    }
}
