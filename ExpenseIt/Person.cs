using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseIt
{
    public class Person
    {
        public string name;
        public string department;
        public double expenses;

        public override string ToString()
        {
            return name;
        }
    }
}
