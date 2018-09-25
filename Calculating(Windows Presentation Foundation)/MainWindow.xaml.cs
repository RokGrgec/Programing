using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFn1
{
    
    
    public partial class MainWindow : Window
    {
        public static int ToSeconds(int minutes,int seconds, int hours) {
        return ((hours * 3600) + (minutes * 60) + seconds);
    }
        


        public MainWindow() {
            InitializeComponent();
        }


        private void calculateButton_Click(object sender, RoutedEventArgs e) {

            resultLabel.Content = "Calculate Clicked";
            try
            {
                int seconds = int.Parse(secondsTextBox.Text); 
                int minutes = int.Parse(minutesTextBox.Text);
                int hours = int.Parse(hoursTextBox.Text);

                resultTextBox.Text = ToSeconds(hours,minutes,seconds).ToString(); //Prints the result in the result textbox

            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid numerical values!");

            }
            

           

        }
        
    }
}
