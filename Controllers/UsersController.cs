using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Models;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Web.Security;

namespace AssetManagement.Controllers
{
    public class UsersController : Controller
    {
        static List<string> AD_Groups = new List<string>(new string[] {
            "RA046_TIAP_System_10252_G", "RA046_TIAP_System_10279_G","RA046_TIAP_System_10253_G", "RA046_TIAP_System_10345_G","RA046_TIAP_System_10344_G","RA046_TIAP_System_10466_G"
        });
        private ProjectManagementEntities db = new ProjectManagementEntities();
        protected class S71500Users
        {
            public int UserId
            {
                get; set;
            }
            public string UserName
            {
                get; set;
            }
            public string Email
            {
                get; set;
            }
            public string DisplayName
            {
                get; set;
            }
            public DateTime Resgistration_Date
            {
                get; set;
            }
            public DateTime LastLogon
            {
                get; set;
            }
            public string ActivatedBy
            {
                get; set;
            }
            public bool IsActive
            {
                get; set;
            }
        }

        public ActionResult UpdateUserTable()
        {
            List<S71500Users> lstusers = new List<S71500Users>();
            foreach (var Group_Name in AD_Groups)
            {
                using (var context = new PrincipalContext(ContextType.Domain, "AD001"))
                {
                    using (var group = GroupPrincipal.FindByIdentity(context, Group_Name))
                    {
                        if (group == null)
                        {
                            Console.Write("Group does not exist");

                        }
                        else
                        {
                            var users = group.GetMembers(true);
                            foreach (UserPrincipal user in users)
                            {

                                if (user.SamAccountName.ToString() == "z003ef1m")
                                {
                                    string a = "break";
                                }
                                S71500Users objusers = new S71500Users();
                                objusers.UserName = user.SamAccountName.ToString();
                                objusers.Email = user.EmailAddress;
                                objusers.DisplayName = user.DisplayName;
                                objusers.Resgistration_Date = DateTime.Now;
                                objusers.ActivatedBy = "Default";
                                objusers.IsActive = true;
                                lstusers.Add(objusers);
                            }
                        }
                    }
                }

            }
            foreach (var users in lstusers)
            {
                var Result = new List<S71500Users>();

                SqlParameter UserName = null;
                SqlParameter Email = null;
                SqlParameter DispalyName = null;
                SqlParameter TempResgitration_Date = null;
                SqlParameter ActivatedBy = null;
                SqlParameter IsActive = null;
                if (users.Email == null)
                {
                    users.Email = "Not Available";
                }
                var Registration_Date = users.Resgistration_Date.ToString().Replace("/", "-");
                UserName = new SqlParameter("UserName", users.UserName);
                Email = new SqlParameter("Email", users.Email);
                DispalyName = new SqlParameter("DisplayName", users.DisplayName);
                TempResgitration_Date = new SqlParameter("Resgitration_Date", Registration_Date);
                ActivatedBy = new SqlParameter("ActivatedBy", "Default");
                IsActive = new SqlParameter("IsActive", users.IsActive);
                //using (var dbcontext = new WebFrontEndContext())
                //{
                //    // Result = dbcontext.Database.SqlQuery<S71500Users>("SP_Login @UserName,@Email,@DisplayName,@Resgitration_Date,@ActivatedBy,@IsActive", UserName, Email, DispalyName, TempResgitration_Date, ActivatedBy, IsActive).ToList();
                //}

            }
            return Json("Succssfull", JsonRequestBehavior.AllowGet);
        }


        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Project).Include(u => u.Role);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.Project_ID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Role_Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,RoleID,UserName,DisplayName,Email,ScrumTeam,GripLevel,Joining_Date,Designation,Project_ID,Modified_date,Modified_By,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Project_ID = new SelectList(db.Projects, "ProjectID", "ProjectName", user.Project_ID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Role_Name", user.RoleID);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Project_ID = new SelectList(db.Projects, "ProjectID", "ProjectName", user.Project_ID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Role_Name", user.RoleID);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,RoleID,UserName,DisplayName,Email,ScrumTeam,GripLevel,Joining_Date,Designation,Project_ID,Modified_date,Modified_By,IsActive")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Project_ID = new SelectList(db.Projects, "ProjectID", "ProjectName", user.Project_ID);
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "Role_Name", user.RoleID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
