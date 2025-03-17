using FjernVarmeFyn.Models;
using FjernVarmeFyn.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernVarmeFyn.ViewModels
{
    public class UserViewModel
    {
        private readonly User _user;
        public string Password => _user.Password;
        public string Email => _user.Email;
        public string PhoneNR => _user.PhoneNR;
        public Group Group => (Group)_user.Group;
        public string LogInScreen { get; set; } // ???

        public UserViewModel(User user) 
        { 
            _user = user ?? throw new ArgumentException(nameof(user));
        }
        
    }
}
