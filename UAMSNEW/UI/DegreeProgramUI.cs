using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMSNEW.BL;
using UAMSNEW.DL;

namespace UAMSNEW.UI
{
    class DegreeProgramUI
    {
        
        public static DegreeProgram addProgram()
        {
            List<Subject> degreeSubjects = new List<Subject>();
            Console.Clear();
            MenuUI.header();
            Console.Write("Enter Degree Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Degree Duration : ");
            string dura = Console.ReadLine();
            Console.Write("Enter Seats for Degree : ");
            int seats = int.Parse(Console.ReadLine());
            Console.Write("Enter How Many subjects : ");
            int totalS = int.Parse(Console.ReadLine());
            DegreeProgram D = new DegreeProgram(name, dura, seats);
            for (int i = 0; i < totalS; i++)
            {
                Console.Write("Enter Subject[" + (i + 1) + "] code : ");
                string code = Console.ReadLine(); 
                Console.Write("Enter Subject[" + (i + 1) + "] Type : ");
                string type = Console.ReadLine();
                Console.Write("Enter Subject[" + (i + 1) + "] Credit Hours : ");
                int credit = int.Parse(Console.ReadLine());
                Console.Write("Enter Subject[" + (i + 1) + "] Fees : ");
                int fees = int.Parse(Console.ReadLine());
                Subject S = new Subject(code, type, credit, fees);
                
                if (D.AddSubject(S))
                {
                    degreeSubjects.Add(S);
                    SubjectDL.addSubjectIntoList(S);
                    SubjectDL.storeintoFile(S);
                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("Subject Not Added");
                    Console.WriteLine("20 credit hour limit exceeded");
                    i--;
                }
            }

            
            MenuUI.clearscreen();
            return D;
        }
        
        public static void availablePrograms()
        {
            Console.Write("Available Degree Programs : ");
            foreach (DegreeProgram temp in DegreeProgramDL.degreeProgramsList)
            {
                Console.Write(temp.getTitle() + " ");

            }
            Console.WriteLine(" ");
        }
        public static void printAdmission()
        {
            foreach (Student S in StudentDL.studentList)
            {
                if(S.GetRegDegree() != null)
                {
                    Console.WriteLine(S.getName() + " got admission in " + S.GetRegDegree().getTitle());
                }
                else
                {
                    Console.WriteLine(S.getName() + " did not got admission ");
                }
            }
            MenuUI.clearscreen();
        }
    }
}
