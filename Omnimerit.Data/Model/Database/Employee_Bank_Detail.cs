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
    
    public partial class Employee_Bank_Detail
    {
        public int Id { get; set; }
        public string Institution_Code { get; set; }
        public string Branch { get; set; }
        public string Branch_Address { get; set; }
        public string Bank_Contact_No { get; set; }
        public string Ifsc_Code { get; set; }
        public string Account_No { get; set; }
        public string DD_Address { get; set; }
        public Nullable<System.DateTime> Created_On { get; set; }
        public string Created_By { get; set; }
        public Nullable<System.DateTime> Modified_On { get; set; }
        public string Modified_By { get; set; }
        public int Designation { get; set; }
        public int Employee_Name { get; set; }
        public int Bank_Name { get; set; }
    
        public virtual Bank_Detail Bank_Detail { get; set; }
        public virtual Designation Designation1 { get; set; }
        public virtual Employee Employee { get; set; }
    }
}