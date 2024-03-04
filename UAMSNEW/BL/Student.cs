using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UAMSNEW.BL
{
    class Student
    {
        private string name;
        private int age;
        private float fsc;
        private float ecat;
        private float merit;
        private List<DegreeProgram> Prefrences = new List<DegreeProgram>();
        private List<Subject> regSubjects = new List<Subject>();
        private DegreeProgram regDegree = new DegreeProgram();
        public Student(string name, int age, float fsc, float ecat, float merit, List<DegreeProgram> Prefrences)
        {
            this.name = name;
            this.age = age;
            this.fsc = fsc;
            this.ecat = ecat;
            this.Prefrences = Prefrences;
            this.merit = merit;
            this.regSubjects = new List<Subject>();
            this.regDegree = null;

        }
        public int getCreditHours()
        {
            int count = 0;
            foreach (Subject sub in regSubjects)
            {
                count = count + sub.getCreditHours();
            }
            return count;
        }
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && stCH + s.getCreditHours() <= 9)
            {
                regSubjects.Add(s);
                return true;
            }
            else
            {
                return false;

            }
        }
        public float calculateFee()
        {
            float fee = 0;
            if (regDegree != null)
            {
                foreach (Subject sub in regSubjects)
                {
                    fee = fee + sub.getSubjectFees();
                }
            }
            return fee;
        }
        public void setStudentName(string name)
        {
            this.name = name;
        }
        public void setAge(int age)
        {
            this.age = age;
        }
        public void setFsc(int fsc)
        {
            this.fsc = fsc;
        }
        public void setEcat(int ecat)
        {
            this.ecat = ecat;
        }
        public void setMerit(float merit)
        {
            this.merit = merit;
        }
        public void setRegSubjects(List<Subject> regSubject)
        {
            this.regSubjects = regSubject;
        }
        public void setRegDegree(DegreeProgram regDegree)
        {
            this.regDegree = regDegree;
        }

        public void setPreferance(List<DegreeProgram> Preferences)
        {
            this.Prefrences = Preferences;
        }
        //Get Functions
        public string getName()
        {
            return name; ;
        }
        public int getAge()
        {
            return age;
        }
        public float getfsc()
        {
            return fsc;
        }
        public float getecat()
        {
            return ecat;
        }
        public float getMerit()
        {
            return merit;
        }
        public List<Subject> getRegSubjects()
        {
            return regSubjects;
        }
        public DegreeProgram GetRegDegree()
        {
            return regDegree;
        }
        public List<DegreeProgram> getPrefrences()
        {
            return Prefrences;
        }
    }
}
