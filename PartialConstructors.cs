using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpVersion14Samples
{
    public partial class Employee
    {
        // Defining declaration of the partial constructor
        public partial Employee(string firstName, string lastName);

        public string FullName { get; private set; }
    }

    public partial class Employee
    {
        // Implementing declaration of the partial constructor
        public partial Employee(string firstName, string lastName) : this() // Constructor initializer goes here
    {
            FullName = $"{firstName} {lastName}";
            Console.WriteLine($"Employee partial constructor invoked: {FullName}");
        }

        //// Base parameterless constructor
        public Employee()
        {
            Console.WriteLine("Employee base constructor invoked.");
        }
    }
}