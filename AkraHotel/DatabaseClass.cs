using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AkraHotel
{
    public class DatabaseClass
    {
        #region SafeSingleton
        private static readonly Lazy<DatabaseClass> LazyInstance = new Lazy<DatabaseClass>(() => new DatabaseClass(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static DatabaseClass Instance => LazyInstance.Value;
        #endregion
        public Employee CurrentUser { get; set; }
        public AkraHotelEntities _context { get; set; } = new AkraHotelEntities();
        public void ReloadContext() { _context = new AkraHotelEntities(); }
    }
}
