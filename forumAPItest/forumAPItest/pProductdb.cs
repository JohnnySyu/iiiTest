//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace forumAPItest
{
    using System;
    using System.Collections.Generic;
    
    public partial class pProductdb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pProductdb()
        {
            this.Group_Product_Binding = new HashSet<Group_Product_Binding>();
        }
    
        public int Product_ID { get; set; }
        public string Product_name { get; set; }
        public Nullable<int> Product_Price { get; set; }
        public Nullable<int> Product_currentnum { get; set; }
        public Nullable<int> Product_restnumber { get; set; }
        public string Product_description { get; set; }
        public string PictureURL { get; set; }
        public string Picturebyte { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group_Product_Binding> Group_Product_Binding { get; set; }
    }
}
