using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Security;
using Mvckutuphane.Models.Entity;


namespace Mvckutuphane.Roller

{
    
    public class KullaniciRolProvider : RoleProvider
    {
       
        public override string ApplicationName 
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public override string[] GetRolesForUser(string username )
        {
            var bilgiler = db.TBLUYE.FirstOrDefault(x => x.MAIL ==username );
            return new string[] {bilgiler.MAIL};
        }
        
        public override string[] GetUsersInRole(string roleName)
        {
           
                 throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}