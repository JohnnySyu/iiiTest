using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace forumAPItest.Controllers
{
    public class VoteController : ApiController
    {
        // GET: api/Vote
        voteEntities db = new voteEntities();
        public JObject Get()
        {

            var result = new
            {
                ftitle = from p in db.voteTitle
                         where p.memberID == p.voteMember.memberID
                         select new
                         {
                             titleID = p.titleID,
                             title = p.title,
                             name = p.voteMember.memberName,
                             startTime = p.startTime,
                             endTime = p.endTime,

                             fitems = new
                             {
                                 items = from q in db.memberVoteitem
                                         where q.viteItem.titleID == p.titleID
                                         group q by q.itemsID into g
                                         select new
                                         {
                                             items = g.Key,                                            
                                             count = g.Count(),
                                        }
                            }
                        }

            };




            string strJson = JsonConvert.SerializeObject(result, Formatting.Indented);
            JObject o = JObject.Parse(strJson);



            return o;
        }

        // GET: api/Vote/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Vote
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vote/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vote/5
        public void Delete(int id)
        {
        }
    }
}
