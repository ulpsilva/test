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

            //Task 2
            ViewBag.q2Basic1 = CheckDigit.GetCheckDigit("543215432154321", new[] {3, 5, 7});

            // Task 3
            ViewBag.q3Basic1 = Sort.getSort().cyclicSort("0123456789ABCDEF".ToCharArray(), 11);
            ViewBag.q3Advance1 = Sort.getSort().cyclicReverseSort("d nntobmeanhnld ftcitao.Laluw lyteuhtoohevet iGa rs llUnai coBn o  oayg. p no .oddf .ityio gntire d. LoKrRiouyiG".ToCharArray(), 13);

            return View();
        }
    }
}