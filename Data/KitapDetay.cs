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
    
    public partial class KitapDetay
    {
        public KitapDetay()
        {
            this.Kitapİlan = new HashSet<Kitapİlan>();
        }
    
        public int Id { get; set; }
        public string KitapSayfaNo { get; set; }
        public string KitapYazari { get; set; }
        public System.DateTime KitapYayinTarihi { get; set; }
        public string KitapBaskıSayısı { get; set; }
        public string KitapBoyutu { get; set; }
        public string KitapDili { get; set; }
    
        public virtual ICollection<Kitapİlan> Kitapİlan { get; set; }
    }
}
