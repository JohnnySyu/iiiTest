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
    
    public partial class viteItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public viteItem()
        {
            this.memberVoteitem = new HashSet<memberVoteitem>();
        }
    
        public int itemsID { get; set; }
        public string items { get; set; }
        public Nullable<int> titleID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<memberVoteitem> memberVoteitem { get; set; }
        public virtual voteTitle voteTitle { get; set; }
    }
}
