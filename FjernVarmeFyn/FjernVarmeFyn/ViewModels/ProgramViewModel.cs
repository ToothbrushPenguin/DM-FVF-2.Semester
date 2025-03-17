using FjernVarmeFyn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FjernVarmeFyn.ViewModels
{
    public class ProgramViewModel
    {
        private Program _program;
        string Description => _program.Description;
        User systemUser => _program.systemUser;

        public ProgramViewModel(Program program)
        {
            _program = program;
        }
    }
}
