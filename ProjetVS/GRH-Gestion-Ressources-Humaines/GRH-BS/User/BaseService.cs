using GRH_BO.Dto.User;
using GRH_BO.Entities;
using GRH_BO.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRH_BS.User
{
    public class BaseService : IBaseService
    {
        private readonly GRHEntities _db;

        public BaseService()
        {
            _db = new GRHEntities();
        }

        public BaseService(GRHEntities db)
        {
            _db = db;
        }
        /// <summary>
        /// Save database change
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }

        public  List<PROFIL> ListProfil()
        {
            return _db.PROFIL.ToList();
        }

        public UserDto  Login(UserDto user)
        {
            try
            {
                var entity = _db.USER.SingleOrDefault(x => x.LOGINUSER == user.Login || x.EMAIL == user.Email);
                if (entity == null)
                {
                    throw new Exception("Utilisateur inexistant!");
                }
                if (!String.Equals(entity.MDP, Utilities.GetHashString(user.Password))){
                    throw new Exception("Mot de passe incorrect!");
                }
                var result = new UserDto
                {
                    Id = entity.IDUSER,
                    ProfilId = entity.IDPROFIL,
                    Nom = entity.NOMUSER,
                    Prenom = entity.PRENOMUSER,
                    Email = entity.EMAIL
                };
                return result;
            }catch(Exception ex)
            {
                Trace.WriteLine(ex.StackTrace);
                Trace.WriteLine(ex.Source);
                Trace.WriteLine("Iner EXCEPTION : " + ex.InnerException);
                throw ex;
            }
        }

        public List<UserDto> GetAllUser() 
        {
            try
            {
                var entity = _db.USER.Select(item => new UserDto
                {
                    Id = item.IDUSER,
                    ProfilId = item.IDPROFIL,
                    Nom = item.NOMUSER,
                    Prenom = item.PRENOMUSER,
                    Email = item.EMAIL,
                    ProfilDate = item.DATEPROFIL,
                    Login = item.LOGINUSER,
                    Photo = item.PHOTOUSER != null ? item.PHOTOUSER : "",
                    TelInscription= item.TELINSCRIPTION != null ? item.TELINSCRIPTION : "",
                    Password = item.MDP
                }).ToList();
                
                return entity;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.StackTrace);
                Trace.WriteLine(ex.Source);
                Trace.WriteLine("Iner EXCEPTION : " + ex.InnerException);
                throw ex;
            }

        }

        public List<UserDto> ListUserForTable()
        {
            try
            {
                var user = GetAllUser();
                var profil = ListProfil();
                for(int i=0; i<user.Count; i++)
                {
                    for(int j=0; j < profil.Count; j++)
                    {
                        if (user.ElementAt(i).ProfilId == profil.ElementAt(j).IDPROFIL)
                        {
                            user.ElementAt(i).ProfilLabel = profil.ElementAt(j).STATUTPROFIL;
                            break;
                        }
                    }
                }
                return user;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ACCES> ListAcces()
        {
            return _db.ACCES.ToList();
        }

        public void InsertUser(USER user)
        {
            if (user == null)
            {
                throw new Exception($"Objet {nameof(user)} ne peut pas être null ");
            }

            try
            {
                _db.USER.Add(user);
                Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(USER user)
        {
            if (user == null)
            {
                throw new Exception($"Objet {nameof(user)} ne peut pas être null ");
            }

            try
            {
                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                var user = _db.USER.Find(id);
                if (user == null) return;
                _db.USER.Remove(user);
                Save();
            }
            catch (Exception ex)
            {
                throw new Exception($"Supression de donnée echouée - ID {id} ", ex);
            }
        }
    }
}
