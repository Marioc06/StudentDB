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
namespace StudentDB
{
    public class ContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string emailAddress;

        public ContactInfo(string first, string last, string email)
        {
            FirstName = first;
            LastName = last;
            EmailAddress = email;
        }

        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                // passed in email must have at least 3 chars and one must be "@"
                if (value.Contains("@") && value.Length > 3)
                {
                    emailAddress = value;
                }
                else
                {
                    // TODO: not sure how we can handle this
                    // HACK:
                    emailAddress = "ERROR: Invalid email.";
                }
            }
        }

        // lambda expression for user friendly printing of the contact info
        public override string ToString() => $"{FirstName}\n{LastName}\n{EmailAddress}\n";

        public string ToStringLegal() => $"{LastName}, {FirstName}\n{EmailAddress}\n";

    }
}