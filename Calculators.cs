using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
 class Program
    {
        public static void IntputChecker(string s) { //Checking the user intput for int
            int temp = 0;
            while (!int.TryParse(s, out temp))
            {
                Console.WriteLine("Please enter valid numreical values ");
                s = Console.ReadLine();
            }
        }     
        
        private static int ToSeconds(int hours, int minutes, int seconds) { //Transforming and adding hours, minutes and seconds to secodns
            return ((hours * 3600) + (minutes * 60) + seconds);
        }

        private static void ToHoursMminsSecs(int seconds) {//Transforming given seconds to hours, minutes and seconds
        
            int hours = seconds / 3600;

            int SecondsLeft = (hours * 3600 - seconds);
            SecondsLeft *= -1;
            
            int minutes = (SecondsLeft / 60);
            
            int RemainingSeconds = (minutes * 60 - SecondsLeft);
            RemainingSeconds *= -1;

            Console.WriteLine("This is equal to " + hours + " hours, " + minutes + " minutes and " + (RemainingSeconds) + " seconds.");
        }

        public static void CountdownCalculator() {
            Console.WriteLine("Countdown Timer Calculator\n");
            
            Console.WriteLine("Enter the number of hours: ");
            string hours = Console.ReadLine() ;
            IntputChecker(hours);
            int Hours = int.Parse(hours);

            Console.WriteLine("Enter the number of minutes: ");
            string minutes = Console.ReadLine();
            IntputChecker(minutes);
            int Minutes = int.Parse(minutes);

            Console.WriteLine("Enter the number of seconds: ");
            string seconds = Console.ReadLine();
            IntputChecker(seconds);
            int Seconds = int.Parse(seconds);

            Console.WriteLine("Total number of seconds is: " + ToSeconds(Hours,Minutes,Seconds)); //Printing entered hours, minutes and seconds to seconds
            Console.ReadLine();
        }


        public static void ReverseCalculator() {
            Console.WriteLine("Reverse Countdown Calculator\n");
            Console.WriteLine("Enter the number of seconds: ");
            string seconds = Console.ReadLine();
            IntputChecker(seconds);
            int Seconds = int.Parse(seconds);
            ToHoursMminsSecs(Seconds);
            Console.ReadLine();
        }


        //-------------------------FAILED ATTEMPT---------------------------------
        //public static int GetYearDifference(DateTime startDate, DateTime endDate)
        //{

        //    int YearsApart = 365 * (startDate.Year - endDate.Year) + startDate.Year - endDate.Year;
        //    int Years = Math.Abs(YearsApart);
        //    int yearsToSeconds = Years * 365 * 12 * 30 * 24 * 60 * 60;
        //    return yearsToSeconds;
        //}

        //public static int GetMonthDifference(DateTime startDate, DateTime endDate){

        //    int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
        //    int months = Math.Abs(monthsApart);
        //    int monthsToSeconds = months * 30 * 24 * 60 * 60;
        //    return monthsToSeconds;
        //}

        //public static int GetDayDifference(DateTime startDate, DateTime endDate)
        //{

        //    int daysApart = 30 * (startDate.Day - endDate.Day) + startDate.Day - endDate.Day;
        //    int days = Math.Abs(daysApart);
        //    int daysToSeconds = days * 24 * 60 * 60;
        //    return daysToSeconds;
        //}
        //--------------------------------------------------------------------------------------

        public static void SecondsToEvent() {
            Console.WriteLine("Seconds to Calculator\n");

            Console.WriteLine("Enter the hour: ");
            string hour = Console.ReadLine();
            IntputChecker(hour);
            int Hour = int.Parse(hour);

            //DateTime EnteredHour = DateTime.Now;
            //DateTime pastHOUR = EnteredHour.AddHours(-25); //Failed attempt
            //int hourDiff = 

            Console.WriteLine("Enter the day: ");
            string day = Console.ReadLine();
            IntputChecker(day);
            int Day = int.Parse(day);

            //DateTime EnteredDay = DateTime.Now;
            //DateTime pastDAY = EnteredDay.AddDays(-Day); //Failed attempt
            //int dayDiff = GetDayDifference(EnteredDay, pastDAY);

            Console.WriteLine("Enter the month: ");
            string month = Console.ReadLine();
            IntputChecker(month);
            int Month = int.Parse(month);

            //DateTime EnteredMonth = DateTime.Now;
            //DateTime past = EnteredMonth.AddMonths(-Month);
            //int monthDiff = GetMonthDifference(EnteredMonth, past); //Failed Attempt

            Console.WriteLine("Enter the year: ");
            string year = Console.ReadLine();
            IntputChecker(year);
            int Year = int.Parse(year);

            //DateTime EnteredYear = DateTime.Now;
            //DateTime pastYear = EnteredYear.AddYears(-Year);
            //int YearDiff = GetYearDifference(EnteredYear, pastYear); //Failed Attempt

            //Console.WriteLine("The total number of seconds is: " +(dayDiff + monthDiff + YearDiff) + " seconds."); //Failed Attempt

            System.DateTime CurentDate = new System.DateTime(2018, 9, 1, 18, 0, 0, 0);
            System.DateTime EnteredDate = new System.DateTime(Year, Month, Day, Hour, 0, 0, 0);
            System.TimeSpan result = CurentDate.Subtract(EnteredDate);

            Console.WriteLine("Number of days left untill entered time from today is: " + result); //Gets the difference in days
            Console.ReadLine();

        }
        static void Main(string[] args) {

            CountdownCalculator();
            Console.Clear();
            ReverseCalculator();
            Console.Clear();
            SecondsToEvent();
        }
    }
}
