using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UAMSNEW.BL;
using UAMSNEW.UI;

namespace UAMSNEW.DL
{
    class StudentDL
    {
        public static List<Student> studentList = new List<Student>();
        public static List<Student> sortedStudentList = new List<Student>();

        public static void addStudentToList(Student s)
        {
            studentList.Add(s);
        }
        public static float calculateMerit(float fsc,float ecat)
        {
            float merit = (fsc / 1100) * 60 + (ecat / 400) * 40;
            return merit;
        }
        public static Student studentPresent(string name)
        {
            foreach (Student S in StudentDL.studentList)
            {
                if (name == S.getName())
                {
                    return S;
                }
            }
            return null;
        }
       public static void storeInFile(Student S)
        {
            string path = "studentLists.txt";
            StreamWriter file = new StreamWriter(path,true);
            string degreesNames="";
            for (int i = 0; i < S.getPrefrences().Count-1; i++)
            {
                degreesNames = degreesNames + S.getPrefrences()[i].getTitle() + ";";

            }
            degreesNames = degreesNames + S.getPrefrences()[S.getPrefrences().Count - 1].getTitle();
            file.WriteLine(S.getName() + "," + S.getAge() + "," + S.getfsc() + "," + S.getecat() + "," + degreesNames);
            file.Flush();
            file.Close();
       }
        public static bool ReadFromFile()
        {
            string path = "studentLists.txt";
            StreamReader file = new StreamReader(path);
            string record;
            if(File.Exists(path))
            {
                while ((record = file.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    float fsc = float.Parse(splittedRecord[2]);
                    float ecat = float.Parse(splittedRecord[3]);
                    float merit = StudentDL.calculateMerit(fsc, ecat);
                    string[] splittedRecordForPreference = splittedRecord[4].Split(';');
                    List<DegreeProgram> preferences = new List<DegreeProgram>();
                    for (int x = 0; x < splittedRecordForPreference.Length; x++)
                    {
                        DegreeProgram d = DegreeProgramDL.isDegreeExists(splittedRecordForPreference[x]);
                        if (d != null)
                        {
                            if (!(preferences.Contains(d)))
                            {
                                preferences.Add(d);
                            }
                        }
                    }
                    Student s = new Student(name, age, fsc,ecat,merit,preferences);
                    studentList.Add(s);
                }
                file.Close();
                return true;
            }
            else
            {
                return false;
            }

        }
     }
 }

