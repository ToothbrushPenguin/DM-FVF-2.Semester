using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernVarmeFyn.Models
{
    public class Program
    {
        public int? ProgramID = 0;
        public string? Description {  get; set; }
        public User systemUser;

        public Program()
        {
            ProgramID++;
        }
    }
}
