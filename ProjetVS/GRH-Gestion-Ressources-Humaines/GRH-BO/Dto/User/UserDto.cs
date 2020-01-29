using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRH_BO.Dto.User
{
    public class UserDto
    {
        public decimal Id { get; set; }

        public decimal ProfilId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Email { get; set; }

        public string TelInscription { get; set; }

        public string Photo { get; set; }

        public System.DateTime ProfilDate { get; set; }

        public string ProfilLabel { get; set; }
    }
}
