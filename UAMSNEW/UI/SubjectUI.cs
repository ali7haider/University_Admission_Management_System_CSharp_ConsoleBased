using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMSNEW.BL;
using UAMSNEW.DL;

namespace UAMSNEW.UI
{
    class SubjectUI
    {
        public static void registerSubject(Student S)
        {
            Console.Write("How Many Subject want to Enter : ");
            int total = int.Parse(Console.ReadLine());
            for (int i = 0; i < total; i++)
            {
                bool flag = false;
                Console.Write("Enter Subject Code : ");
                string code = Console.ReadLine();
                foreach (Subject sub in S.GetRegDegree().getDegreeSubjects())
                {
                    if (sub.getCode() == code && !(S.getRegSubjects().Contains(sub)))
                    {
                        if (S.regStudentSubject(sub))
                        {
                            flag = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("A student cannot have more than 9 CH");
                            flag = true;
                            break;
                        }

                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter VAlid Code.....");
                }
            }
        }
        public static void registerSubjects()
        {
            if (DegreeProgramDL.degreeProgramsList.Count > 0)
            {
                Console.Write("Enter Name : ");
                string name = Console.ReadLine();
                Student S = StudentDL.studentPresent(name);
                if (S != null)
                {
                    viewSubjects(S);
                    registerSubject(S);
                }
            }
            else
            {
                Console.WriteLine("No Registered Student....");


            }
            MenuUI.clearscreen();

        }
        public static void viewSubjects(Student S)
        {
            if (S.GetRegDegree() != null)
            {
                Console.WriteLine("Code\t\tType");
                foreach (Subject sub in S.GetRegDegree().getDegreeSubjects())
                {
                    Console.WriteLine(sub.getCode() + "\t\t" + sub.getSubjectType());
                }
            }
        }
    }
}
