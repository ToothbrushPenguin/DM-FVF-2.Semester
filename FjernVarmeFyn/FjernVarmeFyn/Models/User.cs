using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernVarmeFyn.Models
{
    public class User
    {
        public int? UserID = 0;
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string ?AccessLevel { get; set; }

        public User()
        {
            UserID++;
        }
    }
}
