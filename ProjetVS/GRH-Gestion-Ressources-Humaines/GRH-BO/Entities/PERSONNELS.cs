//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GRH_BO.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PERSONNELS
    {
        public decimal IDPERSONNEL { get; set; }
        public decimal IDSTATUT { get; set; }
        public decimal IDDIPLOME { get; set; }
        public Nullable<decimal> IDRECLASSEMENT { get; set; }
        public decimal IDLOCALITE { get; set; }
        public decimal IDSERVICE { get; set; }
        public Nullable<decimal> IDRETRAITE { get; set; }
        public Nullable<decimal> IDINTEGRATION { get; set; }
        public string NOM { get; set; }
        public string PRENOM { get; set; }
        public string SEXE { get; set; }
        public System.DateTime DDN { get; set; }
        public string MATRICULE { get; set; }
        public string NATIONALITE { get; set; }
        public string CIN { get; set; }
        public System.DateTime DATECIN { get; set; }
        public string LIEUCIN { get; set; }
        public string DUPLICATACIN { get; set; }
        public Nullable<System.DateTime> DATEDUPLICATA { get; set; }
        public byte[] PHOTO { get; set; }
        public System.DateTime DATEENTREE { get; set; }
        public System.DateTime DATERECLASSEMENT { get; set; }
        public System.DateTime DATEINTEGRATION { get; set; }
        public Nullable<System.DateTime> DATEAFFECTATION { get; set; }
    }
}
