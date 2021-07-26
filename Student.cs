using System;

namespace ExceptionHandlingTask
{
    public class Student
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string RoomNumber { get; set; }
        public DateTime DateEntered { get; set; }
        public DateTime DateLeft { get; set; }
        public TimeSpan TimeStayed { get; set; }

        public Student (string FName, string LName, string RoomNumber, DateTime DateEntered, DateTime DateLeft)
        {
            this.FName = FName;
            this.LName = LName;
            this.RoomNumber = RoomNumber;
            this.DateEntered = DateEntered;
            this.DateLeft = DateLeft;
            this.TimeStayed = this.DateLeft.Subtract(this.DateEntered);
        }
        public void PrintInfo()
        {
            Console.WriteLine("{0} {1} entered room {2} at {3} and left at {4}. They stayed for {5}", 
            this.FName, this.LName, this.RoomNumber, this.DateEntered, this.DateLeft, this.TimeStayed);
        }
    }
}