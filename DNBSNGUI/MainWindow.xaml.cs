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
        }

        private void kolkataBtn_Click(object sender, RoutedEventArgs e)
        {
            mapWb.NavigateToString("<html><body><iframe src=\"https://maps.google.co.in/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=kolkata+&amp;aq=&amp;sll=22.356426,88.211975&amp;sspn=0.779817,1.560059&amp;t=h&amp;ie=UTF8&amp;hq=&amp;hnear=Kolkata,+West+Bengal&amp;ll=22.356426,88.211975&amp;spn=24.657494,49.921875&amp;z=5&amp;output=embed\" width=\"1100\" height=\"480\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\">Loading...</iframe></body></html>");
        }

        private void gcalenderBtn_Click(object sender, RoutedEventArgs e)
        {
            gCalenderWb.NavigateToString("<html><body><iframe src=\"https://www.google.com/calendar/feeds/an.anirban%40gmail.com/public/basic\" width=\"1100\" height=\"480\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\">Loading...</iframe></body></html>");
            //<iframe src="https://www.google.com/calendar/embed?src=an.anirban%40gmail.com&ctz=Asia/Calcutta" style="border: 0" width="800" height="600" frameborder="0" scrolling="no"></iframe>
        }
    }
}
