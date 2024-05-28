namespace Oppgave_Studentadministrasjonssystem
{
    internal class Subject
    {
        public int _subjectCode;
        public string _subjectName;
        private int _credits;

        public Subject(string subjectName, int subjectCode, int credits)
        {
            _subjectCode = subjectCode;
            _subjectName = subjectName;
            _credits = credits;
        }

        public void PrintOutInfo()
        {
            Console.WriteLine($"\nFagnavn: {_subjectName}");
            Console.WriteLine($"Fagkode: {_subjectCode}");
            Console.WriteLine($"Antall Studiepoeng: {_credits}");
        }


    }
}
