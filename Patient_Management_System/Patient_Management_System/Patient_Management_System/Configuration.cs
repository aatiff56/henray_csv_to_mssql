using DevExpress.LookAndFeel;
using DevExpress.Skins;
using Patient_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Patient_Management_System
{
    public partial class Configuration : DevExpress.XtraEditors.XtraForm
    {
        public Configuration()
        {
            InitializeComponent();
        }

        DAL dal;
        public static string file_path, server_name, user_id, password, chk_win_authenticate, fileVerifyMessage, database_name, updated_filePath;
        public static int row_count,rows_completed=0, current_row=1, progress=0;
        Authentication obj_authenticate = new Authentication();
        Validations obj_validate = new Validations();
        List<string> lst_updated_data = new List<string>();
        List<string> lst_sampled_data = new List<string>();
        List<string> lst_insert = new List<string>();
        public static SqlTransaction transaction = null;
        StreamReader reader = null;
        Thread obj_thread;
        
        private void Configuration_Load(object sender, EventArgs e)
        {
            SkinElement element = SkinManager.GetSkinElement(SkinProductId.Editors, DevExpress.LookAndFeel.UserLookAndFeel.Default, EditorsSkins.SkinCheckBox);
            element.Size.MinSize = new System.Drawing.Size(26, 27);  
            element.Image.Stretch = SkinImageStretch.Stretch;
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            txtFile.Enabled = false;
            progressBar.Visible = false;
            Btn_Start.Enabled = false;
        }

        private void Btn_Import_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "csv files(*.csv)|*.csv|All files(*.*)|*.*";
            openFileDialog.FileName = "Select CSV file.";
            DialogResult obj_dialog = openFileDialog.ShowDialog();
            file_path = openFileDialog.FileName;
            txtFile.Enabled = true;
            txtFile.Text = file_path;
        }


        private void Btn_View_CSV_Click(object sender, EventArgs e)
        {
            if (lbl_Progress.Visible== true)
            {
                MessageBox.Show("Please Wait Data is Being Imported..");
            }
            else
            {
                string file_path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Updated_CSV.csv"; ;
                Process.Start(file_path);
            }
        }

        private void Btn_FetchDatabase_Click(object sender, EventArgs e)
        {
            obj_authenticate.chk_Authentication = obj_authenticate.Server_Validation = obj_authenticate.User_Validation= obj_authenticate.Password_Validation = "";
            obj_authenticate.Server_Name = txtServerName.Text;
            obj_authenticate.User_Id = txt_UserId.Text;
            obj_authenticate.Password = txtPassword.Text;
            if (chk_authentication.Checked == true)
            {
                obj_authenticate.chk_Authentication = "Checked";
            }
                
            server_name = obj_authenticate.Server_Name;
            chk_win_authenticate = obj_authenticate.chk_Authentication;
            user_id = obj_authenticate.User_Id;
            password = obj_authenticate.Password;

            obj_validate.Connection_Validation(obj_authenticate);
            lbl_Server_Validation.Text = obj_authenticate.Server_Validation;
            lbl_user_validation.Text = obj_authenticate.User_Validation;
            lbl_Password_Validation.Text = obj_authenticate.Password_Validation;
            if (lbl_Server_Validation.Text == "" && lbl_user_validation.Text == "" && lbl_Password_Validation.Text == "")
            {
                dal = new DAL();
                dal.user_validation = dal.server_validation = "";
                string query = "SELECT name from sys.databases";
                dal.Get_Data(query);
                if (dal.server_validation != "")
                {
                    lbl_Server_Validation.Text = dal.server_validation;
                }
                if (dal.user_validation != "")
                {
                    lbl_Server_Validation.Text = dal.user_validation;
                }
                    
                cmb_Database.DataSource = dal.lst_data;
                cmb_Database.Visible = lbl_Database.Visible = true;
            }
            Btn_Start.Enabled = true;
        }

        private void chk_authentication_CheckedChanged(object sender, EventArgs e)
        {
            lbl_UserId.Enabled = txt_UserId.Enabled = lbl_Password.Enabled = txtPassword.Enabled = chk_authentication.Checked ? false : true;
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            Btn_Start.Enabled = false;
            lbl_Progress.Visible = true;
            obj_authenticate.Database_Validation = lbl_ImportFile.Text = fileVerifyMessage = "";
            obj_authenticate.Database = cmb_Database.Text;
            if (txtFile.Text == "")
            {
                lbl_ImportFile.Text = "Please Select CSV File";
            }
            database_name = obj_authenticate.Database;
            obj_validate.Database_Validation(obj_authenticate);
            lblDatabase_Validation.Text = obj_authenticate.Database_Validation;
            Btn_Start.Enabled = true;

            updated_filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Updated_CSV.csv";
            if (updated_filePath != null && lbl_ImportFile.Text == "" && lblDatabase_Validation.Text == "" && File.Exists(updated_filePath))
            {
                dal = new DAL();
                //dal.Close_CSV_File();

                dal.Add_To_List(file_path, lst_sampled_data);
                dal.Add_To_List(updated_filePath, lst_updated_data);
                lbl_Progress.Text = "CSV File is being Verified....";

                try
                {
                    if (obj_authenticate.File_Validation == "" || obj_authenticate.File_Validation == null)
                    {
                        for (int x = 0; x <= lst_updated_data.Count; x++)
                        {
                            if (lst_updated_data[x] != lst_sampled_data[x])
                            {
                                fileVerifyMessage = "Column" + " " + x + " " + lst_updated_data[x] + " " + "is different";
                                MessageBox.Show(fileVerifyMessage);
                            }
                        }
                    }
                    else
                    {
                        lbl_ImportFile.Text = obj_authenticate.File_Validation;
                    }
                }
                catch { }


                if (fileVerifyMessage == "")
                {
                    lbl_Progress.Text = "";
                    MessageBox.Show("CSV File Verified Successfully!");
                    //insert data to database
                    obj_thread = new Thread(Import_Data);
                    obj_thread.Start();                
                }
            }
            if(!File.Exists(updated_filePath)) { MessageBox.Show("Updated CSV File Not found at given directory" + " " + updated_filePath); } 
        }


        public void Import_Data()
        {
            if (File.Exists(updated_filePath))
            {
                try
                {
                    reader = new StreamReader(File.OpenRead(updated_filePath));
                }catch
                {
                    MessageBox.Show("File is Opened. Please Close CSV File"); 
                }
                reader.ReadLine();
                row_count = (File.ReadAllLines(updated_filePath).Length) - 1;

                this.Invoke(new MethodInvoker(delegate
                {
                    progressBar.Visible = true;
                    progressBar.Maximum = row_count;
                }));

                while (!reader.EndOfStream)
                {
                    var values = reader.ReadLine().Split(',');
                    foreach (var item in values)
                    {
                       lst_insert.Add(item);
                    }

                    var Death_Time = lst_insert[49];
                    obj_validate.Time_Validation(Death_Time);
                    Death_Time = Validations.time;
                      
                    var Admission_Time = lst_insert[4];
                    obj_validate.Time_Validation(Admission_Time);
                    Admission_Time = Validations.time;
                     
                    var Pre_Arrival_NotificationTime = lst_insert[27];
                    obj_validate.Time_Validation(Pre_Arrival_NotificationTime);
                    Pre_Arrival_NotificationTime = Validations.time;

                    var Symptom_OnsetTime = lst_insert[22];
                    obj_validate.Time_Validation(Symptom_OnsetTime);
                    Symptom_OnsetTime = Validations.time;

                    var Team_Activation_Time = lst_insert[54];
                    obj_validate.Time_Validation(Team_Activation_Time);
                    Team_Activation_Time = Validations.time;
                       
                    var Arrival_Time = lst_insert[83];
                    obj_validate.Time_Validation(Arrival_Time);
                    Arrival_Time = Validations.time;

                    var Admit_Time = lst_insert[41];
                    obj_validate.Time_Validation(Admit_Time);
                    Admit_Time = Validations.time;
                      
                        var Discharge_Time = lst_insert[43];
                        obj_validate.Time_Validation(Discharge_Time);
                         Discharge_Time = Validations.time;
                       
                        var Service_Time = lst_insert[20];
                        obj_validate.Time_Validation(Service_Time);
                        Service_Time = Validations.time;
                     
                        var ECG_Time = lst_insert[31];
                        obj_validate.Time_Validation(ECG_Time);
                        ECG_Time = Validations.time;

                        var Emergency_DischTime = lst_insert[36];
                        obj_validate.Time_Validation(Emergency_DischTime);
                        Emergency_DischTime = Validations.time;

                        var FirstDeviceActivationTime = lst_insert[84];
                        obj_validate.Time_Validation(FirstDeviceActivationTime);
                        FirstDeviceActivationTime = Validations.time;

                        var EMS1stContactTime = lst_insert[101];
                        obj_validate.Time_Validation(EMS1stContactTime);
                        EMS1stContactTime = Validations.time;

                        var DoseStartTime = lst_insert[75];
                        obj_validate.Time_Validation(DoseStartTime);
                        DoseStartTime = Validations.time;
                        
                        var Surgeon_Called_Time = lst_insert[59];
                        obj_validate.Time_Validation(Surgeon_Called_Time);
                        Surgeon_Called_Time = Validations.time;
                        
                        var Surgeon_Time_Arrived = lst_insert[61];
                        obj_validate.Time_Validation(Surgeon_Time_Arrived);
                        Surgeon_Time_Arrived = Validations.time;

                        var Consultation_Time = lst_insert[68];
                        obj_validate.Time_Validation(Consultation_Time);
                        Consultation_Time = Validations.time; 

                    try
                    {
                        dal = new DAL();
                        string patient_insertion = "Insert into Patient(AdmissionDate,AdmissionTime,LastName,FirstName, MiddleName, City, PatientCounty, State, PostCode, Country, DOB, Gender,Race,Ethnicity,Age,AgeUnits,DeathDate,DeathTime,DeathCircumstance,DeathCause,SymptomOnsetDate,SymptomOnsetTime, StressTesting,FirstEvaluationLocation, ReperfusionCandidate, ReperfusionReason, AdvancedNotification,PreArrivalNotificationDate,PreArrivalNotificationTime, FacilityName, IncidentNumber, TransportMode) values(" + (lst_insert[3] == "" || lst_insert[3] == "N/A" ? "NULL" : "CAST('" + lst_insert[3] + "' AS DATE)") + ", '" + Admission_Time + "', '" + lst_insert[5] + "', '" + lst_insert[6] + "', '" + lst_insert[7] + "', '" + lst_insert[8] + "', '" + lst_insert[9] + "', '" + lst_insert[10] + "', '" + lst_insert[11] + "', '" + lst_insert[12] + "', '" + lst_insert[13] + "', '" + lst_insert[14] + "', '" + lst_insert[15] + "', '" + lst_insert[16] + "', '" + lst_insert[17] + "', '" + lst_insert[18] + "'," + (lst_insert[48] == "N/A" || lst_insert[48] == "" ? "NULL" : "CAST('" + lst_insert[48] + "' AS DATE)") + ", '" + Death_Time + "', '" + lst_insert[50] + "', '" + lst_insert[80] + "', " + (lst_insert[21] == "" || lst_insert[21] == "N/A" ? "NULL" : "CAST('" + lst_insert[21] + "' AS DATE)") + ", '" + Symptom_OnsetTime + "', '" + lst_insert[19] + "', '" + lst_insert[29] + "', '" + lst_insert[69] + "', '" + lst_insert[70] + "', '" + lst_insert[25] + "'," + (lst_insert[26] == "" || lst_insert[26] == "N/A" ? "NULL" : "CAST('" + lst_insert[26] + "' AS DATE)") + " , '" + Pre_Arrival_NotificationTime + "', '" + lst_insert[0] + "', '" + lst_insert[1] + "', '" + lst_insert[24] + "')";
                        dal.OpenConnection();

                        //Transaction Begins
                        transaction = dal.connection.BeginTransaction();
                        SqlCommand cmd = new SqlCommand(patient_insertion, dal.connection, transaction);
                        dal.command.Transaction = transaction;
                        cmd.ExecuteNonQuery();

                        string Patient_Id = "Select max(PatientID) From Patient";
                        dal.ExecuteScalar(Patient_Id);

                        string CathLab_History_Insertion = "Insert into CathLabHistory(PatientID, TeamActivationDate, TeamActivationTime,TeamActivation, ArrivalDate, ArrivalTime) values('"+dal.Id+"', " + (lst_insert[53] == "" || lst_insert[53] == "N/A" ? "NULL" : "CAST('" + lst_insert[53] + "' AS DATE)") + ", '" + Team_Activation_Time + "', '" + lst_insert[51] + "', " + (lst_insert[82] == "" || lst_insert[82] == "N/A" ? "NULL" : "CAST('" + lst_insert[82] + "' AS DATE)") + ", '" + Arrival_Time + "')";
                        dal.ExecuteQuery(CathLab_History_Insertion);

                        string Hospital_insertion = "Insert into PatientHospital values('" + dal.Id + "', " + (lst_insert[40] == "" || lst_insert[40] == "N/A" ? "NULL" : "CAST('" + lst_insert[40] + "' AS DATE)") + ", '" + Admit_Time + "', " + (lst_insert[42] == "" || lst_insert[42] == "N/A" ? "NULL" : "CAST('" + lst_insert[42] + "' AS DATE)") + ", '" + Discharge_Time + "', '" + lst_insert[44] + "', '" + lst_insert[45] + "', '" + lst_insert[46] + "', '" + lst_insert[28] + "', " + (lst_insert[78] == "" || lst_insert[78] == "N/A" ? "NULL" : "CAST('" + lst_insert[78] + "' AS DATE)") + ", '" + Service_Time + "')";
                        dal.ExecuteQuery(Hospital_insertion);

                        string Consultation_Hist_Insertion = "Insert into ConsultationHistory(PatientID, ConsultingService, ServiceTimelyArrival, ServiceType, Staff, ServiceDate, ServiceTime) values('" + dal.Id + "', '" + lst_insert[63] + "', '" + lst_insert[64] + "', '" + lst_insert[65] + "', '" + lst_insert[66] + "', " + (lst_insert[67] == "" || lst_insert[67] == "N/A" ? "NULL" : "CAST('" + lst_insert[67] + "' AS DATE)") + ", '" + Consultation_Time + "')";
                        dal.ExecuteQuery(Consultation_Hist_Insertion);

                        string ECG_History_Insertion = "Insert into ECGHistory(PatientID, FirstECGDate,FirstECGTime,NotedOn,SubsequentWithMIDate,SubSequentWithMITime) values('" + dal.Id + "', " + (lst_insert[30] == "" || lst_insert[30] == "N/A" ? "NULL" : "CAST('" + lst_insert[30] + "' AS DATE)") + ", '" + ECG_Time + "', '" + lst_insert[32] + "', '" + lst_insert[33] + "', '" + lst_insert[34] + "')";
                        dal.ExecuteQuery(ECG_History_Insertion);

                        string Emergency_Dept = "Insert into EmergencyDepartment(PatientID, DischargeDate, DischargeTime, Deposition, DischargeTransportMode, DestinationDetermination, Physician, PhysicianServiceType, MITeamActivatedBy, AdvancedDirective) values('" + dal.Id + "', " + (lst_insert[35] == "" || lst_insert[35] == "N/A" ? "NULL" : "CAST('" + lst_insert[35] + "' AS DATE)") + ", '" + Emergency_DischTime + "', '" + lst_insert[37] + "', '" + lst_insert[38] + "', '" + lst_insert[39] + "', '" + lst_insert[55] + "', '" + lst_insert[56] + "', '" + lst_insert[52] + "', '" + lst_insert[102] + "')";
                        dal.ExecuteQuery(Emergency_Dept);

                        string EMS_History = "Insert into EMSHistory(PatientID, NonEMSFirstMedicalContactDate, NonEMSFirstMedicalContactTimeEstimate, EMS1stContactDate, EMS1stContactTime, NonEMSCardiacArrest) values('" + dal.Id + "', " + (lst_insert[98] == "" || lst_insert[98] == "N/A" ? "NULL" : "CAST('" + lst_insert[98] + "' AS DATE)") + ", '" + lst_insert[99] + "', " + (lst_insert[100] == "" || lst_insert[100] == "N/A" ? "NULL" : "CAST('" + lst_insert[100] + "' AS DATE)") + ", '" + EMS1stContactTime + "', '" + lst_insert[90] + "')";
                        dal.ExecuteQuery(EMS_History);

                        string MedicationHistory = "Insert into MedicationHistory(PatientID, AntiThrombolicMedication, AsprinAtHome, AsprinInFirst24hrs, AsprinAtDischarge, BetaBlockerAtDischarge, StatinAtDischarge, StatinAtDischargeDose) values('" + dal.Id + "', '" + lst_insert[91] + "', '" + lst_insert[92] + "', '" + lst_insert[93] + "', '" + lst_insert[94] + "', '" + lst_insert[95] + "', '" + lst_insert[96] + "', '" + lst_insert[97] + "')";
                        dal.ExecuteQuery(MedicationHistory);

                        string PCI_History = "Insert into PCIHistory values('" + dal.Id + "', '" + lst_insert[71] + "', '" + lst_insert[72] + "', '" + lst_insert[81] + "', '" + lst_insert[86] + "', '" + lst_insert[87] + "', '" + lst_insert[88] + "', '" + lst_insert[79] + "', '" + lst_insert[77] + "', '" + lst_insert[89] + "', '" + FirstDeviceActivationTime + "', " + (lst_insert[85] == "" || lst_insert[85] == "N/A" ? "NULL" : "CAST('" + lst_insert[85] + "' AS DATE)") + ")";
                        dal.ExecuteQuery(PCI_History);

                        string ThrombolyticsHistory = "Insert into ThrombolyticsHistory values('" + dal.Id + "', '" + lst_insert[73] + "', " + (lst_insert[74] == "" || lst_insert[74] == "N/A" ? "NULL" : "CAST('" + lst_insert[74] + "' AS DATE)") + ", '" + DoseStartTime + "', '" + lst_insert[76] + "')";
                        dal.ExecuteQuery(ThrombolyticsHistory);

                        string TruamaHistory = "Insert into TruamaHistory values('" + dal.Id + "', " + (lst_insert[57] == "" || lst_insert[57] == "N/A" ? "NULL" : "CAST('" + lst_insert[57] + "' AS DATE)") + ", '" + Surgeon_Called_Time + "', " + (lst_insert[60] == "" || lst_insert[60] == "N/A" ? "NULL" : "CAST('" + lst_insert[60] + "' AS DATE)") + ", '" + Surgeon_Time_Arrived + "', '" + lst_insert[62] + "')";
                        dal.ExecuteQuery(TruamaHistory);
                        
                        rows_completed += 1;
                        
                        this.Invoke(new MethodInvoker(delegate
                        {    
                            lbl_Progress.Text = rows_completed + " " + "out of" + " " + row_count + " " + "Rows Inserted Successfully!";
                            Show_Progress();
                        }));
                        current_row += 1;
                        lst_insert.Clear();
                       //Commit Transaction
                        transaction.Commit();
                        dal.CloseConnection();
                    }                   
                    catch (Exception error)
                    {
                        lst_insert.Clear();
                        //Roll Back Transactions
                        transaction.Rollback();
                        MessageBox.Show("Transaction was Rolled Back" + error.Message);                     
                    }
                }                              
            }
            
            MessageBox.Show(rows_completed + " " + "out of" + " " + row_count + " " + "Rows Inserted Successfully!");
            progress = row_count = rows_completed =  current_row = 0;
            Btn_Start.Enabled = true;
            this.Invoke(new MethodInvoker(delegate
            {
                 lbl_Progress.Visible = false;
                 progressBar.Visible = false;
           }));       
        }


        public void Show_Progress()
        { 
            try
            {
                progressBar.Value = (current_row * progressBar.Maximum) / row_count; 
                progress = progressBar.Value;  
            }
            catch
            {                   
                progressBar.Value = 100;                               
            }
        }
    }
}
