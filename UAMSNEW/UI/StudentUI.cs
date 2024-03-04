using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMSNEW.BL;
using UAMSNEW.DL;

namespace UAMSNEW.UI
{
    class StudentUI
    {
        

        static public Student addStudent()
        {

            string prefre;
            List<DegreeProgram> pref = new List<DegreeProgram>();
            Console.Clear();
            MenuUI.header();
            Console.Write("Enter Student Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Student Age : ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student fsc Marks : ");
            float fsc = float.Parse(Console.ReadLine());
            Console.Write("Enter Student Ecat marks : ");
            float ecat = float.Parse(Console.ReadLine());
            float merit = StudentDL.calculateMerit(fsc, ecat);
            Console.WriteLine(merit);
            DegreeProgramUI.availablePrograms();
            Console.Write("Enter How Number of Prefrences : ");
            int p = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Programs");
            for (int i = 0; i < p; i++)
            {
                prefre = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgram d in DegreeProgramDL.degreeProgramsList)
                {


                    if (prefre == d.getTitle() && !(pref.Contains(d)))
                    {
                        pref.Add(d);
                        flag = true;
                    }

                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name");
                    i--;
                }
            }
            Student stu = new Student(name, age, fsc, ecat, merit, pref);
            Console.Clear();
            return stu;
        }
        public static void registerStudents()
        {
            if (DegreeProgramDL.degreeProgramsList.Count > 0)
            {
                Console.WriteLine("Name\t\tAge\t\tFSC\t\tECAT");
                foreach (Student S in StudentDL.studentList)
                {
                    if (S.GetRegDegree() != null)
                    {
                        Console.WriteLine(S.getName() + "\t\t" + S.getAge() + "\t\t" + S.getfsc() + "\t\t" + S.getecat());
                    }
                }
            }
            else
            {
                Console.WriteLine("No Registered Student");
            }
            MenuUI.clearscreen();
        }
        public static void viewSpecificDegreeStudent()
        {
            
            if (DegreeProgramDL.degreeProgramsList.Count > 0)
            {
                bool flag = false;
                Console.Write("Enter Degree Name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Name\t\tAge\t\tFSC\t\tECAT");
                foreach (Student S in StudentDL.studentList)
                {
                    if (S.GetRegDegree() != null)
                    {
                        if (name == S.GetRegDegree().getTitle())
                        {
                            flag = true;
                            Console.WriteLine(S.getName() + "\t\t" + S.getAge() + "\t\t" + S.getfsc() + "\t\t" + S.getecat());
                        }
                    }
                }
                if(flag==false)
                {
                    Console.WriteLine("No Such Degree Available");
                }
            }
            else
            {
                Console.WriteLine("No Registered Student");
            }
            MenuUI.clearscreen();
        }
        
        
       
        public static void calculateFeeForAll()
        {
            if (DegreeProgramDL.degreeProgramsList.Count > 0)
            {
                foreach (Student s in StudentDL.studentList)
                {
                    if (s.getRegSubjects() != null)
                    {
                        Console.WriteLine(s.getName() + " has " + s.calculateFee() + " fees");
                    }
                }
            }
            else
            {
                Console.WriteLine("No Registered Student....");
                

            }
            MenuUI.clearscreen();
        }

    }
}
