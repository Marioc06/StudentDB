/////////////////////////////////////////////////////////////////////////////////
// Change History
// Date ---------  Developer ------ Description
// 2021-02-09      marioc          Created one file that consists of multiple programs to start the L6oop Assignment.
// 2021-02-09      marioc          Creating a introduction to the Users that run/exec the program.
// 2021-02-09      marioc          Implementing the GET & SET properties/encapsulation to collect data from the student.
// 2021-02-11      marioc          I was trying to include a clean display for the user to easily understand.
// 2021-02-16      marioc          Getting the proper information to display the Student Information to determine if Undergrad or Graduate.
// 2021-02-18      marioc          Insert ReadDataFrom: Input/Output INPUTDATAFILE/OUTDATAFILE/STUDENT DB method to carry on the information and 
// 2021-02-18      marioc          objects must be stored and manipulated in a List<Student>
//                                 returning those results at the end.
// 2021-02-23      marioc          The selections were clear and identified to carry out the the input/output etc: modify/add/save/exit.
// 2021-02-23      marioc          C# allows any extension for text files but you will use .txt so that it opens in Notepad
// 2021-02-25      marioc          Creating a introduction & multiple selections for the Student to choose from to run/exec the program correctly.
///////////////////////////////////////////////////////
// TINFO 200 C, Winter 2021
// UWTacoma SET, Mario Cavazos Student
using System;
using System.Collections.Generic;
using System.IO;

namespace StudentDB
{
    internal class StudentApp
    {
        private List<Student> students = new List<Student>();
        
        public StudentApp()
        {
        }

        internal void ReadDataFromInputFile()
        {
            StreamReader infile = new StreamReader("INPUTDATAFILE.txt");

            string studentType = string.Empty;

            //read the file
            while((studentType = infile.ReadLine()) != null)
            {
                // read the rest of the record
                string first = infile.ReadLine();
                string last = infile.ReadLine();
                double gpa = double.Parse(infile.ReadLine());
                string email = infile.ReadLine();
                DateTime date = DateTime.Parse(infile.ReadLine());

                if(studentType == "StudentDB.GradStudent")
                {
                    decimal credit = decimal.Parse(infile.ReadLine());
                    string facAdvisor = infile.ReadLine();

                    GradStudent grad = new GradStudent(first, last, gpa, email, date, credit, facAdvisor);
                    students.Add(grad);

                    //Console.WriteLine();

                }
                else if(studentType == "StudentDB.Undergrad")
                {
                    YearRank rank = (YearRank)Enum.Parse(typeof(YearRank), infile.ReadLine());
                    string major = infile.ReadLine();

                    Undergrad undergrad = new Undergrad(first, last, gpa, email, date, rank, major);
                    students.Add(undergrad);

                    //Console.WriteLine(undergrad);
                    
                }
                else
                {
                    Console.WriteLine($"ERROR: type {studentType} is not a valid student.");
                }

                // now you gave all the data from a single rec - add a new student to the list
                //Student stu = new Student(first, last, gpa, email, date);
                //students.Add(stu);
                //Console.WriteLine(stu);     // as the objects are created, we can monitor the data

            }

            Console.WriteLine("Reading input file is complete...");
            infile.Close();

        }

        // TODO: searches the current list for a student record
        // Output: returns the student object if found, null if not found
        // email contains the search string
        private Student FindStudentRecord(out string email)
        {
            Console.WriteLine("\nENTER email address (primary key) to search: ");
            email = Console.ReadLine();
            foreach (var student in students)
            {
                if (email == student.Info.EmailAddress)
                {
                    // found it!
                    Console.WriteLine($"FOUND email address: {student.Info.EmailAddress}");
                    return student;
                }
            }
            // arrived here, must not have found the rec
            Console.WriteLine($"{email}NOT FOUND.");
            return null;
        }

        internal void RunDatabaseApp()
        {
            while(true)
            {
                // Display a main menu
                DisplayMainMenu();

                // capture
                char selection = GetUserSelection();
                string email = string.Empty;

                switch(selection)
                {
                    case 'A':
                    case 'a':
                        AddStudentRecord();
                        break;
                    case 'F':
                    case 'f':
                        FindStudentRecord(out email);
                        break;
                    case 'P':
                    case 'p':
                        PrintAllRecords();
                        break;
                    case 'D':
                    case 'd':
                        DeleteStudentRecord();
                        break;
                    case 'M':
                    case 'm':
                        ModifyStudentRecord();
                        break;
                    case 'E':
                    case 'e':
                        // Exit without save();
                        ExitApplicationWithoutSave();

                        break;
                    case 'S':
                    case 's':
                        SaveAllChangesAndQuit();
                        WriteDataToOutputFile();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"ERROR: {selection} is not a valid choice!");
                        break;
                }
            }
            
        }

        private void ModifyStudentRecord()
        {
            // first, search the list to see if this email rec already exists
            string email = string.Empty;
            Student stu = FindStudentRecord(out email);
            if (stu != null)
            {
                ModifyStudent(stu);
            }
            else
            {
                // record as not in the database = issue an info message
                Console.WriteLine($"***** RECORD NOT FOUND.\nCan't edit record for user {email}.");
            }
        }


        private void ModifyStudent(Student stu)
        {
            string studentType = stu.GetType().ToString();
            Console.WriteLine(stu);
            Console.WriteLine($"Editing student type: {studentType.Substring(10)}");
            DisplayModifyMenu();
            char selection = GetUserSelection();
            if (studentType == "StudentDB.Undergrad")
            {

                Undergrad undergrad = stu as Undergrad;
                switch (selection)
                {
                    case 'Y':
                    case 'y':
                        Console.WriteLine("\nENTER new year/rank in school from the following choices.");
                        Console.Write("[1] Freshman,[2] Sophomore,[3] Junior,[4] Senior: ");
                        undergrad.Rank = (YearRank)int.Parse(Console.ReadLine());
                        break;
                    case 'D':
                    case 'd':
                        Console.Write("\nENTER new degree major: ");
                        undergrad.DegreeMajor = Console.ReadLine();
                        break;
                }
            }
            else if (studentType == "StudentDB.GradStudent")
            {

                GradStudent grad = stu as GradStudent;
                switch (selection)
                {
                    case 'T':
                    case 't':
                        Console.Write("\nENTER new student reimbursement credit: ");
                        grad.TuitionCredit = decimal.Parse(Console.ReadLine());
                        break;
                    case 'A':
                    case 'a':
                        Console.Write("\nENTER new faculty advisor name: ");
                        grad.FacultyAdvisor = Console.ReadLine();
                        break;
                }

            }
            switch (selection)
            {
                case 'F':
                case 'f':
                    Console.Write("\nENTER new student first name: ");
                    stu.Info.FirstName = Console.ReadLine();
                    break;
                case 'L':
                case 'l':
                    Console.Write("\nENTER new student last name: ");
                    stu.Info.LastName = Console.ReadLine();
                    break;
                case 'G':
                case 'g':
                    Console.Write("\nENTER new student grade pt average: ");
                    stu.GradePtAvg = double.Parse(Console.ReadLine());
                    break;
                case 'E':
                case 'e':
                    Console.Write("\nENTER new student enrollment date: ");
                    stu.EnrollmentDate = DateTime.Parse(Console.ReadLine());
                    break;
            }
            Console.WriteLine($"\nEDIT operation done. Current record info:\n{stu}\nPress any key to continue...");
            Console.ReadKey();
        }
        private void DisplayModifyMenu()
        {
            Console.WriteLine(@"
             ********************************
             ******* Edit Student Menu ******
             [F]irst name
             [L]ast name
             [G]rade pt average
             [E]nrollment date
             [Y]ear in school           (undergrad only)
             [D]egree major             (undergrad only)
             [T]uition teaching credit  (graduate only)
             Faculty [A]dvisor          (graduate only)
             ** Email address can never be modified. See admin.
");
            Console.Write("ENTER edit menu selection: ");
        }



        private void AddStudentRecord()
        {
            // first, search the list to see if this email rec already exists
            string email = string.Empty;
            Student stu = FindStudentRecord(out email);
            if (stu == null)
            {
                // Record was not found - go ahead and add
                // first, gather all the data needed for a new student
                Console.WriteLine($"Adding new student, Email: {email}");

                // start gathering data
                Console.WriteLine("ENTER first name: ");
                string first = Console.ReadLine();
                Console.WriteLine("ENTER last name: ");
                string last = Console.ReadLine();
                Console.WriteLine("ENTER grade pt. average: ");
                double gpa = double.Parse(Console.ReadLine());
                // we need an email!
                Console.WriteLine("[U]ndergrad of [G]rad Student? ");
                string studentType = Console.ReadLine().ToUpper();

                if (studentType == "U")
                {
                    Console.WriteLine("[1]Freshman, [2]Sophomore, [3]Junior, [4]Senior");
                    Console.Write("ENTER year/rank in school from above choices: ");
                    YearRank rank = (YearRank)int.Parse(Console.ReadLine());

                    Console.Write("ENTER major degree program: ");
                    string major = Console.ReadLine();

                    stu = new Undergrad(first, last, gpa, email, DateTime.Now, rank, major);
                    students.Add(stu);

                }
                else if(studentType == "G")
                {
                    Console.WriteLine("ENTER the tuition reimbursement earned (no commas): $");
                    decimal discount = decimal.Parse(Console.ReadLine());
                    Console.Write("ENTER full name of graduate faculty advisor: ");
                    string facAdvisor = Console.ReadLine();

                    GradStudent grad = new GradStudent(first, last, gpa,
                                                        email, DateTime.Now,
                                                        discount, facAdvisor);

                    students.Add(grad);
                }
                else
                {
                    Console.WriteLine($"ERROR: No student created. \n" + 
                                        $"{studentType} is not valid type.");
                }
            }
            else
            {
                Console.WriteLine($"{email} RECORD FOUND! Can't add student {email}.\n" + 
                                                                    $"Record already exists.");
            }
        }

        private void DeleteStudentRecord()
        {
            string email = string.Empty;
            Student stu = FindStudentRecord(out email);

            if (stu != null)
            {
                // record was found = go ahead and remove it
                students.Remove(stu);

            }
            else
            {
                // record not in database
                Console.WriteLine($"**** RECORD NOT FOUND. \nCan't delete record for user:{ email}. ");
            }
        }

        private void SaveAllChangesAndQuit()
        {
            WriteDataToOutputFile();
            Environment.Exit(0);
        }

        private void ExitApplicationWithoutSave()
        {
            Environment.Exit(0);
        }

        private char GetUserSelection()
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            return keyPressed.KeyChar;
        }

        private void PrintAllRecords()
        {
            Console.WriteLine("Printing all students records in list: ");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine(@"********
****************************************
************ Studnent Database App *****
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
[A]dd a student record     (C in CRUD)
[F]ind a student record    (R in CRUD)
[P]rint all records
[D]elete a student record  (D in CRUD)
[M]odify a student record  (U in CRUD)
[E]xit without saving changes 
[S]ave changes and quit app
");
            Console.WriteLine("ENTER user selection: ");
        }
   
        
        // purpose or function of this method 
        internal void WriteDataToOutputFile()
        {
            StreamWriter outFile = new StreamWriter("OUTPUTFILE.txt");
            Console.WriteLine("Now writing data to the outout file...");

            foreach (var student in students)
            {
                // using the output file 
                outFile.WriteLine(student.ToStringForOutputFile());
                Console.WriteLine(student.ToStringForOutputFile());
                //Console.WriteLine(student);


            }
            // using the output file

            // close the output file
            outFile.Close();
            Console.WriteLine("Done writing data - file has been closed.");


        }
    }
}
