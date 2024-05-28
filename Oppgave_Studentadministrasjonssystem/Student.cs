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

            Console.WriteLine(name + PadSpacesLeft(name, 35) + age + PadSpacesLeft(age, 25) + studentId);
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
                    
                    if (subject == _grades[index].Subject)
                    {
                        text += PadSpacesLeft(text, 34) + $"Karakter: {_grades[0].GradeNum}";

                    };
                    Console.WriteLine(text);
                }

            }
        }

        private static string PadSpacesLeft(string text, int padding)
        {
            return "".PadLeft(padding - text.Length);
        }
    }

    
}
