using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSNEW.BL
{
    class DegreeProgram
    {
        private string title;
        private string duration;
        private int seats;
        private List<Subject> degreeSubjects = new List<Subject>();
        public DegreeProgram(string title,string duration,int seats)
        {
            this.title = title;
            this.duration = duration;
            this.seats = seats;
            degreeSubjects = new List<Subject>();
            
        }
        public DegreeProgram()
        {

        }
        public int calculateCreditHours()
        {
            int count = 0;
            for (int x = 0; x < degreeSubjects.Count; x++)
            {
                count = count + degreeSubjects[x].getCreditHours();
            }
            return count;
        }
        public bool AddSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if (creditHours + s.getCreditHours() <= 20)
            {
                degreeSubjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void setTitle(string title)
        {
            this.title = title;
        }
        public void setDuration(string duration)
        {
            this.duration = duration;
        }
        public void setSeats(int seats)
        {
            this.seats = seats;
        }
        public void setDegreeSubjects(List<Subject> degreeSubjects)
        {
            this.degreeSubjects = degreeSubjects;
        }
        //___________Getter Functions
        public string getTitle()
        {
            return title;
        }
        public string getDuration()
        {
            return duration;
        }
        
        public int getSeats()
        {
            return seats;
        }
        public List<Subject> getDegreeSubjects()
        {
            return degreeSubjects;
        }

    }
}
