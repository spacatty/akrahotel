//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AkraHotel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            this.Rooms1 = new HashSet<Room>();
        }
    
        public int id { get; set; }
        public Nullable<int> Stars { get; set; }
        public Nullable<int> Rooms { get; set; }
        public string AvailableServices { get; set; }
        public string Catering { get; set; }
        public string Entertainments { get; set; }
        public string RoomsOnFloors { get; set; }
        public Nullable<int> Floors { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms1 { get; set; }
    }
}