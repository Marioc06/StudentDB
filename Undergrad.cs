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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    public enum YearRank
    {
        Freshman = 1,
        Sophomore = 2,
        Junior = 3,
        Senior = 4
    }
    class Undergrad : Student
    {
        public YearRank Rank { get; set; }

        public string DegreeMajor { get; set; }

        public Undergrad(string first, string last, double gpa,
                            string email, DateTime enrolled,
                            YearRank rank, string major)

            :base(new ContactInfo(first, last, email), gpa, enrolled)
        {
            Rank = rank;
            DegreeMajor = major;

        }
        
        // another example of a lambda expression
        public override string ToString() => base.ToString() + $"      Year: {Rank}\n       Major: {DegreeMajor}\n";

        public override string ToStringForOutputFile()
        {
            string str = this.GetType() + "\n";
            str += base.ToStringForOutputFile();

            str += $"{Rank}\n";
            str += $"{DegreeMajor}";  // no CRLF on the last output line because: WritelIne()

            return str;
        }
    }
}
