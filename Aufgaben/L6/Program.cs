using System;
using System.Collections.Generic;

namespace L6
{


    class Person
    {
        public string name;
        public int age;
    }

    class Member : Person
    {
        public int matriculationnumber;
        public List<Course> Courses;
    }

    class Lecturer : Person
    {
        public string office;
        public string consultation;

        public List<Course> Courses;

        public void courselist()
        {
            foreach (Course Course in Courses)
                Console.WriteLine(Course.title);
        }

        public List<Member> memberlist()
        {
            List<Member> allmembers = new List<Member>();

            foreach (Course Course in Courses)
            {
                foreach (Member member in Course.Members)
                {
                    if (!allmembers.Contains(member))
                    {
                        allmembers.Add(member);
                    }
                }
            }
            return allmembers;
        }
    }

    class Course
    {
        public string title;
        public string room;
        public string weekday;
        public string timeofday;

        public Lecturer Lecturer;
        public List<Member> Members;

        public void infotext()
        {
            Console.WriteLine("Der Kurs " + title + " findet am " + weekday + "um" + timeofday + " in Raum " + room + " statt.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
