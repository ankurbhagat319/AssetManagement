using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagement.Models
{
    public class AssetDetailsOverview
    {
        public string Type{get;set;}
            public string Manufacturer{get;set;}
            public string Resources_Class{get;set;}
            public string Serial_No{get;set;}
            public string HostName{get;set;}
            public string SpiridonNo{get;set;}
            public string Location{get;set;}
            public string PRNO{get;set;}
            public string PONO{get;set;}
            public string WarrantyStartDate{get;set;}
        public string AgeOfAsset
        {
            get; set;
        }
        public string ExpireBy
        {
            get; set;
        }
        public string Owner{get;set;}
            public string RAM{get;set;}
            public string Storage{get;set;}
            public string Processor{get;set;}
            public string CPUClockSpeed{get;set;}
            public string PhysicalCores{get;set;}
            public string NIC_Count{get;set;}


    }
}