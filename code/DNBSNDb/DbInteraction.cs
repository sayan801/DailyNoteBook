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

                msqlCommand.CommandText = "INSERT INTO note(id,note) " + "VALUES(@id,@note)";

                msqlCommand.Parameters.AddWithValue("@id", NewNote.id);
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

                msqlCommand.CommandText = "INSERT INTO contact(contactId,name,mobile,homePhone,officePhone,email,address,faxNumber,remark) "
                                                   + "VALUES(@contactId,@name,@mobile,@homePhone,@officePhone,@email,@address,@faxNumber,@remark)";

                msqlCommand.Parameters.AddWithValue("@contactId", contactDetails.id);
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

                msqlCommand.CommandText = "INSERT INTO password(passwordId,name,email,userId,password,secretQuestion,secretAnswer,otherInfo) "
                                                   + "VALUES(@passwordId,@name,@email,@userId,@password,@secretQuestion,@secretAnswer,@otherInfo)";

                msqlCommand.Parameters.AddWithValue("@passwordId", passwordDetails.id);
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


        #endregion
    }
}

