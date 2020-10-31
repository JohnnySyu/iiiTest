using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace forumAPItest.Controllers
{
    public class loginController : ApiController
    {
        // GET: api/login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/login
        [HttpPost]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage Post([FromBody] JObject value)
        {

            try
            {
                string account = value["account"].ToString();
                string password = value["password"].ToString();

                string accountbase64Decoded;
                byte[] accountdata = Convert.FromBase64String(account);
                accountbase64Decoded = Encoding.UTF8.GetString(accountdata);

                string passwordbase64Decoded;
                byte[] passworddata = Convert.FromBase64String(account);
                passwordbase64Decoded = Encoding.UTF8.GetString(passworddata);

               
                    var result = new
                    {
                        STATUS = true,
                        MSG = "成功",
                    };                  
              
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
           
                     

        

        // PUT: api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/login/5
        public void Delete(int id)
        {
        }
    }
}
