using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Models;
using System.Text;


namespace AssetManagement.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AssetDetailsOverview()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ManageAssets()
        {

            
            return View();
        }
        public ActionResult GetAssets()
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            ConnectionStringSettings cs = new ConnectionStringSettings();
            SqlConnection conn = new SqlConnection();
            SqlDataReader rdr = null;
            List<AssetDetailsOverview> lstasset = new List<Models.AssetDetailsOverview>();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebFrontEndDB"].ConnectionString;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPGetAssetDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                rdr = cmd.ExecuteReader();
              
                while (rdr.Read())
                {
                    AssetDetailsOverview obj = new Models.AssetDetailsOverview();
                    obj.Type = rdr["Type"].ToString();
                    obj.Manufacturer = rdr["Manufacturer"].ToString();
                    obj.Resources_Class = rdr["Resources_Class"].ToString();
                    obj.Serial_No = rdr["Serial_No"].ToString();
                    obj.HostName = rdr["HostName"].ToString();
                    obj.SpiridonNo = rdr["SpiridonNo"].ToString();
                    obj.Location = rdr["Location"].ToString();
                    obj.PRNO = rdr["PRNO"].ToString();
                    obj.PONO = rdr["PONO"].ToString();
                    obj.WarrantyStartDate = rdr["WarrantyStartDate"].ToString();
                    obj.AgeOfAsset = rdr["AgeOfAsset"].ToString();
                    obj.ExpireBy = rdr["ExpireBy"].ToString();

                    obj.Owner = rdr["Owner"].ToString();
                    obj.RAM = rdr["RAM"].ToString();
                    obj.Storage = rdr["Storage"].ToString();
                    obj.Processor = rdr["Processor"].ToString();
                    obj.CPUClockSpeed = rdr["CPUClockSpeed"].ToString();
                    obj.PhysicalCores = rdr["PhysicalCores"].ToString();
                    obj.NIC_Count = rdr["NIC_Count"].ToString();
                    lstasset.Add(obj);
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }


            return new JsonResult()
            {
                Data = new
                {
                    data = lstasset != null ? lstasset.ToArray() : null,
                  

                },
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }

        public ActionResult SaveAssest(string Type, string Manufacturer, string Resources_Class,
            string Serial_No, string HostName, string SpiridonNo, string Location, string PRNO, string PONO, string WarrantyStartDate
            , string AgeOfAsset, string ExpireBy, string Owner, string RAM, string Storage, string Processor, string CPUClockSpeed,
            string PhysicalCores, string NIC_Count)
        {

            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            ConnectionStringSettings cs = new ConnectionStringSettings();
            SqlConnection conn = new SqlConnection();
            SqlDataReader rdr = null;
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebFrontEndDB"].ConnectionString;
            List<AssetDetailsOverview> lstasset = new List<Models.AssetDetailsOverview>();
            SqlCommand cmd = new SqlCommand("SP_AddAssets", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Manufacturer",Manufacturer);
            cmd.Parameters.AddWithValue("@Resources_Class", Resources_Class);
            cmd.Parameters.AddWithValue("@Serial_No", Serial_No);
            cmd.Parameters.AddWithValue("@HostName",HostName);
            cmd.Parameters.AddWithValue("@SpiridonNo", SpiridonNo);
            cmd.Parameters.AddWithValue("@Location", Location);
            cmd.Parameters.AddWithValue("@PRNO", PRNO);
            cmd.Parameters.AddWithValue("@PONO",PONO);
            cmd.Parameters.AddWithValue("@WarrantyStartDate", WarrantyStartDate);
            cmd.Parameters.AddWithValue("@AgeOfAsset",AgeOfAsset);
            cmd.Parameters.AddWithValue("@ExpireBy", ExpireBy);
            cmd.Parameters.AddWithValue("@Owner", Owner);
            cmd.Parameters.AddWithValue("@RAM",RAM);
            cmd.Parameters.AddWithValue("@Storage", Storage);
            cmd.Parameters.AddWithValue("@Processor", Processor);
            cmd.Parameters.AddWithValue("@CPUClockSpeed",CPUClockSpeed);
            cmd.Parameters.AddWithValue("@PhysicalCores", PhysicalCores);
            cmd.Parameters.AddWithValue("@NIC_Count", NIC_Count);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();



            return new JsonResult()
            {
                Data = new
                {
                    data = "Success"


                },
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }




        public ActionResult UpdateAssest(string Type, string Manufacturer, string Resources_Class,
           string Serial_No, string HostName, string SpiridonNo, string Location, string PRNO, string PONO, string WarrantyStartDate
           , string AgeOfAsset, string ExpireBy, string Owner, string RAM, string Storage, string Processor, string CPUClockSpeed,
           string PhysicalCores, string NIC_Count)
        {

            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            ConnectionStringSettings cs = new ConnectionStringSettings();
            SqlConnection conn = new SqlConnection();
            SqlDataReader rdr = null;
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebFrontEndDB"].ConnectionString;
            List<AssetDetailsOverview> lstasset = new List<Models.AssetDetailsOverview>();
            SqlCommand cmd = new SqlCommand("SP_Update_Assets", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Manufacturer", Manufacturer);
            cmd.Parameters.AddWithValue("@Resources_Class", Resources_Class);
            cmd.Parameters.AddWithValue("@Serial_No", Serial_No);
            cmd.Parameters.AddWithValue("@HostName", HostName);
            cmd.Parameters.AddWithValue("@SpiridonNo", SpiridonNo);
            cmd.Parameters.AddWithValue("@Location", Location);
            cmd.Parameters.AddWithValue("@PRNO", PRNO);
            cmd.Parameters.AddWithValue("@PONO", PONO);
            cmd.Parameters.AddWithValue("@WarrantyStartDate", WarrantyStartDate);
            cmd.Parameters.AddWithValue("@AgeOfAsset", AgeOfAsset);
            cmd.Parameters.AddWithValue("@ExpireBy", ExpireBy);
            cmd.Parameters.AddWithValue("@Owner", Owner);
            cmd.Parameters.AddWithValue("@RAM", RAM);
            cmd.Parameters.AddWithValue("@Storage", Storage);
            cmd.Parameters.AddWithValue("@Processor", Processor);
            cmd.Parameters.AddWithValue("@CPUClockSpeed", CPUClockSpeed);
            cmd.Parameters.AddWithValue("@PhysicalCores", PhysicalCores);
            cmd.Parameters.AddWithValue("@NIC_Count", NIC_Count);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();



            return new JsonResult()
            {
                Data = new
                {
                    data = "Success"


                },
                ContentType = "application/json",
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }

    }
}
 