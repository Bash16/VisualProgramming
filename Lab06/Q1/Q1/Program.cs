using System;

namespace Q1
{
    public enum Department
    {
        CS,
        BBA
    }
    public class Person
    {
        protected string name;
        public Person()
        {
            name = null;
        }
        public Person(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
    public class Student : Person
    {
        protected string regNo;
        protected int age;
        protected Department program;
        public Student()
        {
            regNo = null;
            age = 0;
            program = 0;
        }
        public Student(string name, string regNo, int age, Department program)
        {
            this.name = name;
            this.regNo = regNo;
            this.age = age;
            this.program = program;
        }
        public string RegNo
        {
            get { return regNo; }
            set { regNo = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public Department Program
        {
            get { return program; }
            set { program = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Student object
            Student student1 = new Student("John Doe", "2023001", 20, Department.CS);

            Console.WriteLine("Student Information:");
            Console.WriteLine($"Name: {student1.Name}");
            Console.WriteLine($"Registration Number: {student1.RegNo}");
            Console.WriteLine($"Age: {student1.Age}");
            Console.WriteLine($"Program: {student1.Program}");

            // Create another Student object
            Student student2 = new Student("Alice Smith", "2023002", 21, Department.BBA);

            Console.WriteLine("\nStudent Information:");
            Console.WriteLine($"Name: {student2.Name}");
            Console.WriteLine($"Registration Number: {student2.RegNo}");
            Console.WriteLine($"Age: {student2.Age}");
            Console.WriteLine($"Program: {student2.Program}");
        }
    }
}