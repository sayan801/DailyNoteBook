using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DNBSNData;

namespace DNBSNDb
{
    public class DbInteraction
    {
        static string passwordCurrent = "technicise";
        static string dbmsCurrent = "dnbsndb";

        private static MySql.Data.MySqlClient.MySqlConnection OpenDbConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;

            msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");

            //open the connection
            if (msqlConnection.State != System.Data.ConnectionState.Open)
                msqlConnection.Open();

            return msqlConnection;
        }

        #region User

        public static int DoRegisterNewUser(UserInfo NewUser)
        {
            return DoRegisterNewuserindb(NewUser);
        }

        private static int DoRegisterNewuserindb(UserInfo NewUser)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO user(id,userid,passwrd,hints) " + "VALUES(@id,@userid,@passwrd,@hints)";

                msqlCommand.Parameters.AddWithValue("@id", NewUser.id);
                msqlCommand.Parameters.AddWithValue("@userid", NewUser.userId);
                msqlCommand.Parameters.AddWithValue("@passwrd", NewUser.pass);
                msqlCommand.Parameters.AddWithValue("@hints", NewUser.hints);


                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        #endregion

        #region Note

        public static int DoEnterNewNote(NoteInfo NewNote)
        {
            return DoEnterNewNoteindb(NewNote);
        }

        private static int DoEnterNewNoteindb(NoteInfo NewNote)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO note(id,date,note) " + "VALUES(@id,@date,@note)";

                msqlCommand.Parameters.AddWithValue("@id", NewNote.id);
                msqlCommand.Parameters.AddWithValue("@date", NewNote.gotoDate);
                msqlCommand.Parameters.AddWithValue("@note", NewNote.note);
                


                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<NoteInfo> GetAllNoteList()
        {
            return QueryAllNoteList();
        }
        private static List<NoteInfo> QueryAllNoteList()
        {
            List<NoteInfo> NoteList = new List<NoteInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From note ;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    NoteInfo Note = new NoteInfo();

                    //Note.id = msqlReader.GetString("id");
                    Note.noteDate = msqlReader.GetDateTime("date");
                    Note.note = msqlReader.GetString("note");

                    NoteList.Add(Note);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return NoteList;
        }
        
        #endregion

        #region ID password

        public static string FetcheId()
        {

            string idStr = string.Empty;

            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {


                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;


                msqlCommand.CommandText = "Select userid from user;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                msqlReader.Read();

                idStr = msqlReader.GetString("userid");

            }
            catch (Exception er)
            {
                //Assert//.Show(er.Message);
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return idStr;
        }

        public static string FetchePassword()
        {

            string passwordStr = string.Empty;

            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {


                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;


                msqlCommand.CommandText = "Select passwrd from user;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                msqlReader.Read();

                passwordStr = msqlReader.GetString("passwrd");

            }
            catch (Exception er)
            {
                //Assert//.Show(er.Message);
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return passwordStr;
        }
        #endregion

        #region Contact


        public static int DoRegisterNewContact(ContactInfo contactDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO contact(id,name,mobile,homePhone,officePhone,email,address,faxNumber,remark) "
                                                   + "VALUES(@id,@name,@mobile,@homePhone,@officePhone,@email,@address,@faxNumber,@remark)";

                msqlCommand.Parameters.AddWithValue("@id", contactDetails.id);
                msqlCommand.Parameters.AddWithValue("@name", contactDetails.name);
                msqlCommand.Parameters.AddWithValue("@mobile", contactDetails.mobileno);
                msqlCommand.Parameters.AddWithValue("@homePhone", contactDetails.homeno);
                msqlCommand.Parameters.AddWithValue("@officePhone", contactDetails.oficeno);
                msqlCommand.Parameters.AddWithValue("@email", contactDetails.email);
                msqlCommand.Parameters.AddWithValue("@address", contactDetails.address);
                msqlCommand.Parameters.AddWithValue("@faxNumber", contactDetails.faxno);
                msqlCommand.Parameters.AddWithValue("@remark", contactDetails.remark);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }


        public static List<ContactInfo> GetAllContactList()
        {
            return QueryAllContactList();
        }
        private static List<ContactInfo> QueryAllContactList()
        {
            List<ContactInfo> ContactList = new List<ContactInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From contact ;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ContactInfo Contact = new ContactInfo();

                    Contact.id = msqlReader.GetString("id");
                    Contact.name = msqlReader.GetString("name");
                    Contact.mobileno = msqlReader.GetString("mobile");
                    Contact.homeno = msqlReader.GetString("homePhone");
                    Contact.oficeno = msqlReader.GetString("officePhone");
                    Contact.email = msqlReader.GetString("email");
                    Contact.address = msqlReader.GetString("address");
                    Contact.faxno = msqlReader.GetString("faxNumber");
                    Contact.remark = msqlReader.GetString("remark");

                    
                    ContactList.Add(Contact);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return ContactList;
        }


        #region delete Contact

        public static void DeleteContact(string contactToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM contact WHERE id=@contactToDelete";
                msqlCommand.Parameters.AddWithValue("@contactToDelete", contactToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #endregion

        #region Task


        public static int DoRegisterNewTask(TaskInfo TaskDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO task(taskId,priority,details) "
                                                   + "VALUES(@taskId,@priority,@details)";

                msqlCommand.Parameters.AddWithValue("@taskId", TaskDetails.id);
                msqlCommand.Parameters.AddWithValue("@priority", TaskDetails.value);
                msqlCommand.Parameters.AddWithValue("@details", TaskDetails.taskDetails);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }



        public static List<TaskInfo> GetAllTaskList()
        {
            return QueryAllTaskList();
        }
        private static List<TaskInfo> QueryAllTaskList()
        {
            List<TaskInfo> TaskList = new List<TaskInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From task;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    TaskInfo Task = new TaskInfo();

                    Task.id = msqlReader.GetString("taskId");
                    Task.value = msqlReader.GetString("priority");
                    Task.taskDetails = msqlReader.GetString("details");
                    

                    TaskList.Add(Task);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return TaskList;
        }

        


        #endregion

        #region Password Manager


        public static int DoRegisterNewPassword(PasswordInfo passwordDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO password(id,name,email,userId,password,secretQuestion,secretAnswer,otherInfo) "
                                                   + "VALUES(@id,@name,@email,@userId,@password,@secretQuestion,@secretAnswer,@otherInfo)";

                msqlCommand.Parameters.AddWithValue("@id", passwordDetails.id);
                msqlCommand.Parameters.AddWithValue("@name", passwordDetails.name);
                msqlCommand.Parameters.AddWithValue("@email", passwordDetails.email);
                msqlCommand.Parameters.AddWithValue("@userId", passwordDetails.userId);
                msqlCommand.Parameters.AddWithValue("@password", passwordDetails.password);
                msqlCommand.Parameters.AddWithValue("@secretQuestion", passwordDetails.scrtqstn);
                msqlCommand.Parameters.AddWithValue("@secretAnswer", passwordDetails.scrtans);
                msqlCommand.Parameters.AddWithValue("@otherInfo", passwordDetails.otherInfo);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }


        public static List<PasswordInfo> GetAllPasswordsList()
        {
            return QueryAllPasswordList();
        }
        private static List<PasswordInfo> QueryAllPasswordList()
        {
            List<PasswordInfo> PasswordList = new List<PasswordInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From password ;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    PasswordInfo Password = new PasswordInfo();

                    Password.id = msqlReader.GetString("id");
                    Password.name = msqlReader.GetString("name");
                    Password.email = msqlReader.GetString("email");
                    Password.userId = msqlReader.GetString("userId");
                    Password.password = msqlReader.GetString("password");
                    Password.scrtqstn = msqlReader.GetString("secretQuestion");
                    Password.scrtans = msqlReader.GetString("secretAnswer");
                    Password.otherInfo = msqlReader.GetString("otherInfo");


                    

                    PasswordList.Add(Password);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return PasswordList;
        }

        #region Delete Password
        public static void DeletePassword(string passwordToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM password WHERE id=@passwordToDelete";
                msqlCommand.Parameters.AddWithValue("@passwordToDelete", passwordToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #endregion

        #region Go To Date / Search

        public static List<NoteInfo> searchNoteList(NoteInfo noteinfo)
        {
            return searchAllNoteList(noteinfo);
        }

        private static List<NoteInfo> searchAllNoteList(NoteInfo noteinfo)
        {
            List<NoteInfo> NoteList = new List<NoteInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "Select * From note where date = @date ; ";

                msqlCommand.Parameters.AddWithValue("@date", noteinfo.gotoDate);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    NoteInfo Note = new NoteInfo();

                    Note.noteDate = msqlReader.GetDateTime("date");
                    

                    NoteList.Add(Note);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return NoteList;
        }

        #endregion

        #region Monthly View

        public static List<NoteInfo> searchMnthlyNoteList(DateTime date)
        {
            DateTime day1st = new DateTime(date.Year, date.Month, 1);
            DateTime dayLast = new DateTime(date.Year, date.Month + 1, 1);
            dayLast = dayLast.Subtract(new TimeSpan(1, 0, 0, 0));
            List<NoteInfo> NoteList = new List<NoteInfo>();

            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "SELECT * FROM note where date(note.date) >= DATE_SUB( @dayLast, INTERVAL @diff DAY) group by date;";
                msqlCommand.Parameters.AddWithValue("@dayLast", dayLast);
                msqlCommand.Parameters.AddWithValue("@diff", dayLast.Subtract(day1st));
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    NoteInfo Note = new NoteInfo();

                    Note.noteDate = msqlReader.GetDateTime("date");
                    Note.note = msqlReader.GetString("note");

                    NoteList.Add(Note);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return NoteList;
        }

        #endregion


    
    }
}

