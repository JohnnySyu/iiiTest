﻿using Newtonsoft.Json;
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
    public class blogbackController : ApiController
    {
        // GET: api/blogback
        finaldbEntities1 db = new finaldbEntities1();
        public JObject Get()
        {

            var ftable = from n in db.blogBinding
                         orderby n.blog.Blog_ID descending
                         select new
                         {
                             id = n.Blog_ID,
                             title = n.blog.BlogTitle,
                             Content = n.blog.BlogContent,
                             time = n.blog.Blogdate
                         };


            var result = new
            {
                ftable
            };

            string strJson = JsonConvert.SerializeObject(result, Formatting.Indented);
            JObject o = JObject.Parse(strJson);
            return o;

        }

        public JObject Get(string titletxt, string contenttxt)
        {


            var ftable = from n in db.blogBinding
                         orderby n.blog.Blog_ID descending
                         where n.blog.BlogTitle.Contains(titletxt) || n.blog.BlogContent.Contains(contenttxt)
                         select new
                         {
                             id = n.Blog_ID,
                             title = n.blog.BlogTitle,
                             Content = n.blog.BlogContent,
                             time = n.blog.Blogdate
                         };
            //if (!String.IsNullOrEmpty(titletxt))
            //{
            //    ftable = ftable.Where(s => s.title.Contains(titletxt));
            //}

            var result = new
            {
                ftable
            };

            string strJson = JsonConvert.SerializeObject(result, Formatting.Indented);
            JObject o = JObject.Parse(strJson);
            return o;

        }

        // POST: api/blogback
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/blogback/5
        [HttpPut]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage Put(int id, [FromBody] JObject value)
        {

            string controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            var Putblog = db.blog.FirstOrDefault(p => p.Blog_ID == id);
            var title = value["title"].ToString();
            var content = value["content"].ToString();
            var time = DateTime.Now.ToString("G");

            Putblog.BlogTitle = title;
            Putblog.BlogContent = content;
            Putblog.Blogdate = time;
            db.SaveChanges();
            var result = new
            {
                STATUS = true,
                MSG = "成功",
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);




        }

        // DELETE: api/blogback/5
        public HttpResponseMessage Delete(int id)
        {
            blog deleteblog = db.blog.FirstOrDefault(p => p.Blog_ID == id);
            blogBinding deleteblogBinding = db.blogBinding.FirstOrDefault(p => p.Blog_ID == id);
            if (deleteblog != null)
            {
                db.blog.Remove(deleteblog);
                db.SaveChanges();
                db.blogBinding.Remove(deleteblogBinding);
                db.SaveChanges();
            }
            var result = new
            {
                STATUS = true,
                MSG = "刪除成功",
            };

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}