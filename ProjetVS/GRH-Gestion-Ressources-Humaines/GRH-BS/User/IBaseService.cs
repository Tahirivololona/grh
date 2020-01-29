using GRH_BO.Dto.User;
using GRH_BO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRH_BS.User
{
    public interface IBaseService
    {
        UserDto Login(UserDto user);

        List<UserDto> GetAllUser();

        List<UserDto> ListUserForTable();

        List<PROFIL> ListProfil();

        List<ACCES> ListAcces();

        void InsertUser(USER user);

        void UpdateUser(USER user);

        void DeleteUser(int id);
    }
}
