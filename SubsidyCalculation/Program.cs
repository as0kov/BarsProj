using System;

namespace SubsidyCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var sub = new SubsidyCalculator();
            sub.OnNotify += NotificationHandler;
            sub.OnException += ExceptionHandler;

            var res = sub.CalculateSubsidy(
                new Volume(3, 3, new DateTime(2020, 04, 15), 30),
                new Tariff(3, 3, new DateTime(2020, 04, 12), new DateTime(2020, 05, 12), 3));

            if (res != null) Console.WriteLine($"Субсидия: {res.Value}");
        }

        static void ExceptionHandler(object sender, Tuple<string, Exception> e)
        {
            Console.WriteLine($"ERROR: {e}");
        }

        static void NotificationHandler(object sender, string e)
        {
            Console.WriteLine($"NOTIFY: {e}");
        }
    }
}
