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
    
    public partial class Complain
    {
        public int id { get; set; }
        public string Text { get; set; }
        public Nullable<int> Guest { get; set; }
        public Nullable<int> Employee { get; set; }
    
        public virtual Employee Employee1 { get; set; }
        public virtual Guest Guest1 { get; set; }
    }
}
