﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class finaldbEntities2 : DbContext
    {
        public finaldbEntities2()
            : base("name=finaldbEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<blog> blog { get; set; }
        public virtual DbSet<blogBinding> blogBinding { get; set; }
        public virtual DbSet<departmentdb> departmentdb { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventBooking> EventBooking { get; set; }
        public virtual DbSet<EventComment> EventComment { get; set; }
        public virtual DbSet<forumBinding> forumBinding { get; set; }
        public virtual DbSet<forumContent> forumContent { get; set; }
        public virtual DbSet<forumLikebinding> forumLikebinding { get; set; }
        public virtual DbSet<forumMemberBinding> forumMemberBinding { get; set; }
        public virtual DbSet<forummessage> forummessage { get; set; }
        public virtual DbSet<forumMessageBinding> forumMessageBinding { get; set; }
        public virtual DbSet<forumPicture> forumPicture { get; set; }
        public virtual DbSet<forumType> forumType { get; set; }
        public virtual DbSet<Groupdb> Groupdb { get; set; }
        public virtual DbSet<groupOrderdb> groupOrderdb { get; set; }
        public virtual DbSet<groupProductBinding> groupProductBinding { get; set; }
        public virtual DbSet<GroupType> GroupType { get; set; }
        public virtual DbSet<likeType> likeType { get; set; }
        public virtual DbSet<memberdb> memberdb { get; set; }
        public virtual DbSet<memberGroupBinding> memberGroupBinding { get; set; }
        public virtual DbSet<MemberGroupOrderBinding> MemberGroupOrderBinding { get; set; }
        public virtual DbSet<MembersType> MembersType { get; set; }
        public virtual DbSet<productdb> productdb { get; set; }
        public virtual DbSet<productPictureBinding> productPictureBinding { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
