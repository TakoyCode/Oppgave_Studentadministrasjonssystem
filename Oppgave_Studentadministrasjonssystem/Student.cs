using System.Diagnostics;
using System.Xml.Linq;

namespace Oppgave_Studentadministrasjonssystem
{
    internal class Student
    {
        public string _name;
        private int _age;
        private int _studentId;
        private List<Subject> _subjects;
        private List<Grade> _grades;

        public Student(string name, int age, int studentId, List<Subject> subjects)
        {
            _name = name;
            _age = age; 
            _studentId = studentId;
            _subjects = subjects;
            _grades = new List<Grade>();
        }

        public void AddGrade(Subject subject, int grade)
        {
            _grades.Add(new Grade(this, subject, grade));
        }

        public void PrintOutInfoSummary()
        {
            string name = $"\nNavn: {_name}";
            string age = $"Alder: {_age}";
            string studentId = $"Student Id: {_studentId}";

            Console.WriteLine(name + PadSpacesLeft(name, 36) + age + PadSpacesLeft(age, 35) + studentId);
        }

        public void PrintOutInfoAll()
        {
            PrintOutInfoSummary();

            if (_subjects.Count > -1)
            {
                for (var index = 0; index < _subjects.Count; index++)
                {
                    var subject = _subjects[index];
                    
                    string text = "Fag:";
                    text += " " + subject._subjectName;

                    foreach (var grade in _grades)
                    {
                        if (subject == grade.Subject)
                        {
                            string gradeStr = $"Karakter: {grade.GradeNum}";

                            text += PadSpacesLeft(text, 35) + gradeStr + PadSpacesLeft(gradeStr, 35);
                        };
                    }
                    
                    string credit = $"Studie poeng: {subject.Credits}";
                    text += credit;
                    Console.WriteLine(text);
                }

                string averageGrade = $"Gjennomsnitts karakter: {GetAverageGrade()}";
                string totalCredits = $"Sammenlagt studiepoeng: {GetCredit()}";
                Console.WriteLine(PadSpacesLeft(35) + averageGrade + PadSpacesLeft(averageGrade,35) + totalCredits);
            }
        }

        private static string PadSpacesLeft(int padding)
        {
            return "".PadLeft(padding);
        }
        private static string PadSpacesLeft(string text, int padding)
        {
            return "".PadLeft(padding - text.Length);
        }

        private double GetAverageGrade()
        {
            int num = 0;
            int totalGrades = 0;
            foreach (var grade in _grades)
            {
                totalGrades++;
                num += grade.GradeNum;
            }
            return num / totalGrades;
        }

        private int GetCredit()
        {
            int num = 0;
            foreach (var subject in _subjects)
            {
                num += subject.Credits;
            }
            return num;
        }

    }

    
}
