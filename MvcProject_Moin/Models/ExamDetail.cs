//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcProject_Moin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExamDetail
    {
        public int ExamDetailsID { get; set; }
        public string ExamName { get; set; }
        public Nullable<int> StudentID { get; set; }
        public System.DateTime ExamDate { get; set; }
        public System.DateTime ResultPublishDate { get; set; }
        public int MCQ { get; set; }
        public int Descriptive { get; set; }
        public int Evidence { get; set; }
        public Nullable<int> Total { get; set; }
    
        public virtual Student Student { get; set; }
    }
}