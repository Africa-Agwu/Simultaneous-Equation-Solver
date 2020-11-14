using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementApp
{
    class Program
    {
        public static int count = 1;
        static void Main(string[] args)
        {
            try
            {
                List<Students> newStudents = new List<Students>();
                Registeration(newStudents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
            
        }
        public static void Registeration(List<Students> newStudents)
        {
            for (int i = count; i < 100;)
            {
                Students student = new Students();
                Console.WriteLine("Enter First name");
                string FirstName = Console.ReadLine();
                Console.WriteLine("Enter last name");
                string LastName = Console.ReadLine();
                Console.WriteLine("Enter Sex");
                string Sex = Console.ReadLine();
                Console.WriteLine("Enter Age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter class");
                string Class = Console.ReadLine();
                student.FName = FirstName;
                student.LName = LastName;
                student.Sex = Sex;
                student.Age = age;
                student.Class = Class;
                //student.ID = count;
                newStudents.Add(student);
                AssignID(newStudents);
                count++;
                DisplayStudentInfo(student.FName, student.LName, student.Sex, student.Age, student.Class, student.ID);
                DisplayOptions(newStudents);

            }
        }
        public static void DisplayOptions(List<Students> newStudents)
        {
            Console.ReadLine();
            Console.WriteLine("What do you want to do next? \n Enter 1 to show all registered students \n Enter 2 to register new student \n Enter 3 to Edit \n Enter 4 to Delete \n Enter 0 to exit");
            string opt = Console.ReadLine();
            if (opt == "1")
            {
                DisplayAll(newStudents);
            }
            else if (opt == "3")
            {
                EditInfo(newStudents);
            }
            else if (opt == "4")
            {
                DeleteInfo(newStudents);
            }
            else if (opt == "0")
            {
                ExitApp();
            }
            else if (opt == "2")
            {
                Registeration(newStudents);
            }
        }
        public static void DisplayStudentInfo(string Fname, string Lname, string Sex, int Age, string Class, int ID)
        {
            Console.WriteLine("     First Name: {0,-10} Last Name: {1,-10} Sex: {2,-6}  Age: {3,-5}  Class: {4,-5}   ID: {5,2}", Fname, Lname, Sex, Age, Class, ID);
            
        }
        public static void DisplayAll(List<Students>newStudents)
        {
            
                foreach (var item in newStudents)
                {
                    Console.WriteLine("First Name: {0,-10}   Last Name: {1,-10}   Sex: {2,-6}   Age: {3,-5}  Class: {4,-5}    ID: {5,2}", item.FName, item.LName, item.Sex, item.Age, item.Class, item.ID);
                }
            
           DisplayOptions(newStudents);
        }
        public static void EditInfo(List<Students> newStudents)
        {
            Console.WriteLine("Enter the ID of the student you want to edit his/her Info");
            int nID = int.Parse(Console.ReadLine());
            int index = newStudents.FindIndex(a => a.ID == nID);
            var info = newStudents[index];
            Console.WriteLine("First Name is {0} \n Last Name is {1} \n Sex is {2} \n Age is {3} \n Class is {4} \n ID is {5}", info.FName, info.LName, info.Sex, info.Age, info.Class, info.ID);
            Console.WriteLine("If you want to leave a field unchanged, just click enter to skip");
            Console.WriteLine("Input New First Name");
            var newFName = Console.ReadLine();
            if (newFName == "")
            {
                Console.WriteLine("First Name is still {0}", info.FName);
            }
            else
            {
                info.FName = newFName;
            }
            Console.WriteLine("Input New Last Name");
            var newLName = Console.ReadLine();
            if (newLName == "")
            {
                Console.WriteLine("Last Name is still {0}", info.LName);
            }
            else
            {
                info.LName = newLName;
            }
            Console.WriteLine("Input New Sex");
            var newSex = Console.ReadLine();
            if (newSex == "")
            {
                Console.WriteLine("Sex is still {0}", info.Sex);
            }
            else
            {
                info.Sex = newSex;
            }
            Console.WriteLine("Input New Age");
            var newAge = Console.ReadLine();
            if (newAge == "")
            {
                Console.WriteLine("Age is still {0}", info.Age);
            }
            else
            {
                info.Age = int.Parse(newAge);
            } 
            Console.WriteLine("Input New Class");
            var newClass = Console.ReadLine();
            if (newClass == "")
            {
                Console.WriteLine("Class is still {0}", info.Class);
            }
            else
            {
                info.Class = newClass;
            }
            DisplayStudentInfo(info.FName, info.LName, info.Sex, info.Age, info.Class, info.ID);
            Console.ReadLine();
            DisplayOptions(newStudents);
                Console.ReadLine();
        }
        public static void DeleteInfo(List<Students> newStudents)
        {
            Console.WriteLine("Enter the ID of the student you want to delete his/her Info");
            int nID = int.Parse(Console.ReadLine());
            int index = newStudents.FindIndex(a => a.ID == nID);
            var info = newStudents[index];
            Console.WriteLine("First Name is {0} \n Last Name is {1} \n Sex is {2} \n Age is {3} \n Class is {4} \n ID is {5}", info.FName, info.LName, info.Sex, info.Age, info.Class, info.ID);
            Console.ReadLine();
            newStudents.RemoveAt(index);
            count--;
            AssignID(newStudents);
            DisplayAll(newStudents);
            
        }
        public static void AssignID(List<Students> newStudents)
        {
            foreach (var item in newStudents)
            {
                item.ID = newStudents.IndexOf(item) + 1;
            }
        }
        public static void ExitApp()
        {
            Console.WriteLine("Thanks For Using the Application \n Press \"Enter\" to exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
    class Students
    
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public int ID { get; set; }
    }

}
