using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DNBSNData;
using DNBSNDb;
using System.Collections.ObjectModel;

using TweetSharp;
using System.Diagnostics;


namespace DNBSNGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {




        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += delegate { this.DragMove(); };
            FocusManager.SetFocusedElement(this, dNBSNUserIDTB);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fetchTaskData();
            fetchContactData();
            fetchPasswordData();
            fetchNoteData();


            for (int i = 1; i <= 30; i++)
                dateUG.Children.Add(new ShowEvent(i));
        }

        private void kolkataBtn_Click(object sender, RoutedEventArgs e)
        {
            mapWb.NavigateToString("<html><body><iframe src=\"https://maps.google.co.in/?ll=20.98352,82.752628&spn=43.617141,86.572266&t=h&z=4\" width=\"1100\" height=\"480\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\">Loading...</iframe></body></html>");
        }

        private void gcalenderBtn_Click(object sender, RoutedEventArgs e)
        {
            gCalenderWb.NavigateToString("<html><body><iframe src=\"https://www.facebook.com/connect/login_success.html#access_token=THE_TOKEN&expires_in=7180\" width=\"1100\" height=\"480\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\">Loading...</iframe></body></html>");
            // fb like url https://www.facebook.com/plugins/like.php?href=https://www.facebook.com/technicise\

        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void virtualKeyboardDateBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //private void maximizeBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    this.WindowState = WindowState.Maximized;
        //}

        private void passwordMLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((passwordMUserIdTB.Text.Equals("1")) && (passwordMPassBtnPB.Password.Equals("1")))
            {
                mainPassDP.IsEnabled = true;
                passwordMPassBtnPB.Password = string.Empty;
                loginpassPassExpndr.IsExpanded = false;
                loginpassPassExpndr.IsEnabled = false;
                loginpassPassExpndr.Header = "Logged In";
                loginpassPassExpndr.ToolTip = "Logged In";
                allDetailsExpndr.IsExpanded = true;
                logoutPassBtn.Content = "Logout";
                allDetailsExpndr.Header = "All Details";
                addpassInfoExpndr.Header = "Add Info";
                logoutPassBtn.IsEnabled = true;
            }
            else
            {
                //MessageBox.Show("Please Enter correct Password");
                //DNBSNGUI.ErrorMessage ErrorMessageObj = new DNBSNGUI.ErrorMessage();
                //ErrorMessageObj.ShowDialog();
                passwordMPassBtnPB.Password = string.Empty;
            }
        }

        private void logoutDnbsnBtn_Click(object sender, RoutedEventArgs e)
        {
            dNBSNUserIDTB.Text = string.Empty;
            dNBSNpassPB.Password = string.Empty;
            mainLeftExpndr.IsExpanded = false;
            mainLeftExpndr.IsEnabled = false;
            mainTabControl.IsEnabled = false;
            logoutDnbsnBtn.IsEnabled = false;
            logoutDnbsnBtn.Content = "";
            loginExpndr.IsExpanded = true;
            loginExpndr.IsEnabled = true;
            hntLginLbl.Content = "Login first to use Daily Note Book with Social Networking Updater";

            loginExpndr.Visibility = Visibility.Visible;
            loginExpndr.IsExpanded = true;
            dNBSNUserIDTB.Clear();
            dNBSNpassPB.Clear();


        }

        private void dNBSNLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (dNBSNUserIDTB.Text.Equals(DNBSNDb.DbInteraction.FetcheId()) && dNBSNpassPB.Password.Equals(DNBSNDb.DbInteraction.FetchePassword()))
            {
                mainLeftExpndr.IsEnabled = true;
                mainLeftExpndr.IsExpanded = true;
                dNBSNpassPB.Password = string.Empty;
                mainTabControl.IsEnabled = true;
                loginExpndr.IsEnabled = false;
                //loginExpndr.Header = "Logged In";
                //loginExpndr.IsExpanded = false;
                loginExpndr.Visibility = Visibility.Collapsed;
                logoutDnbsnBtn.IsEnabled = true;
                logoutDnbsnBtn.Content = "LOG OUT";
                logoutDnbsnBtn.ToolTip = "log out";
                hntLginLbl.Content = "";
            }
            else
            {
                //MessageBox.Show("Please Enter correct Password");
                //DNBSNGUI.ErrorMessage ErrorMessageObj = new DNBSNGUI.ErrorMessage();
                //ErrorMessageObj.ShowDialog();

                errorMsgLbl.Content = "Wrong User ID or Password";
                dNBSNpassPB.Password = string.Empty;
            }
        }

        private void logoutPassBtn_Click(object sender, RoutedEventArgs e)
        {
            mainPassDP.IsEnabled = false;
            passwordMPassBtnPB.Password = string.Empty;
            passwordMUserIdTB.Text = string.Empty;
            loginpassPassExpndr.IsExpanded = true;
            loginpassPassExpndr.IsEnabled = true;
            //loginpassPassExpndr.Header = "Logged In";
            //loginpassPassExpndr.ToolTip = "Logged In";
            allDetailsExpndr.IsExpanded = false;
            logoutPassBtn.Content = "Please Log In First";
            addpassInfoExpndr.Header = "Login To Add Info";
            allDetailsExpndr.Header = "Login To Show All Details";
            //allDetailsExpndr.Header = "All Details";
            //addInfoExpndr.Header = "Add Info";
            logoutPassBtn.IsEnabled = false;





            //mainLeftExpndr.IsEnabled = false;
            //mainLeftExpndr.IsExpanded = false;
            //dNBSNpassPB.Password = string.Empty;
            //mainTabControl.IsEnabled = false;
            //loginExpndr.IsEnabled = true;
            //loginExpndr.Header = "Logged In";
            //loginExpndr.IsExpanded = true;
        }

        private void createAcHp_Click(object sender, RoutedEventArgs e)
        {
            newAcExpndr.Visibility = Visibility.Visible;
            newAcExpndr.IsExpanded = true;

            loginExpndr.Visibility = Visibility.Collapsed;
            dNBSNNewUserIDTB.Clear();
            dNBSNNewPassPB.Clear();
            dNBSNNewRepassPB.Clear();
            dNBSNHintsTB.Clear();
            createErrorMsgLbl.Content = string.Empty;
        }

        private void goLogin_Click(object sender, RoutedEventArgs e)
        {
            newAcExpndr.Visibility = Visibility.Collapsed;


            loginExpndr.Visibility = Visibility.Visible;
            loginExpndr.IsExpanded = true;
            dNBSNUserIDTB.Clear();
            dNBSNpassPB.Clear();
            errorMsgLbl.Content = string.Empty;
            hintsMsgLbl.Content = string.Empty;
        }


        TwitterService service;
        OAuthRequestToken requestToken;

        private void launchTwitterAppButton_Click(object sender, RoutedEventArgs e)
        {
            // Pass your credentials to the service
            service = new TwitterService("rfeDMlcxMQSqDSdmXDT3A", "7ZUD4YtVqOfFJcCHwWz7q0qTFjcKyVGSNyN4ElCsZZE");

            // Step 1 - Retrieve an OAuth Request Token
            requestToken = service.GetRequestToken();

            // Step 2 - Redirect to the OAuth Authorization URL
            Uri uri = service.GetAuthorizationUri(requestToken);
            Process.Start(uri.ToString());
        }

        private void verifyTwitterApp_Click(object sender, RoutedEventArgs e)
        {
            // Step 3 - Exchange the Request Token for an Access Token            
            OAuthAccessToken access = service.GetAccessToken(requestToken, verificationCodeTxtBox.Text);

            // Step 4 - User authenticates using the Access Token
            service.AuthenticateWith(access.Token, access.TokenSecret);

            var tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
            foreach (var tweet in tweets)
            {
                tweetsTextBlock.Text += tweet.User.ScreenName + " says " + tweet.Text + "\n";
            }
        }

        private void dNBSSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!dNBSNNewUserIDTB.Text.Equals(string.Empty) &&
                !dNBSNNewPassPB.Password.Equals(string.Empty) &&
                !dNBSNNewRepassPB.Password.Equals(string.Empty) &&
                !dNBSNHintsTB.Text.Equals(string.Empty))
            {
                if (!dNBSNNewPassPB.Password.Equals(dNBSNNewRepassPB.Password))
                {

                    dNBSNNewPassPB.Clear();
                    dNBSNNewRepassPB.Clear();

                    createErrorMsgLbl.Content = "Please Enter same Password";

                }
                else
                {
                    DNBSNData.UserInfo newUser = new DNBSNData.UserInfo();

                    newUser.id = GenerateId();

                    newUser.userId = dNBSNNewUserIDTB.Text;
                    newUser.pass = dNBSNNewPassPB.Password;
                    newUser.hints = dNBSNHintsTB.Text;

                    DNBSNDb.DbInteraction.DoRegisterNewUser(newUser);

                    newAcExpndr.Visibility = Visibility.Collapsed;
                    loginExpndr.Visibility = Visibility.Visible;
                    loginExpndr.IsExpanded = true;
                    dNBSNUserIDTB.Clear();
                    dNBSNpassPB.Clear();

                }
            }
            else
            {
                createErrorMsgLbl.Content = "Correctly Enter Info ";

            }

        }

        private void previousDateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }


        #region Note

        private void saveNotesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!notesTB.Text.Equals(string.Empty) && !notesTB.Text.Equals("Start writing from here..."))
            {
                DNBSNData.NoteInfo newNote = new DNBSNData.NoteInfo();

                newNote.id = GenerateId();

                newNote.gotoDate = noteDateDP.SelectedDate.Value;
                newNote.note = notesTB.Text;

                DNBSNDb.DbInteraction.DoEnterNewNote(newNote);

                notesTB.Clear();
                noteSuccessMsgLvl.Content = "Event Submited";
                fetchNoteData();
            }


            else
            {
                noteSuccessMsgLvl.Content = "Please Enter Proper Note";
            }


        }

        private void clearFieldsBtn_Click(object sender, RoutedEventArgs e)
        {
            noteSuccessMsgLvl.Content = "";
            notesTB.Clear();
            noteSuccessMsgLvl.Content = "All Clear";
        }

        ObservableCollection<NoteInfo> _allnoteCollection = new ObservableCollection<NoteInfo>();


        public ObservableCollection<NoteInfo> allnoteCollection
        {
            get
            {
                return _allnoteCollection;
            }
        }

        private void fetchNoteData()
        {
            List<NoteInfo> notes = DbInteraction.GetAllNoteList();

            _allnoteCollection.Clear();

            foreach (NoteInfo note in notes)
            {
                _allnoteCollection.Add(note);
            }
        }



        private NoteInfo GetSelectedEventItem()
        {

            NoteInfo noteToDelete = null;

            if (allnoteView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                NoteInfo i = (NoteInfo)passView.SelectedItem;

                noteToDelete = _allnoteCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return noteToDelete;
        }
        #region Delete note
        private void dltevntBtnBtn_Click(object sender, RoutedEventArgs e)
        {
            NoteInfo noteToDelete = GetSelectedEventItem();
            if (noteToDelete != null)
            {
                _allnoteCollection.Remove(noteToDelete);
                DNBSNDb.DbInteraction.DeleteNote(noteToDelete.id);
                fetchNoteData();

            }
        }

        #endregion

     
        #endregion

       


       
        
        #region Password

        private void paswrdSave_Click(object sender, RoutedEventArgs e)
        {
            DNBSNData.PasswordInfo newPassword = new DNBSNData.PasswordInfo();

            newPassword.id = GenerateId();
            newPassword.name = passNameTB.Text;
            newPassword.email = emailforpassTB.Text;
            newPassword.userId = userIdTB.Text;
            newPassword.password = pawsrdTB.Text;
            newPassword.scrtqstn = scrtQstnTB.Text;
            newPassword.scrtans = secrtAnsTB.Text;
            newPassword.otherInfo = othersInfoTB.Text;


            DNBSNDb.DbInteraction.DoRegisterNewPassword(newPassword);
            passNameTB.Text = emailforpassTB.Text = userIdTB.Text = pawsrdTB.Text = scrtQstnTB.Text = secrtAnsTB.Text = othersInfoTB.Text = "";

            addpassInfoExpndr.IsExpanded = false;
            fetchPasswordData();
        }

        private void clearPassInfoFieldBtn_Click(object sender, RoutedEventArgs e)
        {
            passNameTB.Text = emailforpassTB.Text = userIdTB.Text = pawsrdTB.Text = scrtQstnTB.Text = secrtAnsTB.Text = othersInfoTB.Text = "";
        }

        ObservableCollection<PasswordInfo> _passwordCollection = new ObservableCollection<PasswordInfo>();


        public ObservableCollection<PasswordInfo> passwordCollection
        {
            get
            {
                return _passwordCollection;
            }
        }

        private void fetchPasswordData()
        {
            List<PasswordInfo> passwords = DbInteraction.GetAllPasswordsList();

            _passwordCollection.Clear();

            foreach (PasswordInfo password in passwords)
            {
                _passwordCollection.Add(password);
            }
        }

        private void refrshpsdwBtn_Click(object sender, RoutedEventArgs e)
        {
            fetchPasswordData();
        }


        private PasswordInfo GetSelectedPassItem()
        {

            PasswordInfo passwordToDelete = null;

            if (passView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                PasswordInfo i = (PasswordInfo)passView.SelectedItem;

                passwordToDelete = _passwordCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return passwordToDelete;
        }
        #region Delete Password
        private void delPassBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordInfo passwordToDelete = GetSelectedPassItem();
            if (passwordToDelete != null)
            {
                _passwordCollection.Remove(passwordToDelete);
                DNBSNDb.DbInteraction.DeletePassword(passwordToDelete.id);
                fetchContactData();

            }
        }

        #endregion
        #endregion

        #region Task

        private void addTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            DNBSNData.TaskInfo newTask = new DNBSNData.TaskInfo();

            newTask.id = GenerateId();
            newTask.value = taskValueCB.Text;
            newTask.taskDetails = taskDetailsTB.Text;

            DNBSNDb.DbInteraction.DoRegisterNewTask(newTask);

            taskValueCB.Text = taskDetailsTB.Text = "";
            fetchTaskData();
            tskxpndr.IsExpanded = false;

        }

        ObservableCollection<TaskInfo> _taskCollection = new ObservableCollection<TaskInfo>();


        public ObservableCollection<TaskInfo> taskCollection
        {
            get
            {
                return _taskCollection;
            }
        }

        private void fetchTaskData()
        {
            List<TaskInfo> tasks = DbInteraction.GetAllTaskList();

            _taskCollection.Clear();

            foreach (TaskInfo task in tasks)
            {
                _taskCollection.Add(task);
            }
        }

        private void refrshTskBtn_Click(object sender, RoutedEventArgs e)
        {
            fetchTaskData();
        }





        

        private TaskInfo GetSelectedTaskItem()
        {

            TaskInfo taskToDelete = null;

            if (taskView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                TaskInfo i = (TaskInfo)taskView.SelectedItem;

                taskToDelete = _taskCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return taskToDelete;
        }

        #region  Delete Task
        private void delTask_Click(object sender, RoutedEventArgs e)
        {
            TaskInfo taskToDelete = GetSelectedTaskItem();
            if (taskToDelete != null)
            {
                _taskCollection.Remove(taskToDelete);
                DNBSNDb.DbInteraction.DeleteTask(taskToDelete.id);
                fetchTaskData();
              

            }
        }
        #endregion

        #endregion

        #region Contact

        #region Add Contact
        private void saveContactBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!contactnameTB.Text.Equals(""))
            {
                DNBSNData.ContactInfo newContact = new DNBSNData.ContactInfo();

                newContact.id = GenerateId();
                newContact.name = contactnameTB.Text;
                newContact.mobileno = mobnoTB.Text;
                newContact.homeno = homnoTB.Text;
                newContact.oficeno = ofcNoTb.Text;
                newContact.faxno = faxNoTb.Text;
                newContact.address = addressTB.Text;
                newContact.remark = remrkTB.Text;
                newContact.email = emailTb.Text;


                DNBSNDb.DbInteraction.DoRegisterNewContact(newContact);
                contactnameTB.Text = mobnoTB.Text = homnoTB.Text = ofcNoTb.Text = faxNoTb.Text = addressTB.Text = remrkTB.Text = emailTb.Text = "";
                fetchContactData();
                contacXpndr.IsExpanded = false;
            }
            else
                errorContactmsgLbl.Content = "Enter Proper Info";

        }

        private void clearContactFieldBtn_Click(object sender, RoutedEventArgs e)
        {
            contactnameTB.Text = mobnoTB.Text = homnoTB.Text = ofcNoTb.Text = faxNoTb.Text = addressTB.Text = remrkTB.Text = emailTb.Text = "";
            errorContactmsgLbl.Content = "FIeld Cleared";
        }

        #endregion

        #region View Contact
        ObservableCollection<ContactInfo> _contactCollection = new ObservableCollection<ContactInfo>();


        public ObservableCollection<ContactInfo> contactCollection
        {
            get
            {
                return _contactCollection;
            }
        }

        private void fetchContactData()
        {
            List<ContactInfo> contacts = DbInteraction.GetAllContactList();

            _contactCollection.Clear();

            foreach (ContactInfo Contacts in contacts)
            {
                _contactCollection.Add(Contacts);
            }
        }

        private void contactrfrshBtn_Click(object sender, RoutedEventArgs e)
        {
            fetchContactData();
        }

        #endregion

        private ContactInfo GetSelectedContactItem()
        {

            ContactInfo contactToDelete = null;

            if (contactView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                ContactInfo i = (ContactInfo)contactView.SelectedItem;

                contactToDelete = _contactCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return contactToDelete;
        }

        #region Delete Contact
        private void contactDelBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactInfo contactToDelete = GetSelectedContactItem();
            if (contactToDelete != null)
            {
                _contactCollection.Remove(contactToDelete);
                DNBSNDb.DbInteraction.DeleteContact(contactToDelete.id);
                fetchContactData();

            }
        }
        #endregion

        #region search contact
        private void contactSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (searchContactTB.Text == "")
                fetchContactData();
            else
            {
                ContactInfo contactinfo = new ContactInfo();
                contactinfo.name = searchContactTB.Text;


                

                List<ContactInfo> contacts = DbInteraction.searchContactList(contactinfo);

                _contactCollection.Clear();

                foreach (ContactInfo Contacts in contacts)
                {
                    _contactCollection.Add(Contacts);
                }
            }

        }
        #endregion

        #endregion

        #region Go to Date
        private void goToDateBtn_Click(object sender, RoutedEventArgs e)
        {
            noteControlsTab.SelectedIndex = 1;
            NoteInfo noteinfo = new NoteInfo();
            noteinfo.gotoDate = goToDateDP.SelectedDate.Value;


            List<NoteInfo> notes = DbInteraction.searchNoteList(noteinfo);

            _allnoteCollection.Clear();

            foreach (NoteInfo note in notes)
            {
                _allnoteCollection.Add(note);
            }
        }
        #endregion

        private void monthlyViewTC_click(object sender, RoutedEventArgs e)
        {
            List<NoteInfo> months = DbInteraction.searchMnthlyNoteList( goToDateDP.SelectedDate.Value);

            _allnoteCollection.Clear();

            foreach (NoteInfo note in months)
            {
                _allnoteCollection.Add(note);
            }
        }

        
  
            
              
        
    }


}
