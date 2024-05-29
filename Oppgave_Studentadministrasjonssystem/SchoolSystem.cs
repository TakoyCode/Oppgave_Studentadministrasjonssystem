using System.Threading.Tasks;

namespace Oppgave_Studentadministrasjonssystem
{
    internal class SchoolSystem
    {
        public static List<Subject> AllSubjects;
        public static List<Student> AllStudents;
        private static int _lastSubjectCode;

        public static void LoadSystem()
        {
            AllSubjects = new List<Subject>
            {
                new Subject("Abstract Math", GetCurrentSubjectCode(),30),
                new Subject("Intro to psychology", GetCurrentSubjectCode(),20),
                new Subject("Intro to computer science", GetCurrentSubjectCode(),25),
            };

            AllStudents = new List<Student>
            {
                new Student("Bob Smith", 32, 1, [SchoolSystem.GetSubjectViaCode(0)]),
                new Student("Steven Baker", 25, 2, [SchoolSystem.GetSubjectViaCode(1), SchoolSystem.GetSubjectViaCode(2)]),
            };

            AllStudents[0].AddGrade(AllSubjects[0], 4);
            AllStudents[1].AddGrade(AllSubjects[1], 2);
            AllStudents[1].AddGrade(AllSubjects[2], 6);
        }

        private static int GetCurrentSubjectCode()
        {
            return _lastSubjectCode++;
        }

        public static Subject GetSubjectViaCode(int subjectCode)
        {
            foreach (var subject in AllSubjects)
            {
                if (subjectCode == subject._subjectCode) return subject;
            }
            return null;
        }

        public static void Menu()
        {
            Console.Clear();
            ShowMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    ShowStudents();
                    break;
                case "2":
                    ShowSubjects();
                    break;
                case "3":
                    Environment.Exit(404);
                    break;
                default:
                    Menu();
                    break;
            }
        }

        private static void ShowStudents()
        {
            Console.Clear();
            foreach (var student in AllStudents)
            {
                student.PrintOutInfoSummary();
            }

            Console.Write($"\nSkriv inn student id for mer info eller trykk X for å gå tilbake: ");
            ShowStudentView();
        }

        private static void ShowStudentView()
        {
            string userinputStr = Console.ReadLine();
            if (userinputStr.ToLower() == "x") { return; }
            if (Int32.TryParse(userinputStr, out int userinput))
            {
                Console.Clear();
                for (int i = 0; i < AllStudents.Count; i++)
                {
                    if (userinput-1 == i)
                    {
                        AllStudents[i].PrintOutInfoAll();
                    }
                }

                Console.Write("\nTrykk på hvilken som helst tast for å gå til start...");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Skriv inn en student id neste gang :)");
                ShowStudentView();
            }
        }

        private static void ShowSubjects()
        {
            Console.Clear();
            foreach (var subject in AllSubjects)
            {
                subject.PrintOutInfo();
            }

            Console.Write("\nTrykk på hvilken som helst tast for å gå tilbake...");
            Console.ReadKey(true);
        }

        private static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1) Studenter");
            Console.WriteLine("2) Fag");
            Console.WriteLine("3) Exit");
        }
    }
}
