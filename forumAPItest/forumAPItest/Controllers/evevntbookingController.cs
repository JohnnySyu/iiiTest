<<<<<<< HEAD
﻿using forumAPItest.Models;
using Newtonsoft.Json;
=======
<<<<<<< HEAD
﻿using forumAPItest.Models;
using Newtonsoft.Json;
=======
﻿using Newtonsoft.Json;
>>>>>>> origin/master
>>>>>>> f638f8d148a978d95fcd36982884afc20158f499
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace forumAPItest.Controllers
{
    public class evevntbookingController : ApiController
    {
<<<<<<< HEAD
       
            // GET: api/evevntbooking
            finaldbEntities1 db = new finaldbEntities1();
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET: api/evevntbooking/5
            [JwtAuthActionFilte]
            public JObject Get(int id)
            {
                var result = new
                {
                    ebtable = from m in db.EventBooking
                              where m.Event_ID == id
                              select new
                              {
                                  eventid = m.Event_ID,
                                  bookingdate = m.BookingDate,
                                  bookingpeopleid = m.mb_ID,
                                  employeestatus = m.EmployeeJoinStatus,
                              }
                };
                string strJson = JsonConvert.SerializeObject(result, Formatting.Indented);
                JObject o = JObject.Parse(strJson);
                return o;
            }

            // POST: api/evevntbooking
            [HttpPost]
            [EnableCors("*", "*", "*")]
            public HttpResponseMessage Post([FromBody] JObject value)
            {
                EventBooking editeventbooking = new EventBooking();
                var neweventid = value["neweventid"].ToString();
                var newmemberid = value["newmemberid"].ToString();
                var newbookingdate = value["newbookingdate"].ToString();
                var newemployeestatus = value["newemployeestatus"].ToString();
                if (editeventbooking != null)
                {
                    editeventbooking.Event_ID = Convert.ToInt32(neweventid);
                    editeventbooking.mb_ID = Convert.ToInt32(newmemberid);
                    editeventbooking.BookingDate = DateTime.Parse(newbookingdate);
                    editeventbooking.EmployeeJoinStatus = newemployeestatus;
                    db.EventBooking.Add(editeventbooking);
                    db.SaveChanges();
                }
                var result = new
                {
                    STATUS = true,
                    MSG = "成功",
                };

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }

            // PUT: api/evevntbooking/5
            [HttpPut]
            [EnableCors("*", "*", "*")]
            public HttpResponseMessage Put(int id, [FromBody] JObject value)
            {
                var editeventbooking = db.EventBooking.FirstOrDefault(p => p.mb_ID == id);
                var bookingdate = value["bookingdate"].ToString();
                var employeestatus = value["employeestatus"].ToString();
                if (editeventbooking != null)
                {
                    editeventbooking.BookingDate = DateTime.Parse(bookingdate);
                    editeventbooking.EmployeeJoinStatus = employeestatus;
                    db.SaveChanges();
                }
                var result = new
                {
                    STATUS = true,
                    MSG = "成功",
                };

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }

            // DELETE: api/evevntbooking/5
            [HttpDelete]
            [EnableCors("*", "*", "*")]
            public HttpResponseMessage Delete(int id)
            {
                EventBooking eventBooking = db.EventBooking.FirstOrDefault(p => p.mb_ID == id);


                if (eventBooking != null)
                {
                    db.EventBooking.Remove(eventBooking);
                    db.SaveChanges();
                }
                var result = new
                {
                    STATUS = true,
                    MSG = "刪除成功",
                };

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        

=======
<<<<<<< HEAD
        // GET: api/evevntbooking
        finaldbEntities1 db = new finaldbEntities1();
     
=======
        finaldbEntities1 db = new finaldbEntities1();
>>>>>>> origin/master
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/evevntbooking/5
<<<<<<< HEAD
        [JwtAuthActionFilte]
=======
>>>>>>> origin/master
        public JObject Get(int id)
        {
            var result = new
            {
                ebtable = from m in db.EventBooking
                          where m.Event_ID == id
                          select new
                          {
                              eventid = m.Event_ID,
                              bookingdate = m.BookingDate,
                              bookingpeopleid = m.mb_ID,
                              employeestatus = m.EmployeeJoinStatus,
                          }
            };
            string strJson = JsonConvert.SerializeObject(result, Formatting.Indented);
            JObject o = JObject.Parse(strJson);
            return o;
        }

        // POST: api/evevntbooking
        [HttpPost]
        [EnableCors("*", "*", "*")]
<<<<<<< HEAD
        public HttpResponseMessage Post([FromBody] JObject value)
=======
        public HttpResponseMessage Post([FromBody]JObject value)
>>>>>>> origin/master
        {
            EventBooking editeventbooking = new EventBooking();
            var neweventid = value["neweventid"].ToString();
            var newmemberid = value["newmemberid"].ToString();
            var newbookingdate = value["newbookingdate"].ToString();
            var newemployeestatus = value["newemployeestatus"].ToString();
            if (editeventbooking != null)
            {
                editeventbooking.Event_ID = Convert.ToInt32(neweventid);
                editeventbooking.mb_ID = Convert.ToInt32(newmemberid);
                editeventbooking.BookingDate = DateTime.Parse(newbookingdate);
                editeventbooking.EmployeeJoinStatus = newemployeestatus;
                db.EventBooking.Add(editeventbooking);
                db.SaveChanges();
            }
            var result = new
            {
                STATUS = true,
                MSG = "成功",
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/evevntbooking/5
        [HttpPut]
        [EnableCors("*", "*", "*")]
<<<<<<< HEAD
        public HttpResponseMessage Put(int id, [FromBody] JObject value)
=======
        public HttpResponseMessage Put(int id, [FromBody]JObject value)
>>>>>>> origin/master
        {
            var editeventbooking = db.EventBooking.FirstOrDefault(p => p.mb_ID == id);
            var bookingdate = value["bookingdate"].ToString();
            var employeestatus = value["employeestatus"].ToString();
            if (editeventbooking != null)
            {
                editeventbooking.BookingDate = DateTime.Parse(bookingdate);
                editeventbooking.EmployeeJoinStatus = employeestatus;
                db.SaveChanges();
            }
            var result = new
            {
                STATUS = true,
                MSG = "成功",
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // DELETE: api/evevntbooking/5
        [HttpDelete]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage Delete(int id)
        {
            EventBooking eventBooking = db.EventBooking.FirstOrDefault(p => p.mb_ID == id);


            if (eventBooking != null)
            {
                db.EventBooking.Remove(eventBooking);
                db.SaveChanges();
            }
            var result = new
            {
                STATUS = true,
                MSG = "刪除成功",
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
<<<<<<< HEAD
=======

>>>>>>> origin/master
        }
>>>>>>> f638f8d148a978d95fcd36982884afc20158f499
    }
}
