using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMSNEW.BL;
using UAMSNEW.DL;
using UAMSNEW.UI;

namespace UAMSNEW
{
    class Program
    {
        static void Main(string[] args)
        {
            if (SubjectDL.ReadFromFile())
            {
                Console.WriteLine("Subject Data Loaded Successfully");
            }
            if (DegreeProgramDL.ReadfromFile())
            {
                Console.WriteLine("DegreeProgram Data Loaded Successfully");
            }
            if (StudentDL.ReadFromFile())
            {
                Console.WriteLine("Student Data Loaded Successfully");
            }
            while (true)
            {
                string opt = MenuUI.menu();
                if (opt == "1")
                {
                    if (DegreeProgramDL.degreeProgramsList.Count > 0)
                    {
                        Student S = StudentUI.addStudent();
                        StudentDL.addStudentToList(S);
                        StudentDL.storeInFile(S);
                    }
                    else
                    {
                        Console.WriteLine("No Programs Available....");
                        MenuUI.clearscreen();

                    }
                }
                else if (opt == "2")
                {
                    DegreeProgram D = DegreeProgramUI.addProgram();
                    DegreeProgramDL.addDegreeToList(D);
                    DegreeProgramDL.StoreInFile(D);

                }
                else if (opt == "3")
                {
                    DegreeProgramDL.sortedStudentByMerit();
                    DegreeProgramDL.giveAdmission();
                    DegreeProgramUI.printAdmission();
                }
                else if (opt == "4")
                {
                    StudentUI.registerStudents();

                }
                else if (opt == "5")
                {
                    StudentUI.viewSpecificDegreeStudent();

                }
                else if (opt == "6")
                {
                    SubjectUI.registerSubjects();


                }
                else if (opt == "7")
                {
                    StudentUI.calculateFeeForAll();
                }
                else if (opt == "8")
                {
                    break;

                }
                else
                {
                    Console.WriteLine("Wrong Input......");
                    MenuUI.clearscreen();
                }
            }
        }
    }
}
    