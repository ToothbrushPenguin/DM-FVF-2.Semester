using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernVarmeFyn.Models
{
    public class UserGroup
    {
        public string Name { get; set; }
        public List<Program> SystemList { get; set; }

        public UserGroup(string name, List<Program> systemList) {
            Name = name;
            SystemList = systemList;
        }
    }
}
