using Action.Models;
using newBlogprj.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace newBlogprj.Controllers
{
    public class cBlogController : Controller
    {
      public static  string acc = "";
        public static bool logincheck = false;
        public ActionResult Start()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Start(MemberACandPSW macpsw)
        {
            macpsw.mac = Request.Form["txtac"];
            macpsw.mpsw = Request.Form["txtpsw"];
            acc = Request.Form["txtac"];
            


            LoginMethod lm = new LoginMethod();

            bool isacpswok = lm.AcPswCheck(macpsw.mac, macpsw.mpsw);
            
            if (isacpswok)
            {
                ViewBag.Title = "find";
               ViewBag.LoginName ="歡迎 "+lm.getusername(acc);
                logincheck = true;
            }
            else
            {
                ViewBag.Title = "fail";
                ViewBag.LoginName = "";
                 logincheck = false;
               // logincheck = true;
            }
            return View();
        }

        public ActionResult MemberRegister()
        {
            //Mmemberdb mbdb = new Mmemberdb();
            //LoginMethod lm = new LoginMethod();
            //mbdb.mb_empAc = "test1";
            //mbdb.mb_empPsw = "123";
            //lm.Register(mbdb);
            return View();
        }
        [HttpPost]
        public ActionResult MemberRegister(Mmemberdb mbdb)
        {
            mbdb.mb_empAc = Request.Form["txtac"];
            bool accheck = lm2.AcCheck(mbdb.mb_empAc);
            if (accheck == false)
            {
                ViewBag.rmsg = "此帳號已經註冊過";
                return View();
            }
            mbdb.mb_empPsw = Request.Form["txtpsw"];
            mbdb.mb_empName = Request.Form["txtname"];
            mbdb.mb_empGender = Request.Form["txtgender"];
            mbdb.mb_empAddress = Request.Form["txtaddress"];
            mbdb.mb_empDeptID = Convert.ToInt32(Request.Form["txtdept"]);
            mbdb.mb_empPhone = Request.Form["txtphone"];
            mbdb.mb_empEmail = Request.Form["txtemail"];
            mbdb.mb_empHobby = Request.Form["txthobby"];
            mbdb.mb_empLiveCity = Request.Form["txtlivecity"];
            mbdb.mb_empHireDate = Request.Form["txthireday"];
            mbdb.mb_empState = 1;
            if (mbdb.mb_empHireDate == "")
            {
                mbdb.mb_empHireDate = DateTime.Now.ToString();
            }
            if (mbdb.mb_empDeptID == 0)
            {
                mbdb.mb_empDeptID = 4;
            }
            mbdb.mb_empBirthday = Request.Form["txtbirthday"];
            mbdb.empTransport = Request.Form["txttransport"];

            mbdb.mb_empPicture = "../Content/" + Request.Form["txtpic"];

            //  ViewBag.img =".."+mbdb.mb_empPicture;


            LoginMethod lm = new LoginMethod();
            lm.Register(mbdb);
            return RedirectToAction("Start");
        }
        public ActionResult memberregister2()
        {
            return View();
        }

        public ActionResult MemberDataEdit(int id)
        {
            finaldbEntities db = new finaldbEntities();
            Mmemberdb mdb = new Mmemberdb();
            var q = from f in db.memberdb
                    where f.mb_ID == id
                    select f;
            foreach(var item in q)
            {
                mdb.mb_empName = item.mb_employeeName;
                mdb.mb_empAc = item.mb_employeeAccount;
                mdb.mb_empPsw = item.mb_employeePassword;
                mdb.mb_empDeptID =Convert.ToInt32( item.mb_employeeDeptID);
                mdb.mb_empPhone = item.mb_employeePhone;
                mdb.mb_empEmail = item.mb_employeeEmail;
                mdb.mb_empAddress = item.mb_employeeAddress;
                mdb.mb_empGender = item.mb_employeeGender;
                mdb.mb_empHobby = item.mb_employeeHobby;
                mdb.mb_empPicture = item.mb_employeePicture;
                mdb.mb_empBirthday = item.mb_employeeBirthday;
                mdb.mb_empLiveCity = item.mb_employeeLiveCity;
                 mdb.mb_empHireDate = item.mb_employeeHireDate.ToString();
               // DateTime dt = new DateTime();
               // dt =dt.AddYears(item.mb_employeeHireDate.Value.Year);
               //dt= dt.AddMonths(item.mb_employeeHireDate.Value.Month);
               // dt=dt.AddDays(item.mb_employeeHireDate.Value.Day);
               // mdb.mb_empHireDate = dt;
                mdb.empTransport = item.mb_employeeTransport;
                mdb.mb_empState = Convert.ToInt32( item.mb_employeeState);
                
            }
            return View(mdb);
        }
        [HttpPost]
        public ActionResult MemberDataEdit(Mmemberdb mbd)
        {
            return RedirectToAction("Start");
        }
        public ActionResult SendEmail(string id)
        {
            string tid = id;
            string ttid = "";
            string se = "";
            finaldbEntities db = new finaldbEntities();
            var q = from f in db.memberdb
                    select f;
            foreach(var item in q)
            {
                se = item.mb_employeePassword;
            }
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "hungyeelin@gmail.com",
                    Password = "0976204711"
                }
            };
            MailAddress FromEmail = new MailAddress("hungyeelin@gmail.com", "HY LIN");
            //    MailAddress ToEmail = new MailAddress("hongyeelin5@gmail.com", "HY LIN2");
            MailAddress ToEmail = new MailAddress(id, "HY LIN2");
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "This is your password number",
                Body = se
                //  IsBodyHtml = true
            };
            Message.To.Add(ToEmail);

            Client.Send(Message);

            return RedirectToAction("Start");
        }
        public ActionResult LogOut()
        {
            logincheck = false;
            return RedirectToAction("Start");         
        }
        // GET: cBlog
        //----------------------------------------------------------
        // int h = 12;
        int h = 58;
        LoginMethod lm2 = new LoginMethod();
        
        
        public ActionResult BlogList(string searchString)
        {
            if(logincheck == false)
            {
                return RedirectToAction("Start");
            }
            finaldbEntities db = new finaldbEntities();
          //  LoginMethod lm8 = new LoginMethod();
            int hh = lm2.getmid(acc);
            ViewBag.LoginName ="歡迎 "+ lm2.getusername(acc);
            var table = from bloginner in db.blogBinding
                        where bloginner.Memberdb_ID ==hh                
                        orderby bloginner.Blog_ID descending  
                       
                        select new
                        {
                            //memberName = bloginner.memberdb.mb_employeeName,
                            blogContent = bloginner.blog.BlogContent,
                            blogTitle = bloginner.blog.blogTitle,
                            blogID = bloginner.Blog_ID,  
                            blogdate=bloginner.blog.Blogdate,
                        };
            if (!String.IsNullOrEmpty(searchString)){
                table = table.Where(s => s.blogTitle.Contains(searchString));
            }

            h =lm2.getmid(acc);
            var table2 = from blogemp in db.memberdb
                         where blogemp.mb_ID==h
                         select blogemp;

            List<mBlogViewmodels> blogList = new List<mBlogViewmodels>();
            
            foreach (var items in table)
            {
                mBlogViewmodels blogView = new mBlogViewmodels();
                //blogView.blog_member = items.memberName;
                blogView.blog_title = items.blogTitle;
                blogView.blog_content = items.blogContent;
                blogView.blog_ID = (int)items.blogID;
                blogView.blog_date = items.blogdate;
                blogList.Add(blogView);
            }

            foreach (var item in table2)
            {
                mBlogViewmodels blogView = new mBlogViewmodels();
                blogView.Memberdb = item;
                blogList.Add(blogView);
            }
            ViewBag.enumber3 = hh;
            return View(blogList);

        }

        public ActionResult Create()
        {
           
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(blog p,blogBinding q)
        {
            try
            {
                finaldbEntities db = new finaldbEntities();
                p.Blogdate = DateTime.Now.ToString("g");
                db.blog.Add(p);
                db.SaveChanges();
                int blogID = p.Blog_ID;

                q.Blog_ID = blogID;
                q.Memberdb_ID = lm2.getmid(acc);
                db.blogBinding.Add(q);
                db.SaveChanges();
                
            }
            catch(Exception ex)
            {
                throw;
            }
            return RedirectToAction("BlogList");

        }

        public ActionResult Delete(int id)
        {
            finaldbEntities db = new finaldbEntities();
            blog deleteblog = db.blog.FirstOrDefault(p => p.Blog_ID == id);
            blogBinding deleteblogBinding = db.blogBinding.FirstOrDefault(p => p.Blog_ID == id);
            if (deleteblog != null)
            {
                db.blog.Remove(deleteblog);
                db.SaveChanges();
                db.blogBinding.Remove(deleteblogBinding);
                db.SaveChanges();
            }
            return RedirectToAction("BlogList");
        }

        public ActionResult Edit(int id)
        {
            blog blog = (new finaldbEntities()).blog.FirstOrDefault(p => p.Blog_ID == id);
            if (blog == null)
                return RedirectToAction("BlogList");
            return View(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(blog blog)
        {
            finaldbEntities db = new finaldbEntities();
            blog editblog = db.blog.FirstOrDefault(p => p.Blog_ID == blog.Blog_ID);
            if (blog != null)
            {
                editblog.Blogdate= DateTime.Now.ToString("g");
                editblog.blogTitle = blog.blogTitle;
                editblog.BlogContent = blog.BlogContent;              
                db.SaveChanges();
            }
            return RedirectToAction("BlogList");
        }

        //--------------------------------------------------------------------活動區
        finaldbEntities db = new finaldbEntities();
        public ActionResult Action()
        {
            if (logincheck == false)
            {
                return RedirectToAction("Start");
            }
            ViewBag.enumber4 = lm2.getmid(acc);
            ViewBag.LoginName = lm2.getusername(acc);
            // finaldbEntities db = new finaldbEntities();
            var table = from p in db.Event
                        select new ActionViewModel { Event_ID = p.Event_ID, EventName = p.EventName, EventLocation = p.EventLocation, EventStartDate = p.EventStartDate, EventEndDate = p.EventEndDate };
            return View(table);
        }
        public ActionResult ActionList()
        {         
            var table = from p in db.Event
                        select new ActionViewModel { Event_ID = p.Event_ID, EventName = p.EventName, EventLocation = p.EventLocation, EventStartDate = p.EventStartDate, EventEndDate = p.EventEndDate };
            return View(table);
        }
        public ActionResult aCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult aCreate(Event p)
        {
            db.Event.Add(p);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("ActionList");
        }
        public ActionResult Copy(int id)
        {
            Event product = db.Event.FirstOrDefault(p => p.Event_ID == id);
            if (product != null)
            {
                product.EventName += "(複製)";
                db.Event.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("ActionList");
        }
        public ActionResult aEdit(int id)
        {
            ActionViewModel product = (from p in db.Event
                                       where p.Event_ID == id
                                       select new ActionViewModel
                                       {
                                           Event_ID = p.Event_ID,
                                           EventName = p.EventName,
                                           EventLocation = p.EventLocation,
                                           EventStartDate = p.EventStartDate,
                                           EventEndDate = p.EventEndDate
                                       }).FirstOrDefault();
            if (product == null)
            {
                return RedirectToAction("ActionList");
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult aEdit(ActionViewModel prod)
        {
            Event product = db.Event.FirstOrDefault(p => p.Event_ID == prod.Event_ID);
            if (product != null)
            {
                product.EventName = prod.EventName;
                product.EventLocation = prod.EventLocation;
                product.EventStartDate = prod.EventStartDate;
                product.EventEndDate = prod.EventEndDate;
                db.SaveChanges();
            }
            return RedirectToAction("ActionList");
        }
        public ActionResult Index()
        {
            return RedirectToAction("ActionList");
        }
        public ActionResult aDelete(int id)
        {
            Event product = db.Event.FirstOrDefault(p => p.Event_ID == id);
            if (product != null)
            {
                db.Event.Remove(product);
                db.SaveChanges();
            }

            return RedirectToAction("ActionList");
        }
        public ActionResult EventReading(int id)
        {
            ActionViewModel product = (from p in db.Event
                                       where p.Event_ID == id
                                       select new ActionViewModel
                                       {
                                           Event_ID = p.Event_ID,
                                           EventName = p.EventName,
                                           EventLocation = p.EventLocation,
                                           EventStartDate = p.EventStartDate,
                                           EventEndDate = p.EventEndDate
                                       }).FirstOrDefault();
            if (product == null)
            {
                return RedirectToAction("ActionList");
            }
            return View(product);
        }
        //public ActionResult BookingListView()
        //{
        //    //List<ActionViewModel> list = Session[CDictionary.SK_Event_Booking_into_list] as List<ActionViewModel>;
        //    //if (list==null)
        //    //    return RedirectToAction("Action");
        //    return View(/*list*/);
        //}
        //public ActionResult AddtoSession(ActionViewModel booking)
        //{
        //    Event product = db.Event.FirstOrDefault(p => p.Event_ID == booking.Event_ID);
        //    if (product != null)
        //    {
        //        product.EventName = booking.EventName;
        //        product.EventLocation = booking.EventLocation;
        //        product.EventStartDate = booking.EventStartDate;
        //        product.EventEndDate = booking.EventEndDate;
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("ActionList");
        //}
        //-----------------------------------------------------------------------------------forum
        public ActionResult ForumList()
        {
            if (logincheck == false)
            {
                return RedirectToAction("Start");
            }
            ViewBag.enumber = lm2.getmid(acc);
            ViewBag.LoginName = lm2.getusername(acc);
            return View();
        }
        public string updateForum(string gt,string gc)
        {
            return 
                           
                            "<span>[標題]</span><input type = \"text\" value = "+gt+" class=\"form-control\" id=\"recipient-name\">"+


                            "<span>推文</span><input type = \"text\" value = " + gc + " class=\"form-control\" id=\"recipient-name\">" 
                        ;
        }
        //---------------------------揪團go-----------------------------
        //final_pEntities dbp = new final_pEntities();
        public int opengroupd_productnumber = 100;
        public ActionResult PurchaseList()
        {
            
            if (logincheck == false)
            {
                return RedirectToAction("Start");
            }
            ViewBag.enumber2 = lm2.getmid(acc);
            ViewBag.LoginName = lm2.getusername(acc);

            final_pEntities dbp = new final_pEntities();
            vm_purchaselist vmp = new vm_purchaselist();

            var q1 = from f in dbp.Group_Product_Binding
                     where f.pGroupdb.Group_ID == f.Groupid &&
                     f.Productid == f.pProductdb.Product_ID &&
                     f.pGroupdb.Group_ID == 1
                     select f.pProductdb.PictureURL;
            string[] pic = new string[3];
            int p1 = 0;
            foreach(var item in q1)
            {
                pic[p1] = item;
                p1++;
            }


            var q2 = from f in dbp.pGroupdb
                     where f.Group_ID ==1
                     select f;
            int targetn1 = 0;
            int targetn2 = 0;
            
            foreach(var item in q2)
            {
                targetn1 =Convert.ToInt32( item.Group_TartgetNumber1);
                targetn2 = Convert.ToInt32(item.Group_TartgetNumber2);
            }
            //--------------------------------目前抓到目標人數的數值

            return View();
        }
        public ActionResult Purchase_Open()
        {
            ViewBag.enumber5 = lm2.getmid(acc);
            return View();
        }
        string p1name = "";
        string p2name = "";
        [HttpPost]
        public ActionResult Purchase_Open(vmp_openlist vmpol)
        {
            vmpol.group_title = Request.Form["txtptitle"];
            vmpol.group_startdate = DateTime.Now.ToString("yyyyMMdd");
            vmpol.group_enddate = Request.Form["txtpenddate"];

            vmpol.targetnumber1 = Convert.ToInt32(Request.Form["txttargetnumber1"]);
            vmpol.targetnumber2 = Convert.ToInt32(Request.Form["txttargetnumber2"]);

            vmpol.group_type = Convert.ToInt32(Request.Form["group_type"]);
            vmpol.group_description = Request.Form["group_description"];
            // vmpol.owndermemberid = Convert.ToInt32(Request.Form["opnepeopleid"]);
            vmpol.owndermemberid = lm2.getmid(acc);
           
            

            pGroupdb gdb = new pGroupdb();
            gdb.Group_Title = vmpol.group_title;
            gdb.Group_StartDate = vmpol.group_startdate;
            gdb.Group_EndDate = vmpol.group_enddate;

            gdb.Group_TartgetNumber1 = vmpol.targetnumber1;
            gdb.Group_TartgetNumber2 = vmpol.targetnumber2;

            gdb.Group_type = vmpol.group_type;
            gdb.Group_description = vmpol.group_description;
            gdb.OwnerMember_ID = vmpol.owndermemberid;
            final_pEntities dbp = new final_pEntities(); 
            dbp.pGroupdb.Add(gdb);
            dbp.SaveChanges();

             p1name = Request.Form["ponename"];
            int p1n = Convert.ToInt32( Request.Form["ponenum"]);
            int p1price = Convert.ToInt32(Request.Form["poneprice"]);
            vmpol.pic1url = Request.Form["txtpic1"];

             p2name = Request.Form["ptwoname"];
            int p2n = Convert.ToInt32(Request.Form["ptwonum"]);
            int p2price = Convert.ToInt32(Request.Form["ptwoprice"]);
            vmpol.pic2url = Request.Form["txtpic2"];

            pProductdb pproduct = new pProductdb();
            pproduct.Product_name = p1name;
            pproduct.Product_restnumber = p1n;
            pproduct.Product_Price = p1price;
            pproduct.PictureURL = vmpol.pic1url;
            dbp.pProductdb.Add(pproduct);
            dbp.SaveChanges();

            pproduct.Product_name = p2name;
            pproduct.Product_restnumber = p2n;
            pproduct.Product_Price = p2price;
            pproduct.PictureURL = vmpol.pic2url;
            dbp.pProductdb.Add(pproduct);
            dbp.SaveChanges();
            int b1_gid = 0;
            var q1 = from f in dbp.pGroupdb
                     where f.Group_Title == vmpol.group_title
                     select f.Group_ID;
            foreach(var item in q1)
            {
                b1_gid = item;
            }
            int b1_pid1 = 0;
            var q2 = from f2 in dbp.pProductdb
                     where f2.Product_name == p1name
                     select f2.Product_ID;
            foreach(var item in q2)
            {
                b1_pid1 = item;
            }
            int b1_pid2 = 0;
            var q3 = from f3 in dbp.pProductdb
                     where f3.Product_name == p2name
                     select f3.Product_ID;
            foreach (var item in q3)
            {
                b1_pid2 = item;
            }
            Group_Product_Binding pgpb = new Group_Product_Binding();
            pgpb.Groupid = b1_gid;
            pgpb.Productid = b1_pid1;
            dbp.Group_Product_Binding.Add(pgpb);
            dbp.SaveChanges();
            pgpb.Groupid = b1_gid;
            pgpb.Productid = b1_pid2;
            dbp.Group_Product_Binding.Add(pgpb);
            dbp.SaveChanges();

            
           

            

            return RedirectToAction("Purchase_OpenList");
        }
        public ActionResult Purchase_OpenList()
        {
            final_pEntities dbp = new final_pEntities();
            ViewBag.enumber6 = lm2.getmid(acc);
            int mid = lm2.getmid(acc);

            int p1 = 0;
            int p2 = 0;

            var q = from f in dbp.pGroupdb
                    where f.OwnerMember_ID ==mid 
                    select f;

            var q2 = from f2 in dbp.Group_Product_Binding
                     where f2.pGroupdb.OwnerMember_ID == mid && f2.pGroupdb.Group_ID == f2.Groupid && f2.Productid == f2.pProductdb.Product_ID
                     select f2.pProductdb;
            string []pid = new string[opengroupd_productnumber];
            
            string[] prn = new string[opengroupd_productnumber];
            int pp = 0;
            foreach(var item in q2)
            {
                pid[pp] = item.Product_ID.ToString();
                prn[pp] = item.Product_restnumber.ToString();
                pp++;
            }
            List < vm_openlistview > lpg = new List<vm_openlistview>();

            pp = 0;
            foreach (var item in q)
            {
                 vm_openlistview pg = new vm_openlistview();
                pg.title = item.Group_Title;
                pg.startdate= item.Group_StartDate;
                pg.enddate= item.Group_EndDate;
                pg.product1targetnumber = item.Group_TartgetNumber1.ToString();
                pg.product2targetnumber = item.Group_TartgetNumber2.ToString();
                pg.group_type = item.Group_type.ToString();
                pg.group_description = item.Group_description;
                pg.ownerid = item.OwnerMember_ID.ToString();
                //pp = 0;
                pg.product1ID = pid[pp];
                
                pg.p1currentnumber = 0;
                pp++;
                pg.product2ID = pid[pp];
                pp++;
               
                pg.p2currentnumber = 0;
                lpg.Add(pg);
            }
            return View(lpg);
        }
        public ActionResult Purchase_FollowList()
        {
            ViewBag.enumber7 = lm2.getmid(acc);
            return View();
        }
    }
    }