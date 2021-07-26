using System;
using System.Collections.Generic;

namespace ExceptionHandlingTask
{
    class Program
    {
        public static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            int input;

            while (true)
            {
                input = GetMenuInput();
                if (input != 3)
                {
                    switch (input)
                    {
                        case 1:
                            CreateStudentEntry();
                            break;
                        case 2:
                            PrintAllStudentInfo();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Exiting....");
                    break;
                }
            }
        }


        public static int GetMenuInput()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Classroom Entry Program");
            Console.WriteLine("1. Enter new student info");
            Console.WriteLine("2. Print all student info");
            Console.WriteLine("3. Exit");
            Console.Write("Enter a menu number: ");

            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid! Must enter a number");
                Console.Write("Enter a menu number: ");
            }

            return number;
        }
        public static void CreateStudentEntry()
        {
            string FName;
            string LName;
            string RoomNo;
            DateTime DateEntered;
            DateTime DateLeft;

            Console.WriteLine("---------------------------------");
            Console.Write("Enter student's first name: ");
            FName = Console.ReadLine();

            Console.Write("Enter student's last name: ");
            LName = Console.ReadLine();

            Console.Write("Enter the room the student entered (e.g TD224): ");
            RoomNo = Console.ReadLine();

            Console.Write("Enter the date and time the student ENTERED the room (e.g YYYY/MM//DD HH:MM:SS): ");
            DateEntered = CheckValidDateTime();

            Console.Write("Enter the date and time the student LEFT the room (e.g YYYY/MM//DD HH:MM:SS): ");
            DateLeft = CompareDateTime(DateEntered);

            Console.WriteLine("Student info successfully entered!");
            students.Add(new Student(FName, LName, RoomNo, DateEntered, DateLeft));
        }

        public static DateTime CheckValidDateTime()
        {
            DateTime dateTime = new DateTime();
            bool validDateTIme = false;

            while (!validDateTIme)
            {
                string input = Console.ReadLine();

                try
                {
                    dateTime = DateTime.Parse(input);
                    validDateTIme = true;
                }
                catch
                {
                    Console.Write("Invalid date time format, try again: ");
                }
            }
            return dateTime;
        }
        public static DateTime CompareDateTime(DateTime t1)
        {
            bool validDateTime = false;
            DateTime t2 = new DateTime();

            while (!validDateTime)
            {
                t2 = CheckValidDateTime();

                int result = DateTime.Compare(t1, t2);
                if (result >= 0)
                {
                    Console.Write("Invalid! Date left must be AFTER date entered, try again: ");
                }
                else
                {
                    validDateTime = true;
                }
            }
            return t2;
        }
        private static void PrintAllStudentInfo()
        {
            if (students.Count > 0)
            {
                foreach (Student s in students)
                {
                    s.PrintInfo();
                }
            }
            else
            {
                Console.WriteLine("There is currently no student info in the system");
            }
        }
    }
}
