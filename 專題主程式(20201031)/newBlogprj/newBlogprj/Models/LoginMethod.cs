using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newBlogprj.Models
{
    public class LoginMethod
    {
        public bool AcPswCheck(string ac, string psw)
        {
            bool accheck = false;
            bool pswcheck = false;
            finaldbEntities db = new finaldbEntities();
            var q = from f in db.memberdb
                    select f;
            foreach (var item in q)
            {
                if (item.mb_employeeAccount == ac)
                {
                    accheck = true;
                    if (item.mb_employeePassword == psw)
                    {
                        pswcheck = true;
                        break;
                    }
                }
            }
            if (accheck && pswcheck)
            {
                return true;
            }
            return false;
        }
        public bool AcCheck(string ac)
        {
            finaldbEntities db = new finaldbEntities();
            bool check = true; ;
            var q = from f in db.memberdb
                    select f;
            foreach(var item in q)
            {
                if(item.mb_employeeAccount == ac)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }

        public bool Register(Mmemberdb mbdb)
        {
            finaldbEntities db = new finaldbEntities();
            memberdb mb = new memberdb();

            mb.mb_employeeAccount = mbdb.mb_empAc;
            mb.mb_employeePassword = mbdb.mb_empPsw;
            mb.mb_employeeName = mbdb.mb_empName;
            mb.mb_employeeGender = mbdb.mb_empGender;
            mb.mb_employeeAddress = mbdb.mb_empAddress;
            mb.mb_employeeDeptID = mbdb.mb_empDeptID;
            mb.mb_employeePhone = mbdb.mb_empPhone;
            mb.mb_employeeEmail = mbdb.mb_empEmail;
            mb.mb_employeeHobby = mbdb.mb_empHobby;
            mb.mb_employeeBirthday = mbdb.mb_empBirthday;
            mb.mb_employeeLiveCity = mbdb.mb_empLiveCity;
            mb.mb_employeeState = mbdb.mb_empState;
            // mb.mb_employeeHireDate = mbdb.mb_empHireDate;
            DateTime dt = new DateTime();
            dt = dt.AddYears(Convert.ToInt32(mbdb.mb_empHireDate.Substring(0, 4)) - 1);
            dt = dt.AddMonths(Convert.ToInt32(mbdb.mb_empHireDate.Substring(5, 2)) - 1);
            dt = dt.AddDays(Convert.ToInt32(mbdb.mb_empHireDate.Substring(8, 2)) - 1);
            mb.mb_employeeHireDate = dt;
            mb.mb_employeeTransport = mbdb.empTransport;
            mb.mb_employeePicture = mbdb.mb_empPicture;



            db.memberdb.Add(mb);
            db.SaveChanges();
            return false;
        }

        public int getmid(string ac)
        {
            finaldbEntities db = new finaldbEntities();
            var q = from f in db.memberdb
                    where f.mb_employeeAccount == ac
                    select f;
            int mid = 0;
            foreach(var item in q)
            {
                mid = item.mb_ID;
            }
            return mid;
        }
        public string getusername(string ac)
        {
            finaldbEntities db = new finaldbEntities();
            var q = from f in db.memberdb
                    where f.mb_employeeAccount == ac
                    select f;
            string username = "";
            foreach(var item in q)
            {
              username = item.mb_employeeName  ;
            }
            return username;
        }
    }
}