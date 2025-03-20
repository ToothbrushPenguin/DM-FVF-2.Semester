using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FjernVarmeFyn.Models;

namespace FjernVarmeFyn.Persistence
{
    public class UserGroupRepository
    {

        private List<UserGroup> groups = new List<UserGroup>();

        public UserGroupRepository() {
        
        }

        public UserGroup Create(string name, List<Program> systemList)
        {
            UserGroup newUserGroup = new UserGroup(name, systemList);
            groups.Add(newUserGroup);
            return newUserGroup;

        }

        public UserGroup Read(string name)
        {
            UserGroup read = null;
            foreach (UserGroup group in groups)
            {
                if (group.Name == name)
                {
                    read = group;
                }    
            }
            return read;
        }

        public UserGroup Update(string name, string newName, List<Program> newSystemList)
        {
            UserGroup ug = Read(name);
            ug.Name = newName;
            ug.SystemList = newSystemList;
            return ug;
            
        }

        public UserGroup Delete(string name)
        {
            UserGroup ug = Read(name);
            groups.Remove(ug);
            return ug;

        }
    }
}
