using bit285_lucky_number_database.Models;
using lucky_number_database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bit285_lucky_number_database.Controllers
{
    public class LuckyNumberController : Controller
    {
        private LuckyNumberDbContext dbc = new LuckyNumberDbContext();
        // GET: LuckyNumber
        public ActionResult Spin()
        {
            LuckyNumber myLuck = new LuckyNumber { Number = 7, Balance = 4 };
            dbc.LuckyNumbers.Add(myLuck);
            dbc.SaveChanges(); //touch the database
            return View(myLuck);
        }

        [HttpPost]
        public ActionResult Spin(LuckyNumber lucky)
        {
            LuckyNumber databaseLuck = dbc.LuckyNumbers.Where(m=>m.LuckyNumberID ==1).First();
            //change the balance in the database
                if(databaseLuck.Balance>0)
            {
                databaseLuck.Balance -= 1;
            }
            //update the number in the database useing the form submission value
            databaseLuck.Number = lucky.Number;
            dbc.SaveChanges();
            return View(databaseLuck);
        }
    }
}