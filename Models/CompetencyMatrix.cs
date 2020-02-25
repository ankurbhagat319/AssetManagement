//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AssetManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompetencyMatrix
    {
        public int Competency_ID { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> Category_ID { get; set; }
        public Nullable<int> SubCategory_ID { get; set; }
        public Nullable<int> QuestionID { get; set; }
        public Nullable<int> Version_ID { get; set; }
        public Nullable<int> FeatureCycleID { get; set; }
        public string QuestionText { get; set; }
        public string QuestionExplanation { get; set; }
        public string BaseValue { get; set; }
        public string GoalValue { get; set; }
        public Nullable<int> FC1_LevelID { get; set; }
        public Nullable<int> FC2_LevelID { get; set; }
        public Nullable<int> FC3_LevelID { get; set; }
        public Nullable<int> FC4_LevelID { get; set; }
        public string Financial_Year { get; set; }
        public string Comment { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual CompetencyCategory CompetencyCategory { get; set; }
        public virtual CompetencyQuestion CompetencyQuestion { get; set; }
        public virtual CompetencySubCategory CompetencySubCategory { get; set; }
        public virtual FeatureCycle FeatureCycle { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
        public virtual Version Version { get; set; }
    }
}
