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
    
    public partial class BillGuest
    {
        public int id { get; set; }
        public int Bill { get; set; }
        public int Guest { get; set; }
    
        public virtual Bill Bill1 { get; set; }
        public virtual Guest Guest1 { get; set; }
    }
}
