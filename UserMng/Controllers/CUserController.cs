using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserMng.Data;
using UserMng.Models;

namespace UserMng.Controllers
{
    public class CUserController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            UserDetails usersDetails = new UserDetails();
            Users users = usersDetails.FetchOne(id);

            return View("Details", users);
        }

        public ActionResult List()
        {
            List<Users> users = new List<Users>();

            UsersDAO usersDAO = new UsersDAO();

            users = usersDAO.FetchAll();

            return View("List", users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Edit(int id)
        {
            UserDetails usersDetails = new UserDetails();
            Users users = usersDetails.FetchOne(id);
            return View("UserForm", users);
        }
    }
}