﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace newBlogprj
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class finaldbEntities1 : DbContext
    {
        public finaldbEntities1()
            : base("name=finaldbEntities1")
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
        public virtual DbSet<groupOrderDetaildb> groupOrderDetaildb { get; set; }
        public virtual DbSet<groupProductBinding> groupProductBinding { get; set; }
        public virtual DbSet<GroupType> GroupType { get; set; }
        public virtual DbSet<likeType> likeType { get; set; }
        public virtual DbSet<memberdb> memberdb { get; set; }
        public virtual DbSet<MemberGroupOrder> MemberGroupOrder { get; set; }
        public virtual DbSet<MembersType> MembersType { get; set; }
        public virtual DbSet<memberVoteitem> memberVoteitem { get; set; }
        public virtual DbSet<productdb> productdb { get; set; }
        public virtual DbSet<productPictureBinding> productPictureBinding { get; set; }
        public virtual DbSet<voteitem> voteitem { get; set; }
        public virtual DbSet<voteMember> voteMember { get; set; }
        public virtual DbSet<voteTitle> voteTitle { get; set; }
    }
}
