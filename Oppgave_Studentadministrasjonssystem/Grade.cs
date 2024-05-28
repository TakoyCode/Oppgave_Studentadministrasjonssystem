namespace Oppgave_Studentadministrasjonssystem
{
    internal class Grade
    {
        private Student _student;
        public Subject Subject { get; private set; }
        public int GradeNum;

        public Grade(Student student, Subject subject, int gradeNum)
        {
            _student = student;
            Subject = subject;
            GradeNum = gradeNum;
        }

        public void PrintOutInfo()
        {
            Console.WriteLine($"\nStudent: {_student._name}");
            Console.WriteLine($"Fag: {Subject._subjectName}");
            Console.WriteLine($"Karakter: {GradeNum}");
        }
    }
}
