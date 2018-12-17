using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Task 1
            ViewBag.q1Basic1 = LoanCalculator.GetMonthlyRepayment(0.9 * 500000, 4.65, 30);
            ViewBag.q1Advance1 = LoanCalculator.GetNumberOfYears(0.9 * 500000, 4.65, 2000);
            ViewBag.q1Advance2 = LoanCalculator.CheckYearsAndGetLoanAmount(0.9 * 500000, 4.65, 2000, 35, 30);

            return View();
        }
    }
}