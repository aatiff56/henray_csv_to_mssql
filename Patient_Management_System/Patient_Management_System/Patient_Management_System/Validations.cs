using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Management_System
{
    class Validations
    {
        public static string time;
        public bool Connection_Validation(Authentication obj_authenticate)
        {
            if (obj_authenticate.Server_Name == "")
            {
                obj_authenticate.Server_Validation = "Please enter Server Name";
            }

            if (obj_authenticate.chk_Authentication != "Checked")
            {
                if (obj_authenticate.User_Id == "")
                {
                    obj_authenticate.User_Validation = "Please enter Username";
                }
                if (obj_authenticate.Password == "")
                {
                    obj_authenticate.Password_Validation = "Please enter Password";
                }
            }
            return false;
        }

        public bool Database_Validation(Authentication obj_authenticate)
        {
            if (obj_authenticate.Database != "Patient")
            {
                obj_authenticate.Database_Validation = "Please Select Valid Database";
            }
            return false;
        }


        public string Time_Validation(string col_time)
        {
            if(col_time=="N/A" || col_time=="")
            {
                time = null;
            }
            else
            {
                time = col_time.Replace(".", ":");
            }
            return time;
        }
    }
}
