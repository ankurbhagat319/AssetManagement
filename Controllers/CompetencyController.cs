using AssetManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AssetManagement.Controllers
{
    public class CompetencyController : Controller
    {
           
        private ProjectManagementEntities db = new ProjectManagementEntities();
        // GET: Competency
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompetencyManagement()
        {
            return View();
        }
        public ActionResult UserBaseValues()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserID", "DisplayName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.FeatureCycleID = new SelectList(db.FeatureCycles, "FeatureCycle_ID", "FeatureCycle_Name");
            return View();
        }
        public ActionResult UserCompetency()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserID", "DisplayName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            ViewBag.FeatureCycleID = new SelectList(db.FeatureCycles, "FeatureCycle_ID", "FeatureCycle_Name");

            return View();
        }
        public ActionResult Competency()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserID", "UserName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "ProjectName");
            return View();
        }
     
        public ActionResult GetQuestions(int ProjectID,int UserID)
        {
            int CaseId = 0;
            var CompetencyQuestions = new List<Models.Competency>();
            List<Competency> lstque = new List<Models.Competency>();
            ////Check Competency Alreday Available for User///////////
            SqlParameter p1 = null;
            SqlParameter p2 = null;
            SqlParameter p3 = null;
            p1 = new SqlParameter("ProjectID", ProjectID);
            p3 = new SqlParameter("UserID", UserID);

            var Check_Competency = db.UserCompetencies.Where(x => x.UserID == UserID).Select(x => x).ToList();
            if (Check_Competency.Count > 0)
            {
                CaseId = 1;
                p2 = new SqlParameter("CaseId", CaseId);
                using (var dbcontext = new ProjectManagementEntities())
                {

                    try
                    {
                        CompetencyQuestions = dbcontext.Database.SqlQuery<Competency>("SP_GETCOMPETENCY_QUESTIONS @ProjectID,@CaseId,@UserID", p1, p2, p3).ToList();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                
                }

            }
            else
            {
                using (var dbcontext = new ProjectManagementEntities())
                {
                    p2 = new SqlParameter("CaseId", CaseId);

                    CompetencyQuestions = dbcontext.Database.SqlQuery<Competency>("SP_GETCOMPETENCY_QUESTIONS @ProjectID,@CaseId,@UserID", p1, p2,p3).ToList();
                }

            }




            return new JsonResult()
            {
                Data = new
                { data = CompetencyQuestions.ToArray()},
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }

        public ActionResult SaveBaseValue(List<UserBaseValue> userValues)
        {
            
                try
                {
                if (ModelState.IsValid)
                {
                    db.UserBaseValues.AddRange(userValues);
                }
                db.SaveChanges();
                }
                catch (Exception ex)
                {
                   
                }
               
            //}
            return Json("success", JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetUserName(int UserID)
        {
            var UserName = db.Users.Where(x => x.UserID == UserID).Select(x => x.UserName).ToList();
            return Json(UserName.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserQuestions(int ProjectID, int  UserID)
        {
            var CompetencyQuestions = new List<Models.View_UserCompetency>();
            var Check_CompetencyQuestions = new List<Models.View_Check_Competency_New>();
            List<View_UserCompetency> lstque = new List<Models.View_UserCompetency>();
            var Check_Competency = db.UserCompetencies.Where(x => x.UserID == UserID).Select(x => x).ToList();
            if (Check_Competency.Count > 0)
            {
                Check_CompetencyQuestions = db.View_Check_Competency_New.Where(x => x.UserID == UserID && x.ProjectID == ProjectID).Select(x => x).ToList();

                return new JsonResult()
                {
                    Data = new
                    {
                        data = Check_CompetencyQuestions.ToArray()
                    },
                    ContentType = "application/json",
                    ContentEncoding = Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = Int32.MaxValue
                };
            }
            else
            {
                CompetencyQuestions = db.View_UserCompetency.Where(x => x.UserID == UserID && x.ProjectID == ProjectID).Select(x => x).ToList();

                return new JsonResult()
                {
                    Data = new
                    {
                        data = CompetencyQuestions.ToArray()
                    },
                    ContentType = "application/json",
                    ContentEncoding = Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    MaxJsonLength = Int32.MaxValue
                };
            }
          
        
 

        }

        public ActionResult SaveUserCompetency(List<UserCompetency> userValues)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.UserCompetencies.AddRange(userValues);
                    db.SaveChanges();
                }
             
            }
            catch (Exception ex)
            {
                throw ex;
            }

         return Json("success", JsonRequestBehavior.AllowGet);
        }

        public  ActionResult UpdateBaseValues( List<UserBaseValue> baseValues)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var val in baseValues)
                    {

                        var Values = db.UserBaseValues.Where(x => x.UserID == val.UserID && x.ProjectID == val.ProjectID && x.QuestiionID == val.QuestiionID).ToList();
                        Values.ForEach(a =>
                        {
                            a.BaseFC2 = val.BaseFC2;
                            a.BaseFC3 = val.BaseFC3;
                            a.BaseFC4 = val.BaseFC4;
                        });
                        db.SaveChanges();
                    }
               
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubQuestions(int Category_Id,int SubCategory_Id,int Question_Id)
        {

            var SubQuestion = db.CompetencySubQuestions.Where(x => x.Category_Id == Category_Id && x.SubCategory_Id == SubCategory_Id && x.Question_Id  == Question_Id).ToList();
            return new JsonResult()
            {
                Data = new
                {
                    data = SubQuestion.ToArray()
                },
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }

    }
}