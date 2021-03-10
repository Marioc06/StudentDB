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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a single object for the db app
            StudentApp app = new StudentApp();

            // read in data from the input file
            app.ReadDataFromInputFile();

            // operate the database - carry out the user's CRUD operations
            app.RunDatabaseApp();

            // write the data to output file
            


        }

    }

}



