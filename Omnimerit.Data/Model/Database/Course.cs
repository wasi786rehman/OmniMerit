//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Omnimerit.Data.Model.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.Assign_Subject = new HashSet<Assign_Subject>();
            this.Assignments = new HashSet<Assignment>();
            this.Batches = new HashSet<Batch>();
            this.Class_Teacher = new HashSet<Class_Teacher>();
            this.Elective_Subject_Allocation = new HashSet<Elective_Subject_Allocation>();
            this.Notes = new HashSet<Note>();
            this.Students = new HashSet<Student>();
            this.Subject_Allocation = new HashSet<Subject_Allocation>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public Nullable<int> Minimum_Attendance { get; set; }
        public string Attendance_Type { get; set; }
        public Nullable<int> Total_Day { get; set; }
        public string Syllabus_Name { get; set; }
        public string Institution_Code { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_On { get; set; }
        public string Modified_By { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assign_Subject> Assign_Subject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Batch> Batches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class_Teacher> Class_Teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elective_Subject_Allocation> Elective_Subject_Allocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Note> Notes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subject_Allocation> Subject_Allocation { get; set; }
    }
}
