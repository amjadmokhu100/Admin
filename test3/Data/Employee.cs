//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test3.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public Nullable<byte> Employeekind { get; set; }
        public string UserId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
