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
    
    public partial class Book_Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book_Category()
        {
            this.Books = new HashSet<Book>();
        }
    
        public int Id { get; set; }
        public string Institution_Code { get; set; }
        public string Category_Name { get; set; }
        public string Section_Code { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_On { get; set; }
        public string Modified_By { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
