using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAProject.Models;
using CAProject.DB;

namespace CAProject.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult New(string name, string username, string password, string email, string address, string postalcode, string phone)
        {
            if (name == null || name == "" ||
               username == null || username == "" ||
               password == null || password == "" ||
               email == null || email == "" ||
               address == null || address == "")
            {
                string sessionid = (string)Session["sessionId"];
                if (sessionid == null || sessionid == "")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("ListProducts", "Products");
                }
            }

            else
            {
                bool check = CustomerData.CheckUsername(username);

                if (check)
                {
                    Customer customer = new Customer();
                    customer.Id = Guid.NewGuid().ToString();
                    customer.Name = name;
                    customer.Username = username;
                    customer.Password = PasswordHash.HashPassword(password);
                    customer.Email = email;
                    customer.Address = address;
                    customer.Postalcode = Convert.ToInt32(postalcode);
                    customer.Phone = Convert.ToInt32(phone);
                    CustomerData.UpdateCustomer(customer);
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    ViewBag.userfalse = "Username already exists";
                    return View();
                }
            }
        }
    }
}