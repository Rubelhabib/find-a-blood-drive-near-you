//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blood_Page.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Donner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public Nullable<int> Group_ID { get; set; }
        public string Email { get; set; }
        public Nullable<int> District_ID { get; set; }
        public Nullable<int> Thana_ID { get; set; }
        public string Address { get; set; }
        public string Last_Donated_On { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Date_Of_Brith { get; set; }
    
        public virtual Group Group { get; set; }
    }
}