//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NeinteenFlower.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MsMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MsMember()
        {
            this.TrHeaders = new HashSet<TrHeader>();
        }
    
        public int MemberId { get; set; }
        public string MemberRole { get; set; }
        public string MemberName { get; set; }
        public System.DateTime MemberDOB { get; set; }
        public string MemberGender { get; set; }
        public string MemberAddress { get; set; }
        public string MemberPhone { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPassword { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrHeader> TrHeaders { get; set; }
    }
}
