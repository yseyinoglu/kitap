//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Sikayet = new HashSet<Sikayet>();
            this.Kitapİlan = new HashSet<Kitapİlan>();
            this.Yorum = new HashSet<Yorum>();
        }
    
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
    
        public virtual UserType UserType { get; set; }
        public virtual ICollection<Sikayet> Sikayet { get; set; }
        public virtual ICollection<Kitapİlan> Kitapİlan { get; set; }
        public virtual ICollection<Yorum> Yorum { get; set; }
    }
}
