//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvckutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLUYEROL
    {
        public int UyeRolID { get; set; }
        public int ID { get; set; }
        public int RolID { get; set; }
    
        public virtual TBLROLLER TBLROLLER { get; set; }
        public virtual TBLUYE TBLUYE { get; set; }
    }
}