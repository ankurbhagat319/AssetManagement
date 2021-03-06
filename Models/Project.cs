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
    
    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            this.AssetDetails = new HashSet<AssetDetail>();
            this.Competency_Analysis = new HashSet<Competency_Analysis>();
            this.CompetencyMatrices = new HashSet<CompetencyMatrix>();
            this.CompetencyQuestions = new HashSet<CompetencyQuestion>();
            this.ProjectAssetDetails = new HashSet<ProjectAssetDetail>();
            this.Users = new HashSet<User>();
            this.UserCompetencies = new HashSet<UserCompetency>();
            this.CompetencySubQuestions = new HashSet<CompetencySubQuestion>();
        }
    
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCategory { get; set; }
        public string Segment { get; set; }
        public string SegmentHead { get; set; }
        public string SegmentHead_ZID { get; set; }
        public string SegmentHead_Email { get; set; }
        public string SubSegment { get; set; }
        public string SubsegmentHead { get; set; }
        public string SubSegmentHead_ZID { get; set; }
        public string SubsegmentHead_Email { get; set; }
        public string ProjectManager { get; set; }
        public string ManagerZID { get; set; }
        public string ManagerEmail { get; set; }
        public Nullable<System.DateTime> Modified_Date { get; set; }
        public string Modified_By { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetDetail> AssetDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Competency_Analysis> Competency_Analysis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetencyMatrix> CompetencyMatrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetencyQuestion> CompetencyQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectAssetDetail> ProjectAssetDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCompetency> UserCompetencies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetencySubQuestion> CompetencySubQuestions { get; set; }
    }
}
