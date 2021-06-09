using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult General()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string login_username, string login_password)
        {
            Session["access"] = CRUD.login_access(login_username, login_password);
            return View();
        }
        public ActionResult SignUp(string FName, string LName, string Email, string UName, string pass1, string pass2, string SSN, int Age, string phno, string Addr)
        {
            Session["Sign_Up"] = CRUD.SignUp(FName, LName, Email, UName, pass1, pass2, SSN, Age, phno, Addr);
            return View();
        }
        public ActionResult ViewItems()
        {
            return View(CRUD.ViewItems());
        }
        public ActionResult BuyCard()
        {
            return View();
        }
        public ActionResult PayForCard(int card_Amt)
        {
            Session["Pay_For_Card"] = CRUD.PayForCard(card_Amt);
            return View();
        }
        public ActionResult HomePage()
        {
            Session["Home_Page"] = CRUD.HomePage();
            return View();
        }
        public ActionResult MgrHomePage()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
        public ActionResult GetBill(int ItemID, int ItemQty, string delivery)
        {
            Session["Get_Bill"] = CRUD.GetBill(ItemID, ItemQty, delivery);
            return View();
        }
        public ActionResult PayBill(int Bill_Amt)
        {
            Session["Pay_Bill"] = CRUD.PayBill(Bill_Amt);
            return View();
        }
        public  ActionResult CancelOrder()
        {
            Session["Cancel_Order"] = CRUD.CancelOrder();
            return View();
        }
        public ActionResult Feedback(string feedback)
        {
            return View(CRUD.Feedback(feedback));
        }
        public ActionResult SearchByCategory(string searchbycategory)
        {
            return View(CRUD.SearchByCategory(searchbycategory));
        }
        public ActionResult SearchByName(string searchbyname)
        {
            return View(CRUD.SearchByName(searchbyname));
        }
        public ActionResult Earnings()
        {
            return View();
        }
        public ActionResult SeeEarning(DateTime earningdate)
        {
            Session["See_Earning"] = CRUD.SeeEarning(earningdate);
            return View();
        }
        public ActionResult SeeEarningFromTo(DateTime startearningdate, DateTime endearningdate)
        {
            Session["See_Earning_From_To"] = CRUD.SeeEarningFromTo(startearningdate, endearningdate);
            return View();
        }
        public ActionResult AddEmp()
        {
            return View();
        }
        public ActionResult AddEmpInfo(string EName, int EAge, string ESSN, string EPNo, string EAddress, string EDes, int ESal)
        {
            Session["Add_Emp_Info"] = CRUD.AddEmpInfo(EName, EAge, ESSN, EPNo, EAddress, EDes, ESal);
            return View();
        }
        public ActionResult ViewEmp()
        {
            return View(CRUD.ViewEmp());
        }
        public ActionResult RemEmp()
        {
            return View();
        }
        public ActionResult RemEmpInfo(int EID)
        {
            Session["Rem_Emp_Info"] = CRUD.RemEmpInfo(EID);
            return View();
        }
        public ActionResult AddExp()
        {
            return View();
        }
        public ActionResult AddExpInfo(int EAmt, string EReason)
        {
            Session["Add_Exp_Info"] = CRUD.AddExpInfo(EAmt, EReason);
            return View();
        }
        public ActionResult Addtem()
        {
            return View();
        }
        public ActionResult AddItemInfo(string IName, string IPrice, string Ing, string Cat)
        {
            Session["Add_Item_Info"] = CRUD.AddItemInfo(IName, IPrice, Ing, Cat);
            return View();
        }
        public ActionResult ViewUsers()
        {
            return View(CRUD.ViewUsers());
        }
        public ActionResult add_message(string name, string email, string sms)
        {
            Session["add_message"] = CRUD.add_message(name, email, sms);
            return View();
        }
        public ActionResult ViewMessages()
        {
            return View(CRUD.ViewUsers());
        }
        public ActionResult ShowFeedback()
        {
            return View(CRUD.ShowFeedback());
        }
        public ActionResult ViewProfit()
        {
            return View();
        }
        public ActionResult SeeProfit(int month, int year)
        {
            Session["See_Profit"] = CRUD.SeeProfit(month, year);
            return View();
        }
        public ActionResult GraphicalEarning()
        {
            return View(CRUD.GraphicalEarning());
        }
    }
}
