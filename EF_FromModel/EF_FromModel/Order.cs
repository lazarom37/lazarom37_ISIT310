//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_FromModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int OrderID { get; set; }
        public int SupplierID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int PartID { get; set; }
        public int Quantity { get; set; }
    
        public virtual Supplier Supplier { get; set; }
        public virtual Part Part { get; set; }
    }
}
