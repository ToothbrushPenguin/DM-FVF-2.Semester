using Azure.Core.Pipeline;
using FjernVarmeFyn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernVarmeFyn.ViewModels
{
    public class UserGroupViewModel
    {
        public string Name { get; set; }
        public List<Program> SystemList { get; set; }

        public UserGroupViewModel(UserGroup group) 
        {

            
        }
    }
}
