using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLite.Model
{
    public class SQLiteHashSet<T> : HashSet<T>
    {
        public event EventHandler OnAdd;

        public new void Add(T item)
        {
            if (null != OnAdd)
            {
                OnAdd(this, null);
            }
            base.Add(item);
        }
    }
}
