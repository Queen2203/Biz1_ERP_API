using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Cors;

using Microsoft.Extensions.Configuration;
//using Quobject.SocketIoClientDotNet.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;

using System.Net.Mail;
using System.Text;
using System.Net;
using SuperMarketApi.Models;
using Microsoft.AspNetCore.Http;

namespace SuperMarketApi.Controllers
{
    [Route("api/[controller]")]
    public class SaleController : Controller
    {
        private int OrderId;
        private object Order;
        private int CustomerId;
        private int CustomerNo;
        private string CustomerPhone;
        private POSDbContext db;
        private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        public IConfiguration Configuration { get; }
        public SaleController(POSDbContext contextOptions, IConfiguration configuration)
        {
            db = contextOptions;
            Configuration = configuration;
        }
       

        [HttpGet("Testplan")]

        public IActionResult Testplan()
        {
            List<Plan> plans = db.Plans.ToList();

            return Json(plans);
        }

        [HttpGet("GetAccess")]
        public IActionResult GetAccess(int companyid, int storeid, int planid)
        {
            Store store = db.Stores.Find(storeid);
            Accounts company = db.Accounts.Where(a => a.CompanyId == companyid).FirstOrDefault();
            Plan plan = db.Plans.Find(planid);
            Plan oldPlan = db.Plans.Find(store.PlanId);

            string mailbody = String.Format(@"<!DOCTYPE html>
                                <html>
                                <head>
	                                <meta charset='utf-8'>
	                                <meta name='viewport' content='width=device-width, initial-scale=1'>
	                                <title></title>
                                </head>
                                <body>
	                                <p>{0} has requested change of plan from {1} to {2} for store {3} </p>
	                                <strong>Email: </strong> {4} <br>
	                                <strong>Phone No: </strong> {5}, {6} <br>
	                                <strong>Company Id: </strong> {7} <br>
	                                <strong>Store Id: </strong> {8}
                                </body>
                                </html>", company.Name, oldPlan.Name, plan.Name, store.Name, company.Email, company.PhoneNo, store.ContactNo, company.CompanyId, store.Id);
            mailbody += String.Format("{0} has requested change of plan from {1} to {2}\n", company.Name, oldPlan.Name, plan.Name);
            mailbody += String.Format("\nEmail: {0}", company.Email);
            mailbody += String.Format("\nPhone No: {0}, {1}", company.PhoneNo, store.ContactNo);
            //send_alert_email(mailbody);

            var response = new
            {
                status = 200,
                meassage = "You will be contacted soon."
            };

            return Json(response);
        }
        [HttpGet("Testplandetails")]

        public IActionResult Testplandetails()
        {

            List<PlanDetail> Plandetail = db.PlanDetails.Where(x => x.IsActive == true).ToList();

            return Ok(Plandetail);
        }
        //public void send_alert_email(string mailbody)
        //{
        //    string from = "biz1pos.clients@gmail.com"; //From address    
        //    MailMessage message = new MailMessage(from, "biz1pos.bizdom@gmail.com"); //To Address
        //    //message.To.Add("karthick.nath@gmail.com");
        //    //message.To.Add("masterservice2020@gmail.com");
        //    //message.To.Add("mohamedanastsi@gmail.com");
        //    //message.To.Add("sanjai.nath1995@gmail.com");
        //    // string mailbody = storename + " faced an app crash event @" + dateTime.ToString();
        //    message.Subject = "User Plan Access";

        //    message.Body = mailbody;
        //    message.BodyEncoding = Encoding.UTF8;
        //    message.IsBodyHtml = true;
        //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
        //    client.UseDefaultCredentials = false;
        //    NetworkCredential basicCredential1 = new
        //    NetworkCredential(from, "Password@123");

        //    client.EnableSsl = true;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = basicCredential1;
        //    client.Send(message);
        //}


        [HttpPost("SaveOrder_Test")]
        public IActionResult SaveOrder_Test([FromBody] OrderPayload payload) {

            //int? companyid = null;
            //int? storeid = null;
            try

            {
                string message = "Order Test As Been Saved";
                int status = 200;
                dynamic orderjsonformat = JsonConvert.DeserializeObject(payload.OrderJson);
                dynamic DataAllocation = new { };
                //string phoneno = orderjsonformat.CustomerDetails.PhoneNo.ToString();
                //int customerid = -1;
                //if (phoneno != "" && phoneno != null)
                //{
                //    customerid = db.Customers.Where(x => x.PhoneNo == phoneno).Any() ? db.Customers.Where(x => x.PhoneNo == phoneno).FirstOrDefault().Id : 0;
                //}
                using (SqlConnection myconnn = new SqlConnection(Configuration.GetConnectionString("myconn")))
                {
                    myconnn.Open();
                    try
                    {
                        SqlCommand ordersp = new SqlCommand("dbo.SaveOrder", myconnn);
                        ordersp.CommandType = CommandType.StoredProcedure;
                        ordersp.Parameters.Add(new SqlParameter("@orderjson", payload.OrderJson));
                        DataSet ds = new DataSet();
                        SqlDataAdapter sqladapter = new SqlDataAdapter(ordersp);
                        sqladapter.Fill(ds);
                        //DataTable Table = ds.Tables[0];
                        //DataAllocation = Table;
                        myconnn.Close();
                    }
                    catch (Exception e)
                    {
                        myconnn.Close();
                        throw e;
                    }
                }
                var response = new
                {
                    //data = DataAllocation,
                    message = message,
                    status = status
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    Error = new Exception(e.Message, e.InnerException),
                    status = 500,
                    Message = "Opps, Failed"
                };
                return Json(error);
            }
        }

       


        public class OrderPayload
        {
            public string OrderJson { get; set; }
            public List<Transaction> Transactions { get; set; }
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
