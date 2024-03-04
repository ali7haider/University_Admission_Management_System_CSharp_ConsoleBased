using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSNEW.BL
{
    class Subject
    {
        private string code;
        private string subjectType;
        private int creditHours;
        private int subjectFees;
        public Subject(string code, string subjectType,int creditHours,int subjectFees)
        {
            this.code = code;
            this.creditHours = creditHours;
            this.subjectType = subjectType;
            this.subjectFees = subjectFees;
        }
        public void setSubjectCode(string code)
        {
            this.code = code;
        }
        public void setsubjectType(string subjectType)
        {
            this.subjectType = subjectType;
        }
        public void setCreditHour(int creditHours)
        {
            this.creditHours = creditHours;
        }
        public void setEcat(int subjectFees)
        {
            this.subjectFees = subjectFees;
        }
        public string getCode()
        {
            return code; ;
        }
        public string getSubjectType()
        {
            return subjectType;
        }
        public int getCreditHours()
        {
            return creditHours; ;
        }
        public float getSubjectFees()
        {
            return subjectFees;
        }
    }
}
