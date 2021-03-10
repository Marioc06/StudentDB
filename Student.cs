/////////////////////////////////////////////////////////////////////////////////
// Change History
// Date ---------  Developer ------ Description
// 2021-02-09      marioc          Created one file that consists of multiple programs to start the L6oop Assignment.
// 2021-02-09      marioc          Creating a introduction to the Users that run/exec the program.
// 2021-02-09      marioc          Implementing the GET & SET properties/encapsulation to collect data from the student.
// 2021-02-11      marioc          I was trying to include a clean display for the user to easily understand.
// 2021-02-16      marioc          Getting the proper information to display the Student Information to determine if Undergrad or Graduate.
// 2021-02-18      marioc          Insert ReadDataFrom: Input/Output INPUTDATAFILE/OUTDATAFILE/STUDENT DB method to carry on the information and 
//                                 returning those results at the end.
// 2021-02-23      marioc          The selections were clear and identified to carry out the the input/output etc: modify/add/save/exit.
// 2021-02-25      marioc          Creating a introduction & multiple selections for the Student to choose from to run/exec the program correctly.
///////////////////////////////////////////////////////
// TINFO 200 C, Winter 2021
// UWTacoma SET, Mario Cavazos Student
using System;

namespace StudentDB
{
    internal class Student // : object
    {
        //public string FirstName { get; set; }

        //public string LastName { get; set; }
        public ContactInfo Info { get; set; }

        public DateTime EnrollmentDate { get; set; }


        private double gradePtAvg;

        //public string emailAddress;


        public Student()
        {

        }
        
        // Overloading the ctor for students class
        // fully specified ctor for making student POCO objects
        public Student(ContactInfo info, double grades, DateTime enrolled)
        {
            Info = info;
            GradePtAvg = grades;
            EnrollmentDate = enrolled;


        }

        public double GradePtAvg
        {
            get
            {
                return gradePtAvg;
            }
            set
            {
                if(0 <= value && value <= 4)
                {
                    // only set the GPA is passed in val is between
                    // "legal" defined GPA range 0 to 4 inclusive
                    gradePtAvg = value;
                }
                else
                {
                    gradePtAvg = 0.7;
                }
            }

        }



        // display a student object to a string for
        // displaying student data to the user in the UI

        public override string ToString()
        {
            // create a temp string to hold the output
            string str = string.Empty;

            str += "*** Student Record*********\n";

            // build up the string with data from the object
            str += $"First Name: {Info.FirstName}\n";
            str += $" Last Name: {Info.LastName}\n";
            str += $"       Gpa: {GradePtAvg}\n";
            str += $"     Email: {Info.EmailAddress}\n";
            str += $"  Enrolled: {EnrollmentDate}\n";


            // return the string

            return str;
        }

        // format a student object to a string for
        // writing the data to the output file
        public virtual string ToStringForOutputFile()
        {
            // create a temp string to hold the output
            string str = string.Empty;


            // build up the string with data from the object
            str += $"{Info.FirstName}\n";
            str += $"{Info.LastName}\n";
            str += $"{GradePtAvg}\n";
            str += $"{Info.EmailAddress}\n";
            str += $"{EnrollmentDate}\n";


            // return the string

            return str;
        }
    }
}
   