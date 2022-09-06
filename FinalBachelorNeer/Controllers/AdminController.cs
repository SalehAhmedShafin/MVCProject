using FinalBachelorNeer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalBachelorNeer.Controllers
{
    public class AdminController : Controller
    {
        bachelorNeerEntities2 db = new bachelorNeerEntities2();
        // GET: Admin

        public ActionResult ApproveSuccess()
        {
          
           return View();
        }

        
        public ActionResult AdminDashboard()
        {
            List<PropertyDetail> books = db.PropertyDetails.ToList();

            var sql = "select * from PropertyDetails";


            //var sql2 = "SELECT COUNT(u_ID) as count FROM  userinfo";
            //var books3 = db.userinfoes.SqlQuery(sql2);
            //string query = "SELECT COUNT(u_ID) as count FROM  userinfo";

            List<userinfo> data = new List<userinfo>();


            List<PropertyDetail> books2 = db.PropertyDetails.SqlQuery(sql).ToList();
            return View(books);
        }


        [HttpPost]
        public ActionResult AdminDashboard(String up_ID)
        {
            try
            {
                int id = Convert.ToInt32(up_ID);

                PropertyDetail user = db.PropertyDetails.Where(temp => temp.up_ID == id).FirstOrDefault();

                var sql = "select * from PropertyDetails where up_ID=" + up_ID;
                List<PropertyDetail> foradd = db.PropertyDetails.SqlQuery(sql).ToList();
                var sql2 = "insert into Approvedproperties (ap_Name,ap_Email,ap_Number,ap_Type,ap_Proaddress,ap_Thana,ap_Imfile)values('" + foradd[0].up_Name + "', '" + foradd[0].up_Email + "', '" + foradd[0].up_Number + "', '" + foradd[0].up_Type + "', '" + foradd[0].up_Proaddress + "', '" + foradd[0].up_Thana + "', '" + foradd[0].up_Imfile + "') ";
                db.Approvedproperties.SqlQuery(sql2);
                //System.Diagnostics.Debug.WriteLine(sql2);


                db.PropertyDetails.Remove(user);
                db.SaveChanges();
                //ViewBag.users = db.PropertyDetails.ToList();
                return RedirectToAction("ApproveSuccess", "Admin");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "ErrorMessage");
            }
            
        }
    }
}