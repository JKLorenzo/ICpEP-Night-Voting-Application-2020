using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICpEP_Night_Voting_Application_2020
{
    class Student
    {
        public int ID { get; }
        public String Name { get; }

        public Student(int ID, String Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
