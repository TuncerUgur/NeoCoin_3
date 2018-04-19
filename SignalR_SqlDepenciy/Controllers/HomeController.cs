using NeCoin.Models;
using SignalR_SqlDepenciy.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR_SqlDepenciy.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();


            return View();
        }

        public string PersonelleriGetir()
        {
            VeriTabaniIslemleri Veri = new VeriTabaniIslemleri();
            var Personeller = Veri.GetExchanges();
            return Helper.RazorViewRender(Personeller, "~/Views/Shared/_ExchangeList.cshtml");
        }

        public string BitcoinGetir()
        {
            VeriTabaniIslemleri Veri = new VeriTabaniIslemleri();
            var btc = Veri.BitcoinGetir();
            return Helper.RazorViewRender(btc, "~/Views/Shared/_BitcoinList.cshtml");
        }



        public ActionResult Create()
        {




            return View();

          
        }

        [HttpPost]
        public ActionResult Create(Bitcoin btc)
        {

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Bitcoin.Add(btc);
                db.SaveChanges();
            }


            return RedirectToAction("Index");


        }

        public ActionResult Credit()
        {




            return View();


        }

        [HttpPost]
        public ActionResult Credit(MyWallet cre)
        {

            using (DatabaseContext db = new DatabaseContext())
            {

                db.MyWallet.Add(cre);
       
                db.SaveChanges();
     
            }


            return RedirectToAction("Index");


        }






    }

}