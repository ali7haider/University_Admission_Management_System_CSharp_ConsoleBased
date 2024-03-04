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
    class DegreeProgramDL
    {
        public static List<DegreeProgram> degreeProgramsList = new List<DegreeProgram>();
        public static void addDegreeToList(DegreeProgram D)
        {
            degreeProgramsList.Add(D);
        }
        static public void sortedStudentByMerit()
        {

            StudentDL.sortedStudentList = StudentDL.studentList.OrderByDescending(o => o.getMerit()).ToList();

        }
        public static void giveAdmission()
        {
            foreach (Student S in StudentDL.sortedStudentList)
            {

                foreach (DegreeProgram D in S.getPrefrences())
                {
                    if (D.getSeats() > 0 && S.GetRegDegree() == null)
                    {
                        S.setRegDegree(D);
                        D.setSeats(D.getSeats()-1);
                        break;
                    }
                }

            }
        }
        public static DegreeProgram isDegreeExists(string degreeName)
        {
            foreach (DegreeProgram d in degreeProgramsList)
            {
                if (d.getTitle() == degreeName)
                {
                    return d;
                }
            }
            return null;
        }
        public static void StoreInFile(DegreeProgram D)
        {
            string path = "DegreesList.txt";
            StreamWriter file = new StreamWriter(path);
            string SubjectNames = "";
            for (int i = 0; i < D.getDegreeSubjects().Count; i++)
            {
                SubjectNames = SubjectNames + D.getDegreeSubjects()[i].getSubjectType() + ";";
            }
            SubjectNames = SubjectNames + D.getDegreeSubjects()[D.getDegreeSubjects().Count-1].getSubjectType() + ";";
            file.WriteLine(D.getTitle() + "," + D.getDuration() + "," + D.getSeats() + "," + SubjectNames);
            file.Flush();
            file.Close();
        }
        public static bool ReadfromFile()
        {
            string path = "DegreesList.txt";
            StreamReader file = new StreamReader(path);
            string record;
            if(File.Exists(path))
            {
                while((record=file.ReadLine())!=null)
                {
                    string[] splittedRecord = record.Split(',');
                    string title = splittedRecord[0];
                    string duration = splittedRecord[1];
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordforSubject = splittedRecord[3].Split(';');
                    List<DegreeProgram> preferences = new List<DegreeProgram>();
                    DegreeProgram d = new DegreeProgram(title, duration, seats);
                    for (int x = 0; x < splittedRecordforSubject.Length; x++)
                        {
                            Subject s = SubjectDL.isSubjectExists(splittedRecordforSubject[x]);
                            if (s != null)
                            {
                                d.AddSubject(s);
                            }
                        }
                        addDegreeToList(d);

                    }
                file.Close();
                return true;
            }
            return false;
        }
    }

}
