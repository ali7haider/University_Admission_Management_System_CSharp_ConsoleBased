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
    class SubjectDL
    {
        public static List<Subject> subjectList = new List<Subject>();

        public static void addSubjectIntoList(Subject s)
        {
            subjectList.Add(s);
        }
        public static Subject isSubjectExists(string type)
        {
            foreach (Subject s in subjectList)
            {
                if (s.getSubjectType()== type)
                {
                    return s;
                }
            }
            return null;
        }
        public static void storeintoFile(Subject s)
        {
            string path = "SubjectsList.txt";
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(s.getCode() + "," + s.getSubjectType() + "," + s.getCreditHours() + "," + s.getSubjectFees());
            f.Flush();
            f.Close();
        }
        public static bool ReadFromFile()
        {
            string path = "SubjectsList.txt";
            StreamReader file = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = file.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int creditHours = int.Parse(splittedRecord[2]);
                    int subjectFees = int.Parse(splittedRecord[3]);
                    Subject s = new Subject(code, type, creditHours, subjectFees);
                    addSubjectIntoList(s);
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
