using System;
using System.Text.RegularExpressions;

namespace Count_Down
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int countDown = 0;
                Console.WriteLine("Enter a positive numeric value:");
                var userEntry = Console.ReadLine();
                if (userEntry != null && userEntry.ToLower() == "exit") System.Environment.Exit(-1);
                if (!AssertEntryIsValid(userEntry)) ErrorSequence();
                countDown = ConvertEntryToInteger(userEntry);
                Console.Clear();
                do
                {
                    var divisibleStringValue = ReturnStringBasedOnDivisibleNumber(countDown);
                    Console.WriteLine(divisibleStringValue);
                    countDown -= 1;
                } while (countDown >= 1);
                EndSequence();
            }
        }

        private static void EndSequence()
        {
            Console.WriteLine("Press ENTER to continue Or Enter EXIT on next prompt to quit");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ErrorSequence()
        {
            Console.Beep();
            Console.WriteLine("invalid entry. Only numeric whole numbers are expected");
            Console.ReadKey();
        }

        private static string ReturnStringBasedOnDivisibleNumber(int convertedValue)
        {
            var divisibleByFive = ReturnStringAfterDivision(convertedValue, 5);
            var divisibleByThree = ReturnStringAfterDivision(convertedValue, 3);

            if (divisibleByFive && divisibleByThree) return "Testing";
            if (divisibleByFive) return "Agile";
            if (divisibleByThree) return "Software";
            return convertedValue.ToString();
        }

        private static bool AssertEntryIsValid(string entry)
        {
            var pattern = @"\D";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(entry);
            if (match.Success) return false;
            return true;
        }

        public static int ConvertEntryToInteger(string entry)
        {
            if (string.IsNullOrEmpty(entry))
            {
                Console.WriteLine("No Value was entered. Exit Application");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            return Int32.Parse(entry);
        }

        private static bool ReturnStringAfterDivision(int value, int division)
        {
            var remainder = value % division;

            switch (division)
            {
                case 5:
                    if (remainder == 0) return true;
                    break;

                case 3:
                    if (remainder == 0) return true;
                    break;

                default: return false;
            }
            return false;
        }
    }
}
