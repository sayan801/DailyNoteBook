using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNBSNData
{
    public class LinkedInDetails
    {
        public string Appid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<string> updates;
        public DateTime lastLoginTime;
    }
    public class GoogleCalenderDetails
    {
        public string Appid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<string> updates;
        public DateTime lastLoginTime;
    }
    public class TwitterDetails
    {
        public string Appid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<string> updates;
        public DateTime lastLoginTime;
    }
    public class FacebookDetails
    {
        public string Appid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<string> updates;
        public DateTime lastLoginTime;
    }

    public class GoogleMapDetails
    {
        public string Appid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<string> updates;
        public DateTime lastLoginTime;
    }
    public class NoteDetails
    {
        public string Appid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<string> updates;
        public DateTime lastLoginTime;
        public bool isFbSynced;
        public bool isTwitterSynced;
        public bool isLinkedInSynced;
        public bool isGoogleCalenderSynced;
    }


    public class FacebookController
    {
        public List<FacebookDetails> fbs;
    }

    public class TwitterController
    {
        public List<TwitterDetails> twits;
    }
    public class LinkedInController
    {
        public List<LinkedInDetails> linkedin;
    }

    public class GoogleMapController
    {
        public List<GoogleMapDetails> map;
    }
    public class GoogleCalenderController
    {
        public List<GoogleCalenderDetails> calender;
    }

    public enum ReportType
    {
        Single,
        Daily,
        Weekly,
        Monthly,
        Quarterly,
        Yearly
    }

    public class ReportInfo
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public ReportType type { get; set; }
        public string description { get; set; }
    }

    public class DaliyNoteBookController
    {
        public List<NoteDetails> notes;
        public GoogleCalenderController GoogleCalenderController;
        public GoogleMapController GoogleMapController;
        public LinkedInController LinkedInController;
        public FacebookController FacebookController;
        public TwitterController TwitterController;
        public MemberManager MemberManager;
    }

    public class MemberInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public List<PreferenceInfo> prefs;
    }
    public class MemberManager
    {
        public List<MemberInfo> members;
    }
    public class PreferenceInfo
    {
        string name;
        string Description;
        DateTime date;
    }
}
