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
    
    public partial class CompetencyCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompetencyCategory()
        {
            this.Competency_Analysis = new HashSet<Competency_Analysis>();
            this.CompetencyQuestions = new HashSet<CompetencyQuestion>();
            this.CompetencySubCategories = new HashSet<CompetencySubCategory>();
            this.CompetencyMatrices = new HashSet<CompetencyMatrix>();
            this.UserCompetencies = new HashSet<UserCompetency>();
            this.CompetencySubQuestions = new HashSet<CompetencySubQuestion>();
        }
    
        public int Category_ID { get; set; }
        public string CategoryName { get; set; }
        public string Inserted_By { get; set; }
        public Nullable<System.DateTime> Inserted_Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Competency_Analysis> Competency_Analysis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetencyQuestion> CompetencyQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetencySubCategory> CompetencySubCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetencyMatrix> CompetencyMatrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCompetency> UserCompetencies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetencySubQuestion> CompetencySubQuestions { get; set; }
    }
}
