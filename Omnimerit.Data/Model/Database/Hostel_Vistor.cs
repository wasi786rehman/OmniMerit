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
    
    public partial class Hostel_Vistor
    {
        public int Id { get; set; }
        public string Institution_Code { get; set; }
        public string User_Type { get; set; }
        public string Visitor_Name { get; set; }
        public string Relation { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_On { get; set; }
        public string Modified_By { get; set; }
    }
}
