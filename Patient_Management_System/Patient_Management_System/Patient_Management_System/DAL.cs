using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Patient_Management_System
{
    public class DAL
    {
        public SqlConnection connection;
        public SqlTransaction transaction = null;
        public SqlCommand command;
        public SqlDataReader rdr;
        public List<string> lst_data;
        Authentication obj_authenticate = new Authentication();
        public string server_validation, user_validation;
        public int Id;

        public DAL()
        {
            if(Configuration.database_name!=null)
            {
                connection = new SqlConnection(@"Server ='" + Configuration.server_name + "' ;Database='" + Configuration.database_name + "'; Trusted_Connection=True;");
            }
            
            else if (Configuration.chk_win_authenticate == "Checked")
            {
                connection = new SqlConnection(@"Server='" + Configuration.server_name + "';Trusted_Connection = True;");
            }
            else if (Configuration.chk_win_authenticate == "")
            {
                connection = new SqlConnection(@"Server='" + Configuration.server_name + "'; User ID='" + Configuration.user_id + "';Password='" + Configuration.password + "'");                  
            }
            else
            {
                connection = new SqlConnection(@"Server ='" + Configuration.server_name + "' ;Database='" + Configuration.database_name + "'; User ID='" + Configuration.user_id + "';Password='" + Configuration.password + "'; Trusted_Connection=True;");
            }
            command = new SqlCommand
            {
                Connection = connection,
                Transaction = transaction,
                CommandType = CommandType.Text
                };
            }

            public ConnectionState State()
            {
                return connection.State;
            }
            public void OpenConnection()
            {
               try
               {
             
                  if (connection.State != ConnectionState.Open)
                    connection.Open();
                }
               catch
               {
                  if (Configuration.chk_win_authenticate == "Checked")
                  {
                    server_validation = "Please Enter Valid Server Name";
                  }
                  else
                  {
                    user_validation = "Enter Valid Server, User Id and Password";
                  }
               }
            }

            public void CloseConnection()
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            public string ExecuteQuery(string query)
            {
                string msg = "ok";             
                command.CommandText = query;                
                command.ExecuteNonQuery();
                return msg;
            }

         
         public string ExecuteScalar(string query)
         {
            string msg = "ok";
            try
            {
                OpenConnection();
                command.CommandText = query;
                Id = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
            return msg;
        }


        public void Add_To_List(string filePath, List<string> lst)
        {
            try
            {
                var file = File.ReadLines(filePath).ToArray();
                StringBuilder sbFile = new StringBuilder();
                foreach (string line in file)
                {
                    if (String.IsNullOrWhiteSpace(line) == false)
                    {
                        bool quotesStarted = false;
                        StringBuilder sbLine = new StringBuilder();
                        foreach (char currentChar in line)
                        {
                            if (currentChar == '"')
                            {
                                quotesStarted = !quotesStarted;
                                sbLine.Append(currentChar);
                            }
                            else if (currentChar == ',')
                            {
                                if (quotesStarted)
                                    sbLine.Append(currentChar);
                                else
                                    sbLine.Append("\t");
                            }
                            else
                                sbLine.Append(currentChar);
                        }
                        sbFile.AppendLine(sbLine.ToString());
                    }
                    break;
                }

                string[] splitData = sbFile.ToString().Split('\t');
                for (int i = 0; i < splitData.Length; i++)
                {
                    lst.Add(splitData[i].Replace('"', ' ').Trim());
                }

            }
            catch
            {
                obj_authenticate.File_Validation = "Select Valid CSV File";
            }
        }
    


        public void Get_Data(string query)
        {
            lst_data = new List<string>();
            OpenConnection();
            if (server_validation == "" && user_validation=="")
            {
                command.CommandText = query;
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    lst_data.Add(rdr[0].ToString());
                }
                rdr.Close();
                CloseConnection();
            }
        }

        //public void Close_CSV_File()
        //{
        //    foreach (Process myProc in Process.GetProcesses())
        //    {
        //        if (myProc.ProcessName == "EXCEL")
        //        {
        //            myProc.Kill();
        //            break;
        //        }
        //    }
        //}
    }
}