using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagement.Models
{
    public class Competency
    {
        public Nullable<int> UserId
        {
            get; set;
        }
        public string UserName
        {
            get; set;
        }
        public Nullable<int> QuestionID
        {
            get; set;
        }
        public string QuestionText
        {
            get; set;
        }
        public string QuestionExplanation
        {
            get; set;
        }

        public Nullable<int> ProjectID
        {
            get; set;
        }
        public string ProjectName
        {
            get; set;
        }
        public string ProjectManager
        {
            get; set;
        }

        public Nullable<int> Category_ID
        {
            get; set;
        }
        public string CategoryName
        {
            get; set;
        }
        public Nullable<int> SubCategory_ID
        {
            get; set;
        }
        public string SubCategory_Name
        {
            get; set;
        }
        public int BaseFC1
        {
            get; set;
        }

        public int BaseFC2
        {
            get; set;
        }

        public int BaseFC3
        {
            get; set;
        }

        public int BaseFC4
        {
            get; set;
        }

        public int GoalFC1
        {
            get; set;
        }

        public int GoalFC2
        {
            get; set;
        }


        public int GoalFC3
        {
            get; set;
        }

        public int GoalFC4
        {
            get; set;
        }
        public int FeatureCycleID
        {
            get; set;
        }
        
    }
}