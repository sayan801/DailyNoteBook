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
using TweetSharp;
using System.Diagnostics;

namespace TwitterWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                tweetsTextBlock.Text += tweet.User.ScreenName + " says " +  tweet.Text + "\n";
            }
        }
    }
}
