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
    
    public partial class CompetencyLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompetencyLevel()
        {
            this.Competency_Analysis = new HashSet<Competency_Analysis>();
            this.CompetencySubQuestions = new HashSet<CompetencySubQuestion>();
            this.CompetencySubQuestions1 = new HashSet<CompetencySubQuestion>();
        }
    
        public int Level_ID { get; set; }
        public string Level_Name { get; set; }
        public string InsertedBy { get; set; }
        public Nullable<System.DateTime> InsterDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Competency_Analysis> Competency_Analysis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetencySubQuestion> CompetencySubQuestions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompetencySubQuestion> CompetencySubQuestions1 { get; set; }
    }
}
