
using UserMng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserMng.Data;

namespace UserMng.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<Users> users = new List<Users>();

            UsersDAO usersDAO = new UsersDAO();

            users = usersDAO.FetchAll();

            return View("index", users);
        }

        public ActionResult Details(int id)
        {
            UserDetails usersDetails = new UserDetails();
            Users users = usersDetails.FetchOne(id);

            return View("Details", users);
        }

        public ActionResult Create()
        {
            return View("UserForm");
        }

        public ActionResult Edit(int id)
        {
            UserDetails usersDetails = new UserDetails();
            Users users = usersDetails.FetchOne(id);
            return View("UserForm", users);
        }

        public ActionResult Delete(int id)
        {
            UsersDAO usersDAO = new UsersDAO();
            usersDAO.Delete(id);

            List<Users> users = usersDAO.FetchAll();
            return View("Index", users);
        }

        public ActionResult ProcessCreate(Users users)
        {
            UsersDAO usersDAO = new UsersDAO();
            usersDAO.CreateOrUpdate(users);
            return View("Details", users);
        }
    } 
}