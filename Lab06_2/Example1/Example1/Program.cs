using System;

namespace Example1
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // IList<int> intList = new List<int>() {10, 20, 30, 40};
            // Or
            IList<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(20);
            intList.Add(30);
            intList.Add(40);

            IList<string> strList = new List<string>();
            strList.Add("one");
            strList.Add("two");
            strList.Add("three");
            strList.Add("four");
            strList.Add("four");
            strList.Add(null);
            strList.Add(null);

            IList<Student> studentList = new List<Student>();
            studentList.Add(new Student());
            studentList.Add(new Student());
            studentList.Add(new Student());

            //or
        /*    IList<Student> studentList1 = new List<Student>()
            {
                new Student(){ Id = 1, Name="Bill" },
                new Student(){ Id = 2, Name="Elena" },
                new Student(){ Id = 3, Name="Jane" },
            };
        */
        }
    }
}