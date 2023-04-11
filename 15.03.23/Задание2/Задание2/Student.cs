using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание2
{
    class Student
    {
        private string name;
        private string surname;
        private string recordBookNumber;
        public Student(string name, string surname, string recordBookNumber)
        {
            this.name = name;
            this.surname = surname;
            this.recordBookNumber = recordBookNumber;
        }
        public string Name {get { return name; } set { name = value; } }
        public string Surname {get { return surname; } set { surname = value; } }
        public string RecordBookNumber { get { return recordBookNumber; } set { recordBookNumber = value; } }

    }
}
