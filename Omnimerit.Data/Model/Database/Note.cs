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
    
    public partial class Note
    {
        public int Id { get; set; }
        public string Institution_Code { get; set; }
        public string Tilte { get; set; }
        public string Description { get; set; }
        public byte[] Attachment { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_On { get; set; }
        public string Modified_By { get; set; }
        public int Course { get; set; }
        public int Batch { get; set; }
        public int Subject { get; set; }
    
        public virtual Batch Batch1 { get; set; }
        public virtual Course Course1 { get; set; }
        public virtual Subject Subject1 { get; set; }
    }
}
