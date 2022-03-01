using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Management_System
{
    class Authentication
    {
        public string Server_Name { get; set; }
        public string Server_Validation { get; set; }
        public string chk_Authentication { get; set; }

        public string User_Id { get; set; }
        public string User_Validation { get; set; }

        public string Password { get; set; }
        public string Password_Validation { get; set; }
        public string Database { get; set; }

        public string Database_Validation { get; set; }
        public string File_Validation { get; set; }
    }
}
