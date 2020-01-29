using GRH_BO.Dto.User;
using GRH_BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRH_UI.Models.Administration
{
    public class AdministrationViewModel
    {
        /*POUR LE CHAMP CREATION*/
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public decimal Profil { get; set; }
        public string AccesMenu { get; set; }

        public List<UserDto> ListUser { get; set; }
        public List<PROFIL> ListProfil { get; set; }
        public List<ACCES> ListAcces { get; set; }

        public AdministrationViewModel()
        {
            ListAcces = new List<ACCES>();
            ListProfil = new List<PROFIL>();
            ListUser = new List<UserDto>();
        }
    }
}