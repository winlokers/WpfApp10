using System;

namespace WpfApp10
{
    public class Student
    {
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public double Heigth { get; set; }
        public double Weigth { get; set; }

        public Group Group { get; set; }
    }
}