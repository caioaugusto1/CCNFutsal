//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ColaComNois.Context.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class CCN_Despesas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CCN_Despesas()
        {
            this.CCN_Rateios = new HashSet<CCN_Rateios>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public System.DateTime Data_Vencimento { get; set; }
        public Nullable<System.DateTime> Data_Pagamento { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CCN_Rateios> CCN_Rateios { get; set; }
    }
}