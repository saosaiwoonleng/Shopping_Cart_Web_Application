﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using CAProject.Models;
using CAProject.DB;
using CAProject.Filters;

namespace CAProject.Controllers
{
    [AuthorizationFilter]
    public class MyPurchasesController : Controller
    {
        // GET: MyPurchases
        [Route("Partial")]
        public ActionResult MyPurchases()
        {
            string username = (string)Session["username"];
            Customer customer = CustomerData.GetCustomerDetails(username);
            List<OrderQuantity> listoforders = OrderQuantityData.GetOrdersHistory(customer.Id);
            ViewBag.orderhistory = listoforders;
            List<Order> allorders = OrderData.GetAllOrdersByCustomer(customer.Id);
            ViewBag.orderdates = allorders;
            List<OrderDetails> alldetails = OrderDetailsData.GetOrderDetailsByCustomer(customer.Id);
            ViewBag.orderdetails = alldetails;


            return View();
        }
    }
}