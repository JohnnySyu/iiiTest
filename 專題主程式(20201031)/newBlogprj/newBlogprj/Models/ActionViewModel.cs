using newBlogprj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Action.Models
{
    public class ActionViewModel
    {
        //Event
        public int Event_ID { get; set; }
        public Nullable<System.DateTime> EventStartDate { get; set; }
        public Nullable<System.DateTime> EventEndDate { get; set; }
        public string EventLocation { get; set; }
        public string EventName { get; set; }
        public string EventContent { get; set; }
        public string EventRemark { get; set; }
        public Nullable<int> EventMaxPeople { get; set; }
        public Nullable<int> EventMinPeople { get; set; }
        public string EventLocationX { get; set; }
        public string EventLocationY { get; set; }
        public Nullable<int> EventNowJoin { get; set; }
        public Nullable<int> EventCreateEmployeeID { get; set; }

        //EventBooking
        //public int EventBooking_ID { get; set; }
        //public int Event_ID { get; set; }
        public int mb_ID { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public string EmployeeJoinStatus { get; set; }

        public virtual Event Event { get; set; }

        //EventComment
        //public int EventID { get; set; }
        //public int EventCommentID { get; set; }
        //public int Event_ID { get; set; }
        //public int mb_ID { get; set; }
        public Nullable<int> CommentStatus { get; set; }

        //public virtual Event Event { get; set; }

    }
}